using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boustrophedon
{
    class Enumerations
    {
        public enum Shape
        {
            square = 1,
            rectangle  = 2,
            triangle = 3,
            
            polygon = 10
            
        }

        public enum CoverLineStatus
        {
            coverred = 1,
            covering = 2,
            reserved = 3,
                       
        }

        /// <summary>
        /// Machine can have orefered/restricted direction
        /// </summary>
        public enum CoverDirection
        {
            leftToRight = 1,
            rightToLeft = -1,
            both = 3
            
        }

        public enum CoverLineDirection {
            upToDown = 1,
            downToUp=2
        }
    }
}
