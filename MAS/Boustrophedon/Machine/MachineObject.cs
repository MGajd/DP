using Boustrophedon.AreaObjects;
using Boustrophedon.WorldToCover;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boustrophedon.Area;

namespace Boustrophedon.Machine
{
    public partial class MachineObject
    {

        public Coordinates Position;

        public string ActualCoverLineID;
        public string NextCoverLineID;

        public string MachineID;
        public decimal TransportSpeed;
        public decimal NonCoverSpeed;

        public bool CanWorkSideToSide = false;
        public bool CanGoOpposite = false;

        private decimal _workingWidth;
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

        public decimal WorkingWidth
        {
            get
            {
                return _workingWidth;
            }

            set
            {
                _workingWidth = value;
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

        public Enumerations.HorizontalPosition HorizontalPosition
        {
            get {
                var machinePosition = GetMachinePositionToCoverArea();
                if ( machinePosition == Enumerations.MachinePositionToCoverArea.leftDown || machinePosition == Enumerations.MachinePositionToCoverArea.LeftUp)
                    return Enumerations.HorizontalPosition.left;
                else
                    return Enumerations.HorizontalPosition.right;
            }
        }

        public Enumerations.VerticalPosition VerticalPosition
        {
            get
            {
                var machinePosition = GetMachinePositionToCoverArea();
                if (machinePosition == Enumerations.MachinePositionToCoverArea.leftDown || machinePosition == Enumerations.MachinePositionToCoverArea.rightDown)
                    return Enumerations.VerticalPosition.down;
                else
                    return Enumerations.VerticalPosition.up;
            }
        }


        public MachineObject() {
            if (Machines.MachineList == null)
            {
                Machines.MachineList = new List<MachineObject>();
                Machines.TotalWorkingWidth = 0;
            }
            Machines.MachineList.Add(this);

            if (World.CoverageStarted)
                World.AddMachineToCover(this);
        }



        /// <summary>
        /// Method that initiates the process of coverring for current machine
        /// </summary>
        /// <returns></returns>
        internal string StartWork()
        {

            //TODO:critical - StartWork;

            throw new NotImplementedException();

        }

        /// <summary>
        /// Return CoverLine where machine starts its work
        /// </summary>
        /// <returns></returns>
        public string GetFirstCoverLine(string areaToCoverID)
        {
            var machinePosition = GetMachinePositionToCoverArea();

            CoverLine coverLine;
            if (!DivideIsNecessary(areaToCoverID, machinePosition))
            {


                coverLine =  GetCoverLine(machinePosition, World.CoverDirection);


                //switch (World.CoverDirection)
                //{
                //    case (int) Enumerations.CoverDirection.leftToRight:
                //        return GetFirstCoverLineFromLeft(GetFirstCoverLineDirection());

                //    case (int)Enumerations.CoverDirection.rightToLeft:
                //        return GetFirstCoverLineFromRight(GetFirstCoverLineDirection());


                //    case (int)Enumerations.CoverDirection.both:
                //        throw new NotImplementedException();

                //    default:
                //        throw new NotImplementedException();
                //}
            }
            else
                coverLine = DivideCoverArea(machinePosition ,areaToCoverID);


            coverLine.MachineID = this.MachineID;

            NextCoverLineID = coverLine.CoverLineID;
            World.AddCoverLine(coverLine, WorkingWidth);

            return coverLine.CoverLineID;   
        }

        private CoverLine GetCoverLine(Enumerations.MachinePositionToCoverArea machinePositionToCoverArea, Enumerations.CoverDirection coverDirection)
        {
            AreaToCover areaToCover = GetBestAreaToCoverIDForMachine(MachineID, machinePositionToCoverArea);
            CoverLine coverLine = areaToCover.GetCoverLine(VerticalPosition, WorkingWidth);

             //TODO:blocker - decide when area is inner
            if (areaToCover.AreaToCoverID == World.GetAreaToCoverByCoverLineID(ActualCoverLineID).AreaToCoverID)
                coverLine.CoverLinePosition = Enumerations.CoverLinePosition.outer;
            else
                coverLine.CoverLinePosition = Enumerations.CoverLinePosition.inner;

            coverLine.AreaToCoverID = areaToCover.AreaToCoverID;

            return coverLine;
        }

        private AreaToCover GetBestAreaToCoverIDForMachine(string machineID, Enumerations.MachinePositionToCoverArea machinePositionToCoverArea)
        {

            if (!string.IsNullOrEmpty(ActualCoverLineID))
            {
                CoverLine actualCoverLine = World.GetCoverLine(ActualCoverLineID);
                string areaID = string.Empty;

                switch (World.CoverDirection)
                {
                    case Enumerations.CoverDirection.leftToRight :
                        if (VerticalPosition == Enumerations.VerticalPosition.down)
                        {
                            string nextAreaID = ((int.Parse(actualCoverLine.AreaToCoverID)) -1).ToString();
                            if (World.AreaExists(nextAreaID))
                                areaID = (GetNearerAreaToCover(Position, actualCoverLine.AreaToCoverID, nextAreaID ));
                            else
                                areaID = actualCoverLine.AreaToCoverID;

                        }

                        break;
                    case Enumerations.CoverDirection.rightToLeft:
                        //TODO:minor - rightToLeft

                        throw new NotImplementedException();

                    default:
                        throw new NotImplementedException();
                }

                return World.GetAreaByID(areaID);
            }

            //TODO:critical - left or right  
            List<AreaToCover> orderedAreaToCoverList = OrderAreasToCoverByMachinePosition((int)machinePositionToCoverArea);

            foreach (var area in orderedAreaToCoverList)
            {
                if (area.IsHelpNeeded() && area.CanBeMachineAdded(machineID))
                    return area;
            }

            return GetSlowestArea();

        }



        /// <summary>
        /// Returns ID of AreaToCover, that is going to be covered last
        /// </summary>
        /// <returns></returns>
        private AreaToCover GetSlowestArea()
        {
            //TODO:major - return ID of area that is going to be covered last
            return World.AreasToCover.Last();
        }


        /// <summary>
        /// Orders List<AreaToCover> from the best to the worst due to machine position.
        /// </summary>
        /// <param name="machinePositionToCoverArea"></param>
        /// <returns></returns>
        private List<AreaToCover> OrderAreasToCoverByMachinePosition(int machinePositionToCoverArea)
        {
            AreaToCover[] tempAreaToCover = new AreaToCover[World.AreasToCover.Count];
            World.AreasToCover.CopyTo(tempAreaToCover);
            var tempAreaToCoverList = tempAreaToCover.ToList();


            if (machinePositionToCoverArea > 1 && machinePositionToCoverArea < 4)
                tempAreaToCoverList.Reverse();

            return tempAreaToCoverList;

        }



        //private string GetFirstCoverLineFromLeft(Enumerations.MachinePositionToCoverArea machinePositionToCoverArea)
        //{
        //    string AreaToCoverID = GetAreaToCoverID(MachineID, machinePositionToCoverArea, );
        //}


        //private string GetFirstCoverLineFromRight(Enumerations.MachinePositionToCoverArea machinePositionToCoverArea)
        //{
        //}


        //private string GetAreaToCoverID(string machineID)
        //{
        //}




        private Enumerations.MachinePositionToCoverArea GetMachinePositionToCoverArea()
        {
            //first gets left or right to know whether check AreaToCover from left or right

            //left
            if (this.Position.X < (World.AreasToCover.OrderBy(a => a.MinX).First().MinX + World.AreasToCover.OrderByDescending(a => a.MaxX).First().MaxX) / 2)
            {
                //down
                if (this.Position.Y < (World.AreasToCover.OrderBy(a => a.MinY).First().MinY + World.AreasToCover.OrderByDescending(a => a.MaxY).First().MaxY) / 2)
                    return Enumerations.MachinePositionToCoverArea.leftDown;
                //up
                else
                    return Enumerations.MachinePositionToCoverArea.LeftUp;
            }
            //right
            else
            {
                //down
                if (this.Position.Y < (World.AreasToCover.OrderBy(a => a.MinY).First().MinY + World.AreasToCover.OrderByDescending(a => a.MaxY).First().MaxY) / 2)
                    return Enumerations.MachinePositionToCoverArea.rightDown;
                //up
                else
                    return Enumerations.MachinePositionToCoverArea.rightUp;
            }
        }

        /// <summary>
        /// Check whether to divide area.
        /// </summary>
        /// <param name="AreaToCoverID">ID of the area.</param>
        /// <returns>Returns bolean value whether the area should be divided.</returns>
        private bool DivideIsNecessary(string AreaToCoverID, Enumerations.MachinePositionToCoverArea machinePosition)
        {
            //TODO:critical - optimalization implement the decision of the area divide

            
            if ((World.CoverDirection == Enumerations.CoverDirection.leftToRight && machinePosition == Enumerations.MachinePositionToCoverArea.leftDown)
            || (World.CoverDirection == Enumerations.CoverDirection.rightToLeft && machinePosition == Enumerations.MachinePositionToCoverArea.rightUp))
                return false;

            if (Machines.MachineList.Select(a => a.WorkingWidth).Sum() * 2 < World.GetAreaByID(AreaToCoverID).Width)
                return true;

            return false;
        }


        private CoverLine DivideCoverArea(Enumerations.MachinePositionToCoverArea machinePosition, string areaToCoverID)
        {
            //TODO:critical - DivideCoverArea;

            List<string> machinesWithMeIDs = World.GetMachinesToBeOnTheSameCoverArea(areaToCoverID);

            decimal width = this.CalculateWidthToDivide(machinesWithMeIDs);
            CoverLine coverLine;


            if ((int)machinePosition > 2 && World.CoverDirection == Enumerations.CoverDirection.leftToRight)
            {
                coverLine = World.GetAreaByID(areaToCoverID).GetLineFromLeft(width, WorkingWidth);
            }
            else if ((int)machinePosition < 3 && World.CoverDirection == Enumerations.CoverDirection.rightToLeft)
            {
                coverLine = World.GetAreaByID(areaToCoverID).GetLineFromRight(width, WorkingWidth);

            }

            else
                throw new Exception("Should not divide!");

            coverLine.IsDivide = true;
            coverLine.CoverLinePosition = Enumerations.CoverLinePosition.inner;
            coverLine.AreaToCoverID = areaToCoverID;

            return coverLine;

        }
    }
}
