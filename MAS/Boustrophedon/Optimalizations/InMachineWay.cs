using Boustrophedon.Area;
using Boustrophedon.AreaObjects;
using Boustrophedon.Communication;
using Boustrophedon.Machine;
using Boustrophedon.WorldToCover;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boustrophedon.Optimalizations
{
   /// <summary>
   /// Whether the current machine will have to slow down because of the speed of machine in the previous cover line
   /// </summary>
   public class InMachineWay
    {

        public static bool IsInMyWay(MachineObject machineObject, AreaToCover areaToCover)
        {

            string coverlineID = areaToCover.GetLastCoverLine(machineObject.VerticalPosition);
            string reciverMachineID = string.Empty;
            try
            {
                reciverMachineID = World.CoverLinesList.Where(a => a.CoverLineID == coverlineID).First().MachineID;
            }
            catch { }

            if (string.IsNullOrEmpty(reciverMachineID))
                return false;

            Request request = new Communication.Request();

            request.RequestType = Communication.Enum.RequestType.CoverLineFinishStatus;
            request.SenderMachineID = machineObject.MachineID;
            request.ReceiverMachineID = reciverMachineID;
            request.CommunicationRequestID = (++World.CommunicationRequestID).ToString();

            Response response = request.Send();

            if (response.CoverLineFinish.MachineActualCoverLineDirection == World.GetCoverLineByID(machineObject.ActualCoverLineID).CoverLineDirection)
            {
                Coordinates a;
                Coordinates b;

                if ((World.CoverDirection == Enumerations.CoverDirection.leftToRight && machineObject.VerticalPosition == Enumerations.VerticalPosition.down)
                    || (World.CoverDirection == Enumerations.CoverDirection.rightToLeft && machineObject.VerticalPosition == Enumerations.VerticalPosition.up))
                {
                    a = areaToCover.LeftDown;
                    b = areaToCover.LeftUp;
                }

                else if ((World.CoverDirection == Enumerations.CoverDirection.leftToRight && machineObject.VerticalPosition == Enumerations.VerticalPosition.up)
                    || (World.CoverDirection == Enumerations.CoverDirection.rightToLeft && machineObject.VerticalPosition == Enumerations.VerticalPosition.down))
                {
                    a = areaToCover.RightDown;
                    b = areaToCover.RightUp;
                }

                else
                {
                    //TODO: minor - if coverDirection == both

                    a = areaToCover.RightDown;
                    b = areaToCover.RightUp;
                }

                //if the finishing time of cover line in front of current machine is smaller, then take this cover line
                if (response.CoverLineFinish.CoverLineFinishTime < DateTime.Now.AddSeconds(Helpers.Methods.GetCoveringTimeSeconds(a, b, machineObject.CoverSpeed)))
                    return true;
                else
                    return false;
                
            }
            //if the directions are same, machine are going opposite
            else
                return false;

        }
    }
}
