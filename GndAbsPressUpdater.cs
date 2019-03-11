using MissionPlanner;
using MissionPlanner.Plugin;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GndAbsPressUpdater
{
    public enum PressureUnitEnum
    {
        mbar = 0,
        Pa = 1,
    }

    public class GndAbsPressUpdater : Plugin
    {
        public override string Name => "Ground Absolute Pressure Updater";

        public override string Version => "v1";

        public override string Author => "peancor";

        const string ComPortConfigKey = "GndAbsPressUpdaterComPort";
        const string TsConfigKey = "GndAbsPressUpdaterTs";
        const string MaxPressureDeltaPaConfigKey = "GndAbsPressUpdaterMaxPressureDeltaPa";
        const string PressureUnitConfigKey = "GndAbsPressUpdaterPressureUnit";

        int mTs = 10;
        public int Ts
        {
            get => mTs;
            set
            {
                if (value < 1) value = 1;
                if (value > 10000) value = 1000;
                mTs = value;
                loopratehz = 1.0f / value;
            }
        }

        int mMaxPressureDelta;
        public int MaxPressureDeltaPa
        {
            get => mMaxPressureDelta;

            set
            {
                if (value < 1) value = 1;
                if (value > 1000) value = 1000;
                mMaxPressureDelta = value;
            }
        }
        public PressureUnitEnum PressureUnit { get; set; }
        string ComPort { get; set; } = "COM3";
        public bool IsEnabled { get; set; }

        PluginForm mForm;

        public override bool Exit()
        {
            return true;
        }

        public override bool Init()
        {
            Console.WriteLine("Ground Absolute Pressure Updater Init");
            //establecemos la frecuencia de actualización
            loopratehz = 1.0f / mTs;

            RestoreConfigInModel();

            //Creamos el menú
            var menuItem = new ToolStripMenuItem("Ground Absolute Pressure Updater Config");
            menuItem.Click += ConfigMenu_Click;
            Host.FDMenuMap.Items.Add(menuItem);

            //Y el form
            BuildForm();

            return true;
        }

        void RestoreConfigInModel()
        {
            ComPort = RestoreOrCreateConfigKey(ComPortConfigKey, "").ToString();
            if (int.TryParse(RestoreOrCreateConfigKey(TsConfigKey, "10"), out int r))
            {
                Ts = r;
            }
            if (int.TryParse(RestoreOrCreateConfigKey(MaxPressureDeltaPaConfigKey, "50"), out r))
            {
                MaxPressureDeltaPa = r;
            }

            var pressureUnit = RestoreOrCreateConfigKey(PressureUnitConfigKey, PressureUnitEnum.mbar.ToString());
            if (Enum.TryParse<PressureUnitEnum>(pressureUnit, out PressureUnitEnum pu))
            {
                PressureUnit = pu;
            }
        }

        string RestoreOrCreateConfigKey(string key, string defaultValue)
        {
            //leemos la configuración            
            if (Host.config.ContainsKey(key) == false)
            {
                Host.config[key] = defaultValue;
                Host.config.Save();
                return defaultValue;
            }
            else
            {
                return Host.config[key];
            }
        }

        void ValidateFormUpdateModelAndSaveConfigInDb()
        {
            //guardamos el puerto com
            ComPort = mForm.mComPortTextBox.Text;
            Host.config[ComPortConfigKey] = ComPort;
            //El Ts
            if (int.TryParse(mForm.mUpdatePeriodTextBox.Text, out int r))
            {
                Ts = r;
                Host.config[TsConfigKey] = Ts.ToString();
            }
            //El max delta
            if (int.TryParse(mForm.mDeltaPressureMax.Text, out r))
            {
                MaxPressureDeltaPa = r;
                Host.config[MaxPressureDeltaPaConfigKey] = MaxPressureDeltaPa.ToString();
            }
            //y la unidad
            if (Enum.TryParse<PressureUnitEnum>(mForm.mGroundUnitsComboBox.SelectedItem.ToString(), out PressureUnitEnum pu))
            {
                PressureUnit = pu;
                Host.config[PressureUnitConfigKey] = PressureUnit.ToString();
            }
            //guardamos
            Host.config.Save();
        }

        void BuildForm()
        {
            mForm = new PluginForm();
            mForm.mGroundUnitsComboBox.Items.AddRange(Enum.GetNames(typeof(PressureUnitEnum)));
            UpdateFormParams();
            mForm.mSaveButton.Click += (o, e) =>
              {
                  ValidateFormUpdateModelAndSaveConfigInDb();
                  //RestoreConfigInModel();
                  IsEnabled = mForm.mIsEnabledCheckBox.Checked;
                  mForm.Hide();
              };
            mForm.FormClosing += (o, e) =>
              {
                  //ocultamos el form en vez de cerrarlo
                  e.Cancel = true;
                  mForm.Hide();
              };
        }

        public void AddMessage(string msg)
        {
            mForm.BeginInvoke((Action)delegate
            {
                mForm.mMessagesListBox.Items.Insert(0, DateTime.Now + ": " + msg);
            });
        }

        void UpdateFormParams()
        {
            mForm.mComPortTextBox.Text = ComPort;
            mForm.mUpdatePeriodTextBox.Text = Ts.ToString();
            mForm.mDeltaPressureMax.Text = MaxPressureDeltaPa.ToString();
            mForm.mGroundUnitsComboBox.SelectedIndex = mForm.mGroundUnitsComboBox.FindStringExact(PressureUnit.ToString());

        }

        private void ConfigMenu_Click(object sender, EventArgs e)
        {
            mForm.Show();
        }

        public override bool Loaded()
        {
            return true;
        }

        public override bool Loop()
        {
            if (!IsEnabled)
            {
                AddMessage("Plugin not enabled");
                return true;
            }

            if (MainV2.comPort.BaseStream.IsOpen == false)
            {
                AddMessage("Mavlink is not connected");
                return true;
            }
            if (SerialPort.GetPortNames().Contains(ComPort))
            {
                try
                {
                    using (SerialPort p = new SerialPort { PortName = ComPort, BaudRate = 9600, ReadTimeout = 5000, WriteTimeout = 5000 })
                    {
                        p.Open();
                        p.WriteLine("p");
                        var response = p.ReadLine();
                        if (float.TryParse(response, NumberStyles.Float, CultureInfo.InvariantCulture, out float pressure))
                        {
                            //Actualizamos la presión
                            AddMessage($"Ground pressure read: {pressure} {PressureUnit}");
                            var currentQNH = MainV2.comPort.GetParam("GND_ABS_PRESS");
                            var newPressurePa = pressure * (PressureUnit == PressureUnitEnum.mbar ? 100 : 1);
                            //Si la presión es muy parecida no actualizamos
                            var epsilon = 10;
                            var delta = newPressurePa - currentQNH;
                            var deltaAbs = Math.Abs(delta);
                            if (deltaAbs < epsilon)
                            {
                                AddMessage($"Pressure almost equal (not updated): mavlink={currentQNH.ToString("F0")}, new={newPressurePa.ToString("F0")}");
                            }
                            else
                            {
                                //No debemos superar la delta máxima
                                if (deltaAbs > MaxPressureDeltaPa)
                                {
                                    delta = delta > 0 ? MaxPressureDeltaPa : -MaxPressureDeltaPa;                                    
                                }
                                newPressurePa += delta;
                                var smoothUpdateNewPressurePa = 0.7 * currentQNH + 0.3 * newPressurePa;
                                MainV2.comPort.setParam("GND_ABS_PRESS", smoothUpdateNewPressurePa);
                                AddMessage($"Pressure updated: mavlink={currentQNH.ToString("F0")}, new={smoothUpdateNewPressurePa.ToString("F0")}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    AddMessage("Comm Error: " + ex.Message);
                }
            }
            else
            {
                AddMessage("COM port not selected or port not exists");
            }

            return true;
        }
    }
}
