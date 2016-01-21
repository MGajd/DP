using Boustrophedon.Area;
using Boustrophedon.AreaObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boustrophedon.Machine;

namespace Boustrophedon.WorldToCover
{
    public static class World
    {

        public static int CoverLineIDCounter = 1;
        public static int AreaToCoverIDCounter = 1;
        public static int CommunicationRequestID = 0;
        public static int CommunicationResponseID = 0;


        public static bool AreaCovered = false;
        public static bool CoverageStarted = false;

        public static Enumerations.CoverDirection CoverDirection = Enumerations.CoverDirection.leftToRight;

        public static bool GoAroundAreaToCover = false;
        public static bool GoAroundObstacles = false;

        public static int GoAroundAreaTimes = 0;
        public static decimal GoAroundAreaWidth = 0;

        public static int GoAroundObstaclesTimes = 0;
        public static decimal GoAroundObstaclesWidth = 0;

        public static decimal previousUncovered = 0;



        public static List<AreaToCover> AreasToCover;
        public static List<CoveredSubArea> CoveredSubAreaList;
        public static List<CoverLine> CoverLinesList;


        public static void AddCoveredSubArea(CoveredSubArea subArea)
        {
            //TODO: critical - add subarea, find if new, or add to existing in Covered

        }


        public static CoverLine GetCoverLineByID(string coverLineID)
        {
            List<CoverLine> returnCoverLineList = CoverLinesList.Where(a => a.CoverLineID == coverLineID).ToList();
            return returnCoverLineList.Count == 0 ? null : returnCoverLineList.First();
        }

        public static void AddCoverLine(CoverLine newCoverLine, decimal width)
        {
            CoverLinesList.Add(newCoverLine);

            if (newCoverLine.IsDivide)
                return;
            AreaToCover area = AreasToCover.Where(a => a.AreaToCoverID == newCoverLine.AreaToCoverID).First();
            if (area.LeftDown.X + width / 2 == newCoverLine.StartingCoordinates.X || area.LeftDown.X + width / 2 == newCoverLine.EndingCoordinates.X)
            {
                area.MinusWidthFromLeft(width);
            }
            else
            {
                area.MinusWidthFromRight(width);
            }

            if (area.CoordinateList[0].X >= area.CoordinateList[1].X)
            {
                int index = 0;
                while (index < AreasToCover.Count)
                {
                    if (AreasToCover[index].CoordinateList[0].X >= AreasToCover[index].CoordinateList[1].X)
                    {
                        AreasToCover.RemoveAt(index);
                        if (AreasToCover.Count == 0)
                            AreaCovered = true;
                        break;
                    }
                    index++;
                }
            }
        }


        private static string FirstCoverLines()
        {
            StringBuilder result = new StringBuilder();
            foreach (var machine in Machines.MachineList.OrderByDescending(a => a.CoverSpeed))
            {
                if (!AreaCovered)
                //result.AppendLine(AddMachineToCover(machine));
                {




                    var coverLineID = AddMachineToCover(machine);
                    var coverLine = GetCoverLineByID(coverLineID);
                    MachineObject machineRes = Machines.GetMachineByID(coverLine.MachineID);
                    AreaToCover area = AreasToCover.Count() > 0 ? GetAreaByID(coverLine.AreaToCoverID) : null;

                    decimal totalUncovered = 0;
                    foreach (var area2cover in AreasToCover)
                    {
                        totalUncovered += area2cover.Width;
                    }


                    if (area != null && area.AreaToCoverID == coverLine.AreaToCoverID)
                        result.AppendLine("CovelLineID: " + coverLineID + "\t MachineID: " + coverLine.MachineID + "\t WorkingWidth: " + machineRes.WorkingWidth + "\t AreaToCoverID: " + area.AreaToCoverID + "\t AreaToCoverUncoveredWidth: " + area.Width + "\t TotalUncoveredWidth: " + totalUncovered.ToString() + "(" + previousUncovered + " - " + (previousUncovered - totalUncovered).ToString() + ")");

                    else
                        result.AppendLine("CovelLineID: " + coverLineID + "\t MachineID: " + coverLine.MachineID + "\t WorkingWidth: " + machineRes.WorkingWidth + "\t AreaToCoverID: " + coverLine.AreaToCoverID + "\t AreaToCoverUncoveredWidth: 0" + "\t TotalUncoveredWidth: " + totalUncovered.ToString() + "(" + previousUncovered + " - " + (previousUncovered - totalUncovered).ToString() + ")");

                    previousUncovered = totalUncovered;

                }

            }

            return result.ToString();
        }








