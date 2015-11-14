using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boustrophedon.AreaObjects
{
    public class Coordinates
    {

        private int _x;
        private int _y;

        private Point _point;


        /// <summary>
        /// Creates a nev point onf the Area
        /// </summary>
        /// <param name="x">coordinate x</param>
        /// <param name="y">coordinate y</param>
        public Coordinates(int x, int y){
            X = x;
            Y = y;

            Point = new Point(x, y);
        }

        public int X
        {
            get
            {
                return _x;
            }

            set
            {
                _x = value;
            }
        }

        public int Y
        {
            get
            {
                return _y;
            }

            set
            {
                _y = value;
            }
        }

        public Point Point
        {
            get
            {
                return _point;
            }

            set
            {
                _point = value;
            }
        }
    }



    public class Obstacle {

        private List<Coordinates> _obstacleCoordinatesList;


        /// <summary>
        /// Define rectangular obstacle coordinates.
        /// </summary>
        /// <param name="coordinates1"></param>
        /// <param name="coordinates2"></param>
        public Obstacle(Coordinates coordinates1, Coordinates coordinates2) {

            ObstacleCoordinatesList = new List<Coordinates>();

            ObstacleCoordinatesList.Add(coordinates1);
            ObstacleCoordinatesList.Add(coordinates2);

        }

        public List<Coordinates> ObstacleCoordinatesList
        {
            get
            {
                return _obstacleCoordinatesList;
            }

            set
            {
                _obstacleCoordinatesList = value;
            }
        }


    }

}
