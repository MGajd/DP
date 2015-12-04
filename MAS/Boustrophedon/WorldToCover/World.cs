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
        public static int CoverLineIDCounter = 0;

        public static bool AreaCovered = false;
        public static bool CoverageStarted = false;

        public static Enumerations.CoverDirection CoverDirection = Enumerations.CoverDirection.leftToRight;

        public static bool GoAroundAreaToCover = false;
        public static bool GoAroundObstacles = false;

        public static int GoAroundAreaTimes = 0;
        public static decimal GoAroundAreaWidth = 0;

        public static int GoAroundObstaclesTimes = 0;
        public static decimal GoAroundObstaclesWidth = 0;




        public static List<AreaToCover> AreasToCover;
        public static List<CoveredSubArea> CoveredSubAreaList;
        public static List<CoverLine> CoverLinesList;


        public static void AddCoveredSubArea(CoveredSubArea subArea)
        {
            //TODO: critical - add subarea, find if new, or add to existing in Covered
            
        }


        public static CoverLine GetCoverLine(string coverLineID)
        {
            return CoverLinesList.Where(a => a.AreaToCoverID == coverLineID).First();
        }

        public static void AddCoverLine(CoverLine newCoverLine, decimal width)
        {
            //TODO:blocker - AddCoverLine
        }


        /// <summary>
        /// Initializes and starts the process of coverring the world
        /// </summary>
        public static string StartCover()
        {
            StringBuilder result = new StringBuilder(); 
            foreach (var machine in Machines.MachineList.OrderByDescending(a => a.CoverSpeed))
            {
                if (!AreaCovered)
                    result.AppendLine(AddMachineToCover(machine));
            }

            return result.ToString();
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
                    machineObject.GetFirstCoverLine("1");
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
            return AreasToCover.Where(a => a.AreaToCoverID == areaToCoverID).First();
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
                return (AreasToCover.Where(a => a.AreaToCoverID == areaToCoverID)).FirstOrDefault();
            else
                //TODO:major - if null
                throw new NotImplementedException();
        }

        internal static bool AreaExists(string areaToCoverID)
        {
            return AreasToCover.Where(a => a.AreaToCoverID == areaToCoverID).Count() > 0;
        }
    }
}