        /// <summary>
        /// Initializes and starts the process of coverring the world
        /// </summary>
        public static string StartCover()
        {
            previousUncovered = AreasToCover[0].Width;
            StringBuilder result = new StringBuilder();
            result.AppendLine(FirstCoverLines());

            while (!AreaCovered)
            {
                var coverLineID = nextCoverLine();
                var coverLine = GetCoverLineByID(coverLineID);
                MachineObject machine = Machines.GetMachineByID(coverLine.MachineID);
                AreaToCover area = AreasToCover.Count() > 0 ? GetAreaByID(coverLine.AreaToCoverID) : null;

                decimal totalUncovered = 0;
                foreach (var area2cover in AreasToCover)
                {
                    totalUncovered += area2cover.Width;
                }


                if (area != null && area.AreaToCoverID == coverLine.AreaToCoverID)
                    result.AppendLine("CovelLineID: " + coverLineID + "\t MachineID: " + coverLine.MachineID + "\t WorkingWidth: " + machine.WorkingWidth + "\t AreaToCoverID: " + area.AreaToCoverID + "\t AreaToCoverUncoveredWidth: " + area.Width + "\t TotalUncoveredWidth: " + totalUncovered.ToString() + "(" + previousUncovered + " - " + (previousUncovered - totalUncovered).ToString() + ")");

                else
                    result.AppendLine("CovelLineID: " + coverLineID + "\t MachineID: " + coverLine.MachineID + "\t WorkingWidth: " + machine.WorkingWidth + "\t AreaToCoverID: " + coverLine.AreaToCoverID + "\t AreaToCoverUncoveredWidth: 0" + "\t TotalUncoveredWidth: " + totalUncovered.ToString() + "(" + previousUncovered + " - " + (previousUncovered - totalUncovered).ToString() + ")");

                previousUncovered = totalUncovered;
            }

            result.AppendLine("NOTHING TO COVER / AREA (ALREADY) FULLY COVERED");
            return result.ToString();

        }

        private static string nextCoverLine()
        {
            Machines.MachineList.Sort((m1, m2) => DateTime.Compare(m1.EndsAt, m2.EndsAt));
            var machine = Machines.MachineList.First();
            machine.Position = GetCoverLineByID(machine.ActualCoverLineID).EndingCoordinates;
            return AddMachineToCover(Machines.MachineList.First());
        }

        internal static string AddMachineToCover(MachineObject machineObject)
        {

            if (AreasToCover != null && AreasToCover.Count > 0)
            {
                if (GoAroundAreaTimes != 0)
                {
                    //TODO:major - implement GoAround
                    throw new NotImplementedException();
                }
                else
                {
                    //TODO:major - divide machines into groups
                    if (string.IsNullOrEmpty(machineObject.ActualCoverLineID))
                        machineObject.GetFirstCoverLine();
                    else
                        machineObject.GetFirstCoverLine(World.GetAreaToCoverByCoverLineID(machineObject.ActualCoverLineID).AreaToCoverID);

                    return machineObject.StartWork();

                }

            }
            else
            {
                AreaCovered = true;
                return "NOTHING TO COVER / AREA (ALREADY) FULLY COVERED";
            }




        }

        internal static AreaToCover GetAreaByID(string areaToCoverID)
        {
            var list = AreasToCover.Where(a => a.AreaToCoverID == areaToCoverID);
            if (list.Count() > 0)
                return list.First();

            return GetAreaByID(GetFirstAreaID());

        }


        /// <summary>
        /// Get machines working on the same area
        /// </summary>
        /// <param name="coverAreaID"></param>
        /// <returns></returns>
        internal static List<string> GetMachinesToBeOnTheSameCoverArea(string coverAreaID)
        {
            //TODO:major - optimalization
            return Machines.MachineList.Select(a => a.MachineID).ToList();
        }

        internal static AreaToCover GetAreaToCoverByCoverLineID(string coverLineID)
        {
            string areaToCoverID = CoverLinesList.Where(a => a.CoverLineID == coverLineID).FirstOrDefault().AreaToCoverID;
            if (areaToCoverID != null)
            {
                var list = AreasToCover.Where(a => a.AreaToCoverID == areaToCoverID);
                if (list.Count() > 0)
                    return list.First();
            }
            //TODO:major - if null
            return GetAreaByID(GetFirstAreaID());
            //throw new NotImplementedException();
        }

        internal static bool AreaExists(string areaToCoverID)
        {
            return AreasToCover.Where(a => a.AreaToCoverID == areaToCoverID).Count() > 0;
        }

        internal static string GetFirstAreaID()
        {
            AreaToCover min = AreasToCover.First();

            foreach (var area in AreasToCover)
            {
                if (area.LeftDown.X < min.LeftDown.X)
                    min = area;
            }

            return min.AreaToCoverID;
        }
    }
}
