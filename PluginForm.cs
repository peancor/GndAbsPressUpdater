using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GndAbsPressUpdater
{
    public partial class PluginForm : Form
    {
        public PluginForm()
        {
            InitializeComponent();
        }

        private void MEdronicalLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.edronica.com");
        }
    }
}
