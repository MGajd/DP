using Boustrophedon.AreaObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boustrophedon.Helpers
{
    public static class Methods
    {
        /// <summary>
        /// C# code snippet to determine if a point is in a polygon
        /// http://dominoc925.blogspot.sk/2012/02/c-code-snippet-to-determine-if-point-is.html
        /// 15.11.2015
        /// </summary>
        /// <param name="polygon"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public static bool IsPointInPolygon(PointF[] polygon, PointF point)
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

        public static decimal GetDistance(Coordinates point1, Coordinates point2)
        {
            decimal x = point1.X - point2.X;
            decimal y = point1.Y - point2.Y;

            var power = Math.Pow((double)x, 2) + Math.Pow((double)y, 2);

            return Convert.ToDecimal(Math.Sqrt(power));

        }

        public static double GetCoveringTimeSeconds(Coordinates a, Coordinates b, decimal speed)
        {
            return (double)(GetDistance(a, b) / speed);
        }

        internal static decimal GetMax(decimal x, decimal y)
        {
            return x > y ? x : y;
        }
        internal static decimal GetMin(decimal x, decimal y)
        {
            return x < y ? x : y;
        }

        internal static Coordinates LinearInterpolation(Coordinates coordinates1, Coordinates coordinates2, decimal x)
        {
            decimal y;
            //if (coordinates1.y > coordinates2.y)
            //{
            //    Coordinates temp = coordinates1;
            //    coordinates1 = coordinates2;
            //    coordinates2 = temp;
            //}


            if (coordinates2.Y == coordinates1.Y)
                y = coordinates2.Y;
            else
                y = ((coordinates2.Y - coordinates1.Y) / (coordinates2.X - coordinates1.X)) * (x - coordinates1.X) + coordinates1.Y;

            //if (y < 0)
            //    y *= -1;
            return new Coordinates(x, y);
        }

        internal static int GetCoordinatecIndex(List<Coordinates> coordinateList, Coordinates coordinates)
        {
            int counter = 0;
            foreach (Coordinates coor in coordinateList)
            {
                if (coor.X == coordinates.X && coor.Y == coordinates.Y)
                    return counter;
                else
                    counter++;
            }

            throw new Exception("Coordinates not found!");
        }
    }
}
