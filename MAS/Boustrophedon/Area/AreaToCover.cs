using System;
using System.Collections.Generic;
using System.Drawing;
using Boustrophedon.AreaObjects;
using Boustrophedon.WorldToCover;
using Boustrophedon.Machine;

namespace Boustrophedon.Area
{
    public class AreaToCover
    {

        public string AreaToCoverID;
        public PointF[] Area;



        public decimal MinX
        {
            get
            {
                decimal minX;
                minX = CoordinateList[0].X;
                foreach (var item in CoordinateList)
                {
                    if (item.X < minX)
                        minX = item.X;
                }
                return minX;
            }
        }

        public decimal MinY
        {
            get
            {
                decimal minY;
                minY = CoordinateList[0].Y;
                foreach (var item in CoordinateList)
                {
                    if (item.Y < minY)
                        minY = item.Y;
                }
                return minY;
            }
        }

        internal string GetLastCoverLine(Enumerations.VerticalPosition verticalPosition)
        {
            if (World.CoverDirection == Enumerations.CoverDirection.both)
                throw new NotImplementedException();

            else if ((verticalPosition == Enumerations.VerticalPosition.up && World.CoverDirection == Enumerations.CoverDirection.leftToRight)
                || (verticalPosition == Enumerations.VerticalPosition.down && World.CoverDirection == Enumerations.CoverDirection.rightToLeft))
            
               return GetLastCoverLineFromRight();
            
            else
                return GetLastCoverLineFromLeft();
        }

        private string GetLastCoverLineFromLeft()
        {
            return GetCoverLineForY(RightUp.X + 1);
        }

        private string GetLastCoverLineFromRight()
        {
            return GetCoverLineForY(RightUp.X + 1);
        }

        private string GetCoverLineForY(decimal x )
        {
            foreach (var machine in Machines.MachineList)
            {
                CoverLine coverLine = World.GetCoverLineByID(machine.ActualCoverLineID);
                if (coverLine != null)
                {
                    //ak y patri do intervalu uurceneho pracovnou sirkou
                    if (coverLine.StartingCoordinates.X + machine.WorkingWidth / 2 > x && coverLine.StartingCoordinates.X - machine.WorkingWidth / 2 < x)
                        return coverLine.CoverLineID;
                }
            }
                    return null;
        }

        public decimal MaxX
        {
            get
            {
                decimal maxX;
                maxX = CoordinateList[0].X;
                foreach (var item in CoordinateList)
                {
                    if (item.X > maxX)
                        maxX = item.X;
                }
                return maxX;
            }
        }

