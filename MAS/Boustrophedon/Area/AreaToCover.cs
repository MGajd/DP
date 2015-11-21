using System.Collections.Generic;
using System.Drawing;

namespace Boustrophedon.Area
{
    public class AreaToCover
    {

        public string ID;
        public PointF[] Area;


        private List<AreaObjects.Coordinates> _coordinateList;
        private List<AreaObjects.Obstacle> _obstaclesList;

        private bool _allObstaclesKnown = true;
        private int _shape;

        /// <summary>
        /// Use when area shape is rectange and starts at coordinates [0,0]
        /// </summary>
        /// <param name="coordinate">Coordinate oposite to [0,0]</param>
        public AreaToCover(AreaObjects.Coordinates coordinate) {

            CoordinateList = new List<AreaObjects.Coordinates>();

            CoordinateList.Add(new AreaObjects.Coordinates(0,0));
            CoordinateList.Add(coordinate);

            Shape = (int)Enumerations.Shape.rectangle;
        }

        public bool AddObstacle(AreaObjects.Obstacle obstacle) {
            if (ObstaclesList == null)
                ObstaclesList = new List<AreaObjects.Obstacle>();

            //TODO: minor - concat obstacles
            ObstaclesList.Add(obstacle);

            return true;
        }

        public List<AreaObjects.Coordinates> CoordinateList
        {
            get
            {
                return _coordinateList;
            }

            set
            {
                _coordinateList = value;
            }
        }

        public int Shape
        {
            get
            {
                return _shape;
            }

            set
            {
                _shape = value;
            }
        }

        public List<AreaObjects.Obstacle> ObstaclesList
        {
            get
            {
                return _obstaclesList;
            }

            set
            {
                _obstaclesList = value;
            }
        }

        public bool AllObstaclesKnown
        {
            get
            {
                return _allObstaclesKnown;
            }

            set
            {
                _allObstaclesKnown = value;
            }
        }
    }
}
