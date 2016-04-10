using Boustrophedon.AreaObjects;
using Boustrophedon.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boustrophedon.Machine
{
    public partial class MachineObject
    {
        internal Response ProcessRequest(Request request)
        {
            CoverLine actualCoverLine = WorldToCover.World.GetCoverLineByID(ActualCoverLineID);

            Response response = null; //new Response();

            switch (request.RequestType)
            {
                case Communication.Enum.RequestType.CoverLineFinishStatus:
                    response = AssumedCoverLineFinishResponse(actualCoverLine);
                    break;
                case Communication.Enum.RequestType.StatusRequest:
                 //   break;
                case Communication.Enum.RequestType.ReplaceRequest:
                 //   break;
                case Communication.Enum.RequestType.MeetingRequest:
                 //   break;
                case Communication.Enum.RequestType.CommonRideRequest:
                 //   break;
                case Communication.Enum.RequestType.StopRequest:
                 //   break;
                default:
                    response = new Response();
                    break;
            }

            response.CommunicationRequestID = request.CommunicationRequestID;
            response.ReceiverMachineID = request.SenderMachineID;
            response.SenderMachineID = MachineID;


            return response;

        }

        private Response AssumedCoverLineFinishResponse(CoverLine actualCoverLine)
        {
            Response response = new Response();

            response.CoverLineFinish = new CoverLineFinishObject();
            response.CoverLineFinish.SetMachineActualCoverDirection(actualCoverLine);
            response.CoverLineFinish.CoverLineFinishTime = EndsAt;


            return response;
      }
    }
}
