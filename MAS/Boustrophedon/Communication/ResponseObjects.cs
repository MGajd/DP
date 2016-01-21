using Boustrophedon.AreaObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boustrophedon.Communication
{
    public class CoverLineFinishObject 
    {
        public Enumerations.CoverLineDirection MachineActualCoverLineDirection;

        public DateTime CoverLineFinishTime {
            get; set;
        }


        public void SetMachineActualCoverDirection(CoverLine actualCoverLine) {
            MachineActualCoverLineDirection = actualCoverLine.CoverLineDirection;



        }
    }
}
