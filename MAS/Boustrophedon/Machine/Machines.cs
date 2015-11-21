using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boustrophedon.Machine
{
    public static class Machines
    {
        public static List<MachineObject> MachineList;
        public static decimal TotalWorkingWidth;



        public static void AddMachineToList(MachineObject machineObject)
        {
            MachineList.Add(machineObject);
            TotalWorkingWidth += machineObject.Width;
        }


        public static void RemoveMachineFromList(MachineObject machineObject)
        {
            int index = 0;
            foreach (var machine in MachineList)
            {
                if (machine.MachineID == machineObject.MachineID)
                {
                    TotalWorkingWidth -= machine.Width;
                    break;
                }

                index++;
            }

            MachineList.RemoveAt(index);
        }
    }
}
