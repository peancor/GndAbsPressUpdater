# GndAbsPressUpdater
A Mission Planner plugin for updating the ground pressure on the autopilot periodically.

it requires a Serial Port barometer at 9600bps. When the barometer receives a line with the character 'p' it must respond with another line containing the pressure in mbar or in Pa.

The plugin is activated clicking on the context menu of the map (right button).
