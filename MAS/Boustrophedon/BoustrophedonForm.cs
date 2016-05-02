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
    }
}
