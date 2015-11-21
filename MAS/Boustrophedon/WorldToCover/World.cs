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

        public static bool AreaCovered = false;
        public static bool CoverageStarted = false;

        public static int CoverDirection = (int)Enumerations.CoverDirection.both;

        public static bool GoAroundAreaToCover = false;
        public static bool GoAroundObstacles = false;

        public static int GoAroundAreaTimes = 0;
        public static decimal GoAroundAreaWidth = 0;

        public static int GoAroundObstaclesWidth = 0;
        public static decimal GoAroundObstaclesWidth = 0;




        public static List<AreaToCover> AreaToCover;
        public static List<CoveredSubArea> CoveredSubAreaList;
        public static List<CoverLine> CoverLinesList;

        public static void AddCoveredSubArea(CoveredSubArea subArea)
        {
            //TODO: critical - add subarea, find if new, or add to existing in Covered
            
        }



        /// <summary>
        /// C# code snippet to determine if a point is in a polygon
        /// http://dominoc925.blogspot.sk/2012/02/c-code-snippet-to-determine-if-point-is.html
        /// 15.11.2015
        /// </summary>
        /// <param name="polygon"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        private static bool IsPointInPolygon(PointF[] polygon, PointF point)
        {
            bool isInside = false;
            for (int i = 0, j = polygon.Length - 1; i < polygon.Length; j = i++)
            {
                if (((polygon[i].Y > point.Y) != (polygon[j].Y > point.Y)) &&
                (point.X < (polygon[j].X - polygon[i].X) * (point.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) + polygon[i].X))
                {
                    isInside = !isInside;
                }
            }
            return isInside;
        }


        public static CoverLine GetLine(string ID)
        {
            return CoverLinesList.Where(a => a.AreaToCoverID == ID).First();
        }


        /// <summary>
        /// Initializes and starts the process of coverring the world
        /// </summary>
        public static string StartCover()
        {
            StringBuilder result = new StringBuilder(); 
            foreach (var machine in Machines.MachineList)
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

                    machineObject.GetNewCoverLine();

            }
            else
            {
                AreaCovered = true;
                return "NOTHING TO COVER / AREA FULLY COVERED";
            }
                

            

        }
    }
}
