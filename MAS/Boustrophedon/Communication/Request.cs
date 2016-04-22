using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Boustrophedon.Communication.Enum;

namespace Boustrophedon.Communication
{
    public class Request
    {
        public string CommunicationRequestID;

        public string SenderMachineID;
        public string ReceiverMachineID;

        public bool IsSynchronous = true;
        public RequestType RequestType;

        internal Response Send()
        {
            if (ReceiverMachineID == BROADCAST)
            {
                //TODO: major - implement broadcast if needed
                throw new NotImplementedException();
            }

            else if (IsSynchronous)
            {
                return Machine.Machines.MachineList.Where(a => a.MachineID == ReceiverMachineID).First().ProcessRequest(this);
            }
            else
            {
                Machine.Machines.MachineList.Where(a => a.MachineID == ReceiverMachineID).First().ProcessRequest(this);
                return null;
            }
        }
    }
}
