using Boustrophedon.AreaObjects;
using Boustrophedon.Machine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boustrophedon.GUI
{

    public partial class Boustrophedon : Form
    {
        private string ErrorMessage;


        public Boustrophedon()
        {
            InitializeComponent();
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            new WorldToCover.Initialization();
            rtbLog.AppendText("INITIALIZATION SUCCESFULL\n \n \n");

            rtbLog.AppendText(WorldToCover.World.StartCover());

            StringBuilder sbStatistics = new StringBuilder();

            foreach (Machine.MachineObject machine in Machine.Machines.MachineList.OrderBy(a => a.MachineID))
            {
                sbStatistics.AppendLine("Machine ID:\t" + machine.MachineID);
                sbStatistics.AppendLine("Working width:\t" + machine.WorkingWidth);
                sbStatistics.AppendLine("Working distance:\t" + machine.WorkingDistance);
                sbStatistics.AppendLine("Other distance:\t" + machine.OtherDistance);
                sbStatistics.AppendLine("Total distance:\t" + (machine.WorkingDistance + machine.OtherDistance));
                sbStatistics.AppendLine("\n\n");
            }

            rtbMachineStatisticsText.Text = sbStatistics.ToString();
        }

        private void btAddMachine_Click(object sender, EventArgs e)
        {
            if (AddNewMachineIsValid())
            {
                SetNewMachine();
                ClearValues();
                RebindTable();
            }
            else
            {
                ShowMessagwBox(ErrorMessage, "Error", icon: MessageBoxIcon.Error);
            }
        }

        private void RebindTable()
        {
            var bindingList = new BindingList<Machine.MachineObject>(Machines.MachineList);
            var source = new BindingSource(bindingList, null);

            //Machines.MachineList.First().TurningRadius;

            dgwMachinesList.DataSource = source;
        }

        private void ClearValues()
        {
            nudVolume.Value = 0;
            nudWorkingSpeed.Value = 0;
            nudTransportSpeed.Value = 0;
            nudWorkingWidth.Value = 0;
            nudTurningRadius.Value = 0;
        }

        private bool AddNewMachineIsValid()
        {
            if (nudVolume.Value > 0
                && nudWorkingSpeed.Value > 0
                && nudTransportSpeed.Value > 0
                && nudWorkingWidth.Value > 0
                && nudTurningRadius.Value > 0

                && cbVolumeUnit.SelectedIndex > -1
                && cbWorkingSpeedUnit.SelectedIndex > -1
                && cbTransportSpeedUnit.SelectedIndex > -1
                && cbWorkingWidthUnits.SelectedIndex > -1
                && cbTurningRadiusUnit.SelectedIndex > -1
                )
            {
                return true;
            }
            else
            {
                ErrorMessage = "All fields are required";
                return false;
            }
        }

        private void ShowMessagwBox(string message, string title = "", MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Information, MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1)
        {
            DialogResult messageBox = MessageBox.Show(message, title, buttons, icon, defaultButton);
        }

        private void SetNewMachine()
        {
            var machine = new MachineObject();
            machine.CoverSpeed = Helpers.Methods.GetMetersPerSecond(nudWorkingSpeed.Value, cbWorkingSpeedUnit.SelectedItem.ToString());
            machine.Position = new Coordinates(0, 0);
            machine.TransportSpeed = Helpers.Methods.GetMetersPerSecond(nudTransportSpeed.Value, cbTransportSpeedUnit.SelectedItem.ToString());
            machine.TurningRadius = Helpers.Methods.GetMeters(nudTurningRadius.Value, cbTurningRadiusUnit.SelectedItem.ToString());
            machine.WorkingWidth = Helpers.Methods.GetMeters(nudWorkingWidth.Value, cbWorkingWidthUnits.SelectedItem.ToString());
            machine.Type = rbPrimary.Checked ? Enumerations.MachineType.primary : Enumerations.MachineType.secondary;
        }
    }
}
