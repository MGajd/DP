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
    }
}
