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
        }
    }
}
