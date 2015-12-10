using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boustrophedon.Machine
{
    public static class Machines
    {
        public static int machineIDCounter = 0;
        public static List<MachineObject> MachineList;
        public static decimal TotalWorkingWidth;

        internal static List<MachineObject> GetMachines(List<string> machinesIDs)
        {
            List<MachineObject> machinesByIds = new List<MachineObject>();

            foreach (var id in machinesIDs)
            {
                machinesByIds.Add(MachineList.Where(a => a.MachineID == id).First());
            }

            return machinesByIds;
        }

        public static void AddMachineToList(MachineObject machineObject)
        {
            MachineList.Add(machineObject);
            TotalWorkingWidth += machineObject.WorkingWidth;
        }


        public static void RemoveMachineFromList(MachineObject machineObject)
        {
            int index = 0;
            foreach (var machine in MachineList)
            {
                if (machine.MachineID == machineObject.MachineID)
                {
                    TotalWorkingWidth -= machine.WorkingWidth;
                    break;
                }

                index++;
            }

            MachineList.RemoveAt(index);
        }

        internal static MachineObject GetMachineByID(string machineID)
        {
            return MachineList.Where(a => a.MachineID == machineID).First();
        }
    }
}
