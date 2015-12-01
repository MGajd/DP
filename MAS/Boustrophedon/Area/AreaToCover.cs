using System;
using System.Collections.Generic;
using System.Drawing;
using Boustrophedon.AreaObjects;
using Boustrophedon.WorldToCover;

namespace Boustrophedon.Area
{
    public class AreaToCover
    {

        public string AreaToCoverID;
        public PointF[] Area;



        public int MinX
        {
            get
            {
                int minX;
                minX = CoordinateList[0].X;
                foreach (var item in CoordinateList)
                {
                    if (item.X < minX)
                        minX = item.X;
                }
                return minX;
            }
        }

        public int MinY
        {
            get
            {
                int minY;
                minY = CoordinateList[0].Y;
                foreach (var item in CoordinateList)
                {
                    if (item.Y < minY)
                        minY = item.Y;
                }
                return minY;
            }
        }

        public int MaxX
        {
            get
            {
                int maxX;
                maxX = CoordinateList[0].X;
                foreach (var item in CoordinateList)
                {
                    if (item.X > maxX)
                        maxX = item.X;
                }
                return maxX;
            }
        }

        public int MaxY
        {
            get
            {
                int maxY;
                maxY = CoordinateList[0].Y;
                foreach (var item in CoordinateList)
                {
                    if (item.Y > maxY)
                        maxY = item.Y;
                }
                return maxY;
            }
        }


        private List<Coordinates> _coordinateList;
        private List<Obstacle> _obstaclesList;

        private bool _allObstaclesKnown = true;
        private int _shape;

        /// <summary>
        /// Use when area shape is rectange and starts at coordinates [0,0]
        /// </summary>
        /// <param name="coordinate">Coordinate oposite to [0,0]</param>
        public AreaToCover(Coordinates coordinate)
        {

            CoordinateList = new List<Coordinates>();

            CoordinateList.Add(new Coordinates(0, 0));
            CoordinateList.Add(coordinate);

            Shape = (int)Enumerations.Shape.rectangle;
        }

        public bool AddObstacle(Obstacle obstacle)
        {
            if (ObstaclesList == null)
                ObstaclesList = new List<Obstacle>();

            //TODO: minor - concat obstacles
            ObstaclesList.Add(obstacle);

            return true;
        }

        public List<Coordinates> CoordinateList
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

        public List<Obstacle> ObstaclesList
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

        public decimal Width
        {
            get { return MaxX - MinX; }
        }

        public Coordinates LeftUp
        {
            get
            {
                var x = MinX;
                int y = 0;
                bool found = false;

                foreach (var item in CoordinateList)
                {
                    if (x == item.X && (!found || y < item.Y))
                    {
                        y = item.Y;
                        found = true;
                    }
                }
                return new Coordinates(x, y);
            }
        }
        public Coordinates LeftDown
        {
            get
            {
                var x = MinX;
                int y = 0;
                bool found = false;

                foreach (var item in CoordinateList)
                {
                    if (x == item.X && (!found || y > item.Y))
                    {
                        y = item.Y;
                        found = true;
                    }
                }
                return new Coordinates(x, y);
            }
        }
        public Coordinates RightDown
        {
            get
            {
                var x = MaxX;
                int y = 0;
                bool found = false;

                foreach (var item in CoordinateList)
                {
                    if (x == item.X && (!found || y > item.Y))
                    {
                        y = item.Y;
                        found = true;
                    }
                }
                return new Coordinates(x, y);
            }
        }

        public Coordinates RightUp {
            get
            {
                var x = MaxX;
                int y = 0;
                bool found = false;

                foreach (var item in CoordinateList)
                {
                    if (x == item.X && (!found || y < item.Y))
                    {
                        y = item.Y;
                        found = true;
                    }
                }
                return new Coordinates(x, y);
            }
        }


        /// <summary>
        /// Returns bolean value whether the machines working on this area need help.
        /// </summary>
        /// <returns></returns>
        internal bool IsHelpNeeded()
        {
            //TODO:critical - implement the decision if other machine is needed

            return true;
        }


        /// <summary>
        /// Returns bolean value whether the machine is compatible to help machines working on this area.
        /// </summary>
        /// <param name="machineID">ID of machine to be added</param>
        /// <returns></returns>
        internal bool CanBeMachineAdded(string machineID)
        {
            //TODO:major - optimalization, whether the adition of the machine will not cause worse results
            return true;
        }

        internal CoverLine GetCoverLine(Enumerations.VerticalPosition machineVerticalPosition, decimal workingWidth)
        {
            if (machineVerticalPosition == Enumerations.VerticalPosition.down && World.CoverDirection == Enumerations.CoverDirection.leftToRight)
                return GetFirstLineFromLeft(workingWidth);
            else if (machineVerticalPosition == Enumerations.VerticalPosition.down && World.CoverDirection == Enumerations.CoverDirection.rightToLeft)
                return GetFirstLineFromRight(workingWidth);
            else if (machineVerticalPosition == Enumerations.VerticalPosition.up && World.CoverDirection == Enumerations.CoverDirection.leftToRight)
                return GetFirstLineFromRight(workingWidth, true);
            else if (machineVerticalPosition == Enumerations.VerticalPosition.up && World.CoverDirection == Enumerations.CoverDirection.rightToLeft)
                return GetFirstLineFromLeft(workingWidth, true);

            else // TODO:major - if Enumerations.CoverDirection.both
                throw new NotImplementedException();
        }

        private CoverLine GetFirstLineFromRight(decimal width, bool reverseDirection = false)
        {
            CoverLine coverLine = new CoverLine();
            coverLine.StartingCoordinates = new Coordinates(RightDown.X - width / 2, RightDown.Y);
            coverLine.EndingCoordinates = new Coordinates(RightUp.X - width / 2, RightUp.Y);

            coverLine.Status = Enumerations.CoverLineStatus.reserved;
            coverLine.IsDivide = false;
            coverLine.CoverLineID = World.CoverLineIDCounter++.ToString();

            if (reverseDirection)
                coverLine.ReverseCoordinates();
            return coverLine;
        }

        private CoverLine GetFirstLineFromLeft(decimal width, bool reverseDirection = false)
        {
            CoverLine coverLine = new CoverLine();
            coverLine.StartingCoordinates = new Coordinates(LeftDown.X + width / 2, LeftDown.Y);
            coverLine.EndingCoordinates = new Coordinates(LeftUp.X + width / 2, LeftUp.Y);

            coverLine.Status = Enumerations.CoverLineStatus.reserved;
            coverLine.IsDivide = false;
            coverLine.CoverLineID = World.CoverLineIDCounter++.ToString();

            if (reverseDirection)
                coverLine.ReverseCoordinates();
            return coverLine;
        }
    }
}