        public decimal MaxY
        {
            get
            {
                decimal maxY;
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

        internal void MinusWidthFromRight(decimal width)
        {
            CoordinateList[1].X -= width;
            CoordinateList[2].X -= width;
        }

        internal void MinusWidthFromLeft(decimal width)
        {
            CoordinateList[0].X += width;
            CoordinateList[3].X += width;
        }

        /// <summary>
        /// Use when area shape is rectange and starts at coordinates [0,0]
        /// </summary>
        /// <param name="coordinate">Coordinate oposite to [0,0]</param>
        public AreaToCover(Coordinates coordinate)
        {

            CoordinateList = new List<Coordinates>();

            CoordinateList.Add(new Coordinates(0, 0));
            CoordinateList.Add(new Coordinates(coordinate.X, 0));
            CoordinateList.Add(coordinate);
            CoordinateList.Add(new Coordinates(0, coordinate.Y));


            Shape = (int)Enumerations.Shape.rectangle;
        }

        /// <summary>
        /// Use when you want to make a copy of existing AreaToCover
        /// </summary>
        /// <param name="area"></param>
        public AreaToCover(AreaToCover area)
        {
            CoordinateList = new List<Coordinates>();

            foreach (var coordinate in area.CoordinateList)
            {
                CoordinateList.Add(new Coordinates(coordinate.X, coordinate.Y));
            }
            AreaToCoverID = World.AreaToCoverIDCounter++.ToString();
        }

        /// <summary>
        /// Use when the shape of area to cover is not rectangle.
        /// </summary>
        /// <param name="CoordinatesList"></param>
        public AreaToCover(List<Coordinates> coordinatesList)
        {
            this.CoordinateList = coordinatesList;
            AreaToCoverID = World.AreaToCoverIDCounter++.ToString();

            Shape = (int)Enumerations.Shape.polygon;
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
                decimal y = 0;
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
                decimal y = 0;
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
                decimal y = 0;
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
                decimal y = 0;
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

        private CoverLine GetFirstLineFromRight(decimal workingWidth, bool reverseDirection = false)
        {
             int coef = 1;
            if (reverseDirection)
                coef = 1;
            CoverLine coverLine = new CoverLine();
            coverLine.StartingCoordinates = new Coordinates(RightDown.X - (coef * workingWidth) / 2, RightDown.Y);
            coverLine.EndingCoordinates = new Coordinates(RightUp.X - (coef * workingWidth) / 2, RightUp.Y);

            coverLine.Status = Enumerations.CoverLineStatus.reserved;
            coverLine.IsDivide = false;
            coverLine.CoverLineID = World.CoverLineIDCounter++.ToString();

            if (reverseDirection)
                coverLine.ReverseCoordinates();
            return coverLine;
        }

        private CoverLine GetFirstLineFromLeft(decimal workingWidth, bool reverseDirection = false)
        {
            int coef = 1;
            if (reverseDirection)
                coef = -1;
            CoverLine coverLine = new CoverLine();
            coverLine.StartingCoordinates = new Coordinates(LeftDown.X + (coef * workingWidth) / 2, LeftDown.Y);
            coverLine.EndingCoordinates = new Coordinates(LeftUp.X + (coef * workingWidth) / 2, LeftUp.Y);

            coverLine.Status = Enumerations.CoverLineStatus.reserved;
            coverLine.IsDivide = false;
            coverLine.CoverLineID = World.CoverLineIDCounter++.ToString();

            if (reverseDirection)
                coverLine.ReverseCoordinates();
            return coverLine;
        }

        public CoverLine GetLineFromLeft(decimal width, decimal workingWidth, bool reverseDirection = false)
         {
            //int coef = 1;
            //if (reverseDirection)
            //    coef = -1;
            CoverLine coverLine = new CoverLine();
            coverLine.EndingCoordinates = new Coordinates(LeftDown.X + width - workingWidth / 2, LeftDown.Y);
            coverLine.StartingCoordinates = new Coordinates(LeftUp.X + width - workingWidth / 2, LeftUp.Y);

            coverLine.Status = Enumerations.CoverLineStatus.reserved;
            coverLine.IsDivide = false;
            coverLine.CoverLineID = World.CoverLineIDCounter++.ToString();

            if (reverseDirection)
                coverLine.ReverseCoordinates();
            return coverLine;

        }

        public CoverLine GetLineFromRight(decimal width, decimal workingWidth, bool reverseDirection = false)
        {
            int coef = 1;
            if (reverseDirection)
                coef = -1;
            CoverLine coverLine = new CoverLine();
            coverLine.StartingCoordinates = new Coordinates(RightDown.X - width -(coef * workingWidth) / 2, RightDown.Y);
            coverLine.EndingCoordinates = new Coordinates(RightUp.X - width -(coef * workingWidth) / 2, RightUp.Y);

            coverLine.Status = Enumerations.CoverLineStatus.reserved;
            coverLine.IsDivide = false;
            coverLine.CoverLineID = World.CoverLineIDCounter++.ToString();

            if (reverseDirection)
                coverLine.ReverseCoordinates();
            return coverLine;
        }

        internal void SetAsDividedLeft(CoverLine coverLine, decimal workingWidth)
        {
            CoordinateList[1] = new Coordinates(coverLine.StartingCoordinates.X - workingWidth / 2, CoordinateList[1].Y);
            CoordinateList[2] = new Coordinates(coverLine.EndingCoordinates.X - workingWidth / 2, CoordinateList[2].Y);
        }

        internal void SetAsDividedRight(CoverLine coverLine, decimal workingWidth)
        {
            CoordinateList[0] = new Coordinates(coverLine.StartingCoordinates.X + workingWidth / 2, CoordinateList[0].Y);
            CoordinateList[3] = new Coordinates(coverLine.EndingCoordinates.X + workingWidth / 2, CoordinateList[3].Y);
        }


        

    }
}
