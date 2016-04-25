using System;
using System.Collections.Generic;
using System.Drawing;
using Boustrophedon.AreaObjects;
using Boustrophedon.WorldToCover;
using Boustrophedon.Machine;
using System.Linq;

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

        public int GetSafeCoordinateListIndex(int index)
        {
            return (index + CoordinateListCount) % CoordinateListCount;
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

        private string GetCoverLineForY(decimal x)
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


        /// <summary>
        /// Edit Coordinates in CoordinatesList due to coverLine
        /// </summary>
        /// <param name="newCoverLine"></param>
        internal void AddCoverLine(CoverLine newCoverLine)
        {
            int counter = 0;
            Coordinates leftDown = null,
                        leftUp = null,
                        rightDown = null,
                        rightUp = null;

            decimal leftX = newCoverLine.X - newCoverLine.Width / 2;
            decimal rightX = newCoverLine.X + newCoverLine.Width / 2;

            while (leftDown == null)
            {
                if (CoordinateList[GetSafeCoordinateListIndex(counter)].X <= leftX && CoordinateList[GetSafeCoordinateListIndex(counter + 1)].X > leftX)
                    leftDown = CoordinateList[GetSafeCoordinateListIndex(counter)];

                counter++;
            }

            while (rightDown == null)
            {
                if (CoordinateList[GetSafeCoordinateListIndex(counter)].X >= rightX && CoordinateList[GetSafeCoordinateListIndex(counter - 1)].X < rightX)
                    rightDown = CoordinateList[GetSafeCoordinateListIndex(counter)];
                else
                    counter++;
            }

            while (rightUp == null)
            {
                if (CoordinateList[GetSafeCoordinateListIndex(counter)].X >= rightX && CoordinateList[GetSafeCoordinateListIndex(counter + 1)].X < rightX)
                    rightUp = CoordinateList[GetSafeCoordinateListIndex(counter)];

                counter++;
            }

            while (leftUp == null)
            {
                if (CoordinateList[GetSafeCoordinateListIndex(counter)].X <= leftX && CoordinateList[GetSafeCoordinateListIndex(counter - 1)].X > leftX)
                    leftUp = CoordinateList[GetSafeCoordinateListIndex(counter)];

                counter++;
            }


            //zhora dole
            if (newCoverLine.CoverLineDirection == Enumerations.CoverLineDirection.upToDown)
            {
                if (World.CoverDirection == Enumerations.CoverDirection.leftToRight)
                    DeleteCoordinatesBetween(leftDown, leftUp, newCoverLine, -1);
                else if (World.CoverDirection == Enumerations.CoverDirection.rightToLeft)
                    DeleteCoordinatesBetween(rightUp, rightDown, newCoverLine);
            }

            //zdola hore
            else if (newCoverLine.CoverLineDirection == Enumerations.CoverLineDirection.downToUp)
            {
                if (World.CoverDirection == Enumerations.CoverDirection.leftToRight)
                    DeleteCoordinatesBetween(rightUp, rightDown, newCoverLine);
                else if (World.CoverDirection == Enumerations.CoverDirection.rightToLeft)
                    DeleteCoordinatesBetween(leftDown, leftUp, newCoverLine, -1);
            }


        }

        private void DeleteCoordinatesBetween(Coordinates coorFrom, Coordinates coorTo, CoverLine newCoverLine, int coef = 1)
        {
            List<Coordinates> newCoordinates = AddNewIndexes(coorFrom, coorTo, newCoverLine, coef);
            RemoveRedundantCoordinates();

            int coorFomIndex = Helpers.Methods.GetCoordinatecIndex(CoordinateList, newCoordinates.Last());
            int coorToIndex = Helpers.Methods.GetCoordinatecIndex(CoordinateList, newCoordinates.First());

            DeleteCoordinatesBetweenIndexes(coorFomIndex, coorToIndex);
        }

        /// <summary>
        /// Removes redundant coordinates - coordinates that are duplicate
        /// </summary>
        private void RemoveRedundantCoordinates()
        {
            int oldCount = CoordinateListCount;

            for (int i = 0; i < oldCount;)
            {
                if (CoordinateList[GetSafeCoordinateListIndex(i)] == CoordinateList[GetSafeCoordinateListIndex(i - 1)])
                    CoordinateList.RemoveAt(GetSafeCoordinateListIndex(i));
                else i++;
            }
        }

        private List<Coordinates> AddNewIndexes(Coordinates coorFrom, Coordinates coorTo, CoverLine newCoverLine, int coef)
        {

            List<Coordinates> returnCoordinates = new List<Coordinates>();

            int coorToIndex = Helpers.Methods.GetCoordinatecIndex(CoordinateList, coorTo);
            returnCoordinates.Add(Helpers.Methods.LinearInterpolation(CoordinateList[GetSafeCoordinateListIndex(coorToIndex)], CoordinateList[GetSafeCoordinateListIndex(coorToIndex - 1)], newCoverLine.X + (newCoverLine.Width / 2) * coef));
            CoordinateList.Insert(coorToIndex, returnCoordinates.Last());

            int coorFromIndex = Helpers.Methods.GetCoordinatecIndex(CoordinateList, coorFrom);
            returnCoordinates.Add(Helpers.Methods.LinearInterpolation(CoordinateList[GetSafeCoordinateListIndex(coorFromIndex)], CoordinateList[GetSafeCoordinateListIndex(coorFromIndex + 1)], newCoverLine.X + (newCoverLine.Width / 2) * coef));
            CoordinateList.Insert(coorFromIndex + 1, returnCoordinates.Last());

            return returnCoordinates;
        }

        /// <summary>
        /// Deletes range between from - to indexes, excluding from and to indexes.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        private void DeleteCoordinatesBetweenIndexes(int from, int to)
        {
            if (from > to)
            {
                CoordinateList.RemoveRange(from + 1, CoordinateListCount - from - 1);
                CoordinateList.RemoveRange(0, to);
            }
            else
            {
                CoordinateList.RemoveRange(from + 1, to - from - 1);
            }
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
        private Enumerations.Shape _shape;

        internal void MinusWidthFromRight(decimal width)
        {
            //if shape is rectangle or square
            if ((int)Shape < 3)
            {
                CoordinateList[1].X -= width;
                CoordinateList[2].X -= width;
                //TODO:blocker - if shape is rectangle, change Y coordinates
            }

        }
        internal void MinusWidthFromLeft(decimal width)
        {
            //if shape is rectangle or square
            if ((int)Shape < 3)
            {
                CoordinateList[0].X += width;
                CoordinateList[3].X += width;
                //TODO:blocker - if shape is rectangle, change Y coordinates
            }



        }
        /// <summary>
        /// Use when area shape is rectange and starts at coordinates [0,0]
        /// </summary>
        /// <param name="coordinate">Coordinate oposite to [0,0]</param>
        public AreaToCover(Coordinates coordinate)
        {
            AreaToCoverID = World.AreaToCoverIDCounter++.ToString();

            CoordinateList = new List<Coordinates>();
            CoordinateList.Add(new Coordinates(0, 0));
            CoordinateList.Add(new Coordinates(coordinate.X, 0));
            CoordinateList.Add(coordinate);
            CoordinateList.Add(new Coordinates(0, coordinate.Y));

            Shape = coordinate.X == coordinate.Y ? Enumerations.Shape.square : Enumerations.Shape.rectangle;
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

            Shape = coordinatesList.Count == 3 ? Enumerations.Shape.triangle : Enumerations.Shape.polygon;
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

        public int CoordinateListCount
        {
            get
            { return CoordinateList.Count; }
        }

        public Enumerations.Shape Shape
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



        //TODO:major- implement new points gettnig, taking diversification of area shape
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

        public Coordinates RightUp
        {
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
            //TODO: can be incorrect
            int coef = 1;
            if (reverseDirection)
                coef = -1;
            CoverLine coverLine = new CoverLine();
            coverLine.StartingCoordinates = new Coordinates(MaxX + (coef * workingWidth) / 2, GetMinY(MaxX, (coef * workingWidth)));// RightDown.Y);
            coverLine.EndingCoordinates = new Coordinates(MaxX + (coef * workingWidth) / 2, GetMaxY(MaxX, (coef * workingWidth)));// RightUp.Y);

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

            //TODO:blocker - DONE? change Y-coordinates to the proper Y due to shape
            coverLine.StartingCoordinates = new Coordinates(MinX + (coef * workingWidth) / 2, GetMinY(MinX, (coef * workingWidth)));
            coverLine.EndingCoordinates = new Coordinates(MinX + (coef * workingWidth) / 2, GetMaxY(MinX, (coef * workingWidth)));// LeftUp.Y);

            coverLine.Status = Enumerations.CoverLineStatus.reserved;
            coverLine.IsDivide = false;
            coverLine.CoverLineID = World.CoverLineIDCounter++.ToString();

            if (reverseDirection)
                coverLine.ReverseCoordinates();
            return coverLine;
        }


        /// <summary>
        /// Returns min Y for values between X an X + offset
        /// </summary>
        /// <param name="x">X Coordinate</param>
        /// <param name="offset"></param>
        /// <returns></returns>
        private decimal GetMinY(decimal x, decimal offset)
        {

            List<Coordinates> extendedCoordinatesList = new List<Coordinates>();
            Coordinates[] tempArray = new Coordinates[CoordinateList.Count];
            CoordinateList.CopyTo(tempArray);
            extendedCoordinatesList = tempArray.ToList();

            Coordinates previousCoordinate = CoordinateList.First();
            for (int i = CoordinateList.Count - 1; i > 0; i++)
            {
                if (CoordinateList[i].X < previousCoordinate.X)
                {
                    extendedCoordinatesList.Insert(0, new Coordinates(CoordinateList[i].X, CoordinateList[i].Y));
                    previousCoordinate = CoordinateList[i];
                }
                else
                    break;
            }


            List<Coordinates> outerCoordinatesList = GetOuterPoints(extendedCoordinatesList, Helpers.Methods.GetMin(x, x + offset), Helpers.Methods.GetMax(x, x + offset));
            List<Coordinates> minMaxCoordinatesList = GetMinMaxCoordinates(outerCoordinatesList, x, offset);

            return minMaxCoordinatesList.OrderBy(a => a.Y).First().Y;
        }

        /// <summary>
        /// Returns max Y for values between X an X + offset
        /// </summary>
        /// <param name="x">X Coordinate</param>
        /// <param name="offset"></param>
        /// <returns></returns>
        private decimal GetMaxY(decimal x, decimal offset)
        {
            Coordinates[] tempArray = new Coordinates[CoordinateList.Count];
            List<Coordinates> reversedList = new List<Coordinates>();
            CoordinateList.CopyTo(tempArray);
            reversedList = tempArray.ToList();
            reversedList.Reverse();
            reversedList.Insert(0, new Coordinates(reversedList.Last().X, reversedList.Last().Y));

            List<Coordinates> outerCoordinatesList = GetOuterPoints(reversedList, Helpers.Methods.GetMin(x, x + offset), Helpers.Methods.GetMax(x, x + offset));
            List<Coordinates> minMaxCoordinatesList = GetMinMaxCoordinates(outerCoordinatesList, x, offset);

            return minMaxCoordinatesList.OrderBy(a => a.Y).Last().Y;
        }

        /// <summary>
        /// Returns List of coordinates that contains loccal minimums an maximums
        /// </summary>
        /// <param name="coordinatesList"></param>
        /// <param name="x"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        private List<Coordinates> GetMinMaxCoordinates(List<Coordinates> coordinatesList, decimal x, decimal offset)
        {
            Coordinates coor;
            List<Coordinates> results = new List<Coordinates>();

            for (int i = 0; i < coordinatesList.Count; i++)
            {
                coor = coordinatesList[i];
                if (coor.X < x)
                {
                    results.Add(Helpers.Methods.LinearInterpolation(coordinatesList[i], coordinatesList[i + 1], x));
                }
                else if (coor.X > x + offset)
                {
                    results.Add(Helpers.Methods.LinearInterpolation(coordinatesList[i - 1], coordinatesList[i], x + offset));
                }
                else results.Add(coor);
            }
            return results;
        }


        /// <summary>
        /// Returns list of Coordinates, that are necessary to count min or max Y
        /// </summary>
        /// <param name="coordinateList"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        private List<Coordinates> GetOuterPoints(List<Coordinates> coordinateList, decimal x1, decimal x2)
        {

            List<Coordinates> growingCoordinatesList = GetGrowingCoordinatesList(coordinateList);
            List<Coordinates> resultList = new List<Coordinates>();
            int coordinatesCount = growingCoordinatesList.Count;
            decimal from = -1, to = -1;

            for (int i = 0; i < growingCoordinatesList.Count; i++)
            {
                if (growingCoordinatesList[i].X <= x1)
                {
                    from = i;
                }

                if (to == -1 && coordinateList[i].X >= x2 && from != -1)
                {
                    to = i;
                }
            }

            from = from == -1 ? 0 : from;
            to = to == -1 ? growingCoordinatesList.Count - 1 : to;
            return growingCoordinatesList.GetRange((int)from, (int)(to - from + 1));
        }

        private List<Coordinates> GetGrowingCoordinatesList(List<Coordinates> coordinateList)
        {
            List<Coordinates> resultList = new List<Coordinates>();
            foreach (var coor in coordinateList)
            {
                if (resultList.Count == 0)
                    resultList.Add(coor);
                else
                {
                    if (resultList.Last().X <= coor.X)
                        resultList.Add(coor);
                    else
                        break;
                }
            }
            return resultList;
        }


        public CoverLine GetLineFromLeft(decimal width, decimal workingWidth, bool reverseDirection = false)
        {
            //int coef = 1;
            //if (reverseDirection)
            //    coef = -1;


            //TODO:blocker - upravit kvoli moznosti pokrytia nepravidelnej plochy
            CoverLine coverLine = new CoverLine();
            coverLine.EndingCoordinates = new Coordinates(MinX + width - workingWidth / 2, LeftDown.Y);
            coverLine.StartingCoordinates = new Coordinates(MinX + width - workingWidth / 2, LeftUp.Y);

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
            coverLine.StartingCoordinates = new Coordinates(RightDown.X - width - (coef * workingWidth) / 2, RightDown.Y);
            coverLine.EndingCoordinates = new Coordinates(RightUp.X - width - (coef * workingWidth) / 2, RightUp.Y);

            coverLine.Status = Enumerations.CoverLineStatus.reserved;
            coverLine.IsDivide = false;
            coverLine.CoverLineID = World.CoverLineIDCounter++.ToString();

            if (reverseDirection)
                coverLine.ReverseCoordinates();
            return coverLine;
        }

        internal void SetAsDividedLeft(CoverLine coverLine, decimal workingWidth)
        {
            DeleteAllBiggerOrEqualXCoordinates(coverLine.X - workingWidth / 2);

            //CoordinateList[1] = new Coordinates(coverLine.StartingCoordinates.X - workingWidth / 2, CoordinateList[1].Y);
            //CoordinateList[2] = new Coordinates(coverLine.EndingCoordinates.X - workingWidth / 2, CoordinateList[2].Y);
        }

        internal void SetAsDividedRight(CoverLine coverLine, decimal workingWidth)
        {
            DeleteAllSmallerOrEqualXCoordinates(coverLine.X + workingWidth / 2);

            //CoordinateList[0] = new Coordinates(coverLine.StartingCoordinates.X + workingWidth / 2, CoordinateList[0].Y);
            //CoordinateList[3] = new Coordinates(coverLine.EndingCoordinates.X + workingWidth / 2, CoordinateList[3].Y);
        }


        private void DeleteAllSmallerOrEqualXCoordinates(decimal xCoordinate)
        {
            int i = 0;
            bool down = false,
                 up = false;


            while (i < CoordinateListCount)
            {
                if (CoordinateList[i].X <= xCoordinate)
                {
                    if (!down && (CoordinateList[GetSafeCoordinateListIndex(i + 1)].X > xCoordinate))
                    {
                        CoordinateList[i] = Helpers.Methods.LinearInterpolation(CoordinateList[i], CoordinateList[GetSafeCoordinateListIndex(i + 1)], xCoordinate);
                        down = true;
                        i++;
                    }
                    else if (!up)
                    {
                        CoordinateList[i] = Helpers.Methods.LinearInterpolation(CoordinateList[i], CoordinateList[GetSafeCoordinateListIndex(i - 1)], xCoordinate);
                        up = true;
                        i++;
                    }
                    else
                    {
                        CoordinateList.RemoveAt(i);
                        //cant do i++ cause just deleted item
                    }
                }
                else
                {
                    i++;
                }
            }
        }

        private void DeleteAllBiggerOrEqualXCoordinates(decimal xCoordinate)
        {
            int i = 0;
            bool down = false,
                 up = false;


            while (i < CoordinateListCount)
            {
                if (CoordinateList[i].X >= xCoordinate)
                {
                    if (!down)
                    {
                        CoordinateList.Insert(i, Helpers.Methods.LinearInterpolation(CoordinateList[i], CoordinateList[GetSafeCoordinateListIndex(i - 1)], xCoordinate));
                        down = true;
                        i++;
                    }
                    else if (!up && (CoordinateList[GetSafeCoordinateListIndex(i + 1)].X < xCoordinate))
                    {
                        CoordinateList[i] = Helpers.Methods.LinearInterpolation(CoordinateList[i], CoordinateList[GetSafeCoordinateListIndex(i + 1)], xCoordinate);
                        up = true;
                        i++;
                    }
                    else
                    {
                        CoordinateList.RemoveAt(i);
                        //cant do i++ cause just deleted item
                    }
                }
                else
                {
                    i++;
                }
            }
        }
    }
}