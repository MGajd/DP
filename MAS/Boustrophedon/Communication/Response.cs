using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boustrophedon.Communication
{
    public class Response
    {
        public string CommunicationRequestID;
        public string CommunicationResponseID;

        public string SenderMachineID;
        public string ReceiverMachineID;


        public CoverLineFinishObject CoverLineFinish;


    }
}
