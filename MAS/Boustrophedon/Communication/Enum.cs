using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boustrophedon.Communication
{
    public static class Enum
    {

        public const string BROADCAST = "broadcast";

        public enum RequestType {
            

            /// <summary>
            /// Machine sends info about finishing cover line
            /// </summary>
            CoverLineFinishStatus,
            
            /// <summary>
            /// To get machine status
            /// </summary>
            StatusRequest,

            /// <summary>
            /// When the replacement of current machine is needed
            /// </summary>
            ReplaceRequest,

            /// <summary>
            /// Use when two machines need to meet
            /// </summary>
            MeetingRequest,

            /// <summary>
            /// When two machines needs to ride along together.
            /// </summary>
            CommonRideRequest,

            /// <summary>
            /// When the machine needs to stop another machine.
            /// </summary>
            StopRequest
        }

        public enum CommunicationForm {

            /// <summary>
            /// whern sending message to all machines
            /// </summary>
            Broadcast,

            /// <summary>
            /// When sending message to all primary machines
            /// </summary>
            PrimaryBroadcast,

            /// <summary>
            /// When sending message to all secondary machines
            /// </summary>
            SecondaryBroadcast,

            /// <summary>
            /// Communication between two primary machines
            /// </summary>
            Primary_Primary,

            /// <summary>
            /// Communication between two secondary machines
            /// </summary>
            Secondary_Secondary,

            /// <summary>
            /// Communication between primary and secondary machine
            /// </summary>
            Primary_Secondary


        }


    }
}
