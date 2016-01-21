using Boustrophedon.Area;
using Boustrophedon.AreaObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boustrophedon.Communication;

namespace Boustrophedon.Machine
{
    public partial class MachineObject
    {
        private decimal CalculateWidthToDivide(List<string> machinesIDs)
        {
            List<MachineObject> machines = Machines.GetMachines(machinesIDs);

            var widths = machines.Select(a => a.WorkingWidth);

            //TODO:minor - optimalize
            return widths.Sum()*3;
        }

        private string GetNearerAreaToCover(Coordinates position, string area1ID, string area2ID)
        {
            //TODO:minor check if all case-s + if-es are necesarry
            switch (WorldToCover.World.CoverDirection)
            {
                case Enumerations.CoverDirection.leftToRight:
                    if (VerticalPosition == Enumerations.VerticalPosition.down)
                    {
                        if (Helpers.Methods.GetDistance(position, WorldToCover.World.GetAreaByID(area1ID).LeftDown) - WorkingWidth/2 < Helpers.Methods.GetDistance(position, WorldToCover.World.GetAreaByID(area2ID).LeftDown) + WorkingWidth/2)
                            return area1ID;
                        else
                            return area2ID;
                    }

                    break;
                default:
                    //TODO:minor Implement othe cover direction decisionns
                    throw new NotImplementedException("Implement othe cover direction decisionns");
            }
            return area1ID;      
        }


    }
}
