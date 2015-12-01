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




        public static List<AreaToCover> AreaToCover;
        public static List<CoveredSubArea> CoveredSubAreaList;
        public static List<CoverLine> CoverLinesList;

        public static void AddCoveredSubArea(CoveredSubArea subArea)
        {
            //TODO: critical - add subarea, find if new, or add to existing in Covered
            
        }


        public static CoverLine GetLine(string ID)
        {
            return CoverLinesList.Where(a => a.AreaToCoverID == ID).First();
        }

        public static void AddCoverLine(CoverLine newCoverLine, decimal width)
        {

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


            if (AreaToCover != null && AreaToCover.Count > 0)
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
            return AreaToCover.Where(a => a.AreaToCoverID == areaToCoverID).First();
        }
    }
}
