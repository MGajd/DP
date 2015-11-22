using Boustrophedon.AreaObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boustrophedon.Machine
{
    public class MachineObject
    {

        public string ActualCoverLineID;
        public string NextCoverLineID;

        public string MachineID;
        public decimal TransportSpeed;
        public decimal NonCoverSpeed;

        public bool CanWorkSideToSide = false;
        public bool CanGoOpposite = false;

        private decimal _width;
        private decimal _coverSpeed;
        private decimal _turningRadius;

        /// <summary>
        /// Distance that can be traveled by machine due to energy source (i.e. fuel).
        /// </summary>
        private int _energySourceLimitation = -1;

        /// <summary>
        /// Distance that can be traveled by machine due to stack source (carriage space).
        /// </summary>
        private int _spaceLimitaion = -1;

        /// <summary>
        /// Domain specific informations.
        /// </summary>
        private List<object> _domainSpecifics;

        /// <summary>
        /// Domain specific limitations.
        /// </summary>
        private List<object> _domainLimitations;

        public decimal Width
        {
            get
            {
                return _width;
            }

            set
            {
                _width = value;
            }
        }

        public decimal CoverSpeed
        {
            get
            {
                return _coverSpeed;
            }

            set
            {
                _coverSpeed = value;
            }
        }

        public decimal TurningRadius
        {
            get
            {
                return _turningRadius;
            }

            set
            {
                _turningRadius = value;
            }
        }

        public int EnergySourceLimitation
        {
            get
            {
                return _energySourceLimitation;
            }

            set
            {
                _energySourceLimitation = value;
            }
        }

        public int SpaceLimitaion
        {
            get
            {
                return _spaceLimitaion;
            }

            set
            {
                _spaceLimitaion = value;
            }
        }

        public List<object> DomainSpecifics
        {
            get
            {
                return _domainSpecifics;
            }

            set
            {
                _domainSpecifics = value;
            }
        }

        public List<object> DomainLimitations
        {
            get
            {
                return _domainLimitations;
            }

            set
            {
                _domainLimitations = value;
            }
        }

        public MachineObject() {
            if (Machines.MachineList == null)
            {
                Machines.MachineList = new List<MachineObject>();
                Machines.TotalWorkingWidth = 0;
            }
            Machines.MachineList.Add(this);

            if (WorldToCover.World.CoverageStarted)
                WorldToCover.World.AddMachineToCover(this);
        }

        /// <summary>
        /// Method that initiates the process of coverring for current machine
        /// </summary>
        /// <returns></returns>
        internal string StartWork()
        {


        }

        /// <summary>
        /// Return CoverLine where machine starts its work
        /// </summary>
        /// <returns></returns>
        public string GetFirstCoverLine()
        {

            if (WorldToCover.World.CoverageStarted && !DivideIsNecessary("1"))
            {
                switch (WorldToCover.World.CoverDirection)
                {
                    case (int) Enumerations.CoverDirection.leftToRight:
                        return GetFirstCoverLineFromLeft(Enumerations.CoverLineDirection.upToDown);
                        
                    case (int)Enumerations.CoverDirection.rightToLeft:
                        return GetFirstCoverLineFromRight(Enumerations.CoverLineDirection.upToDown);


                    case (int)Enumerations.CoverDirection.both:
                        throw new NotImplementedException();
                        
                    default:
                        throw new NotImplementedException();
                }
            }
            
        }

        private bool DivideIsNecessary(string v)
        {
        }

        private string GetFirstCoverLineFromRight(Enumerations.CoverLineDirection upToDown)
        {

        }

        private string GetFirstCoverLineFromLeft(Enumerations.CoverLineDirection upToDown)
        {
        }

        private string DivideCoverArea(string CoverAreaID)
        {
        }
    }
}
