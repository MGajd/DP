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

        private decimal _x;
        private decimal _y;

        private PointF _point;


        /// <summary>
        /// Creates a new point on the Area
        /// </summary>
        /// <param name="x">coordinate x</param>
        /// <param name="y">coordinate y</param>
        public Coordinates(int x, int y){
            X = x;
            Y = y;

            Point = new PointF(x, y);
        }

        public Coordinates(decimal x, decimal y)
        {
            X = x;
            Y = y;

            Point = new PointF((int)x, (int)y);
        }

        public decimal X
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

        public decimal Y
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

        public PointF Point
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
        private int _shape;

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
    }

    public class CoveredSubArea {

        //TODO: critical - implement constructors

        /// <summary>
        /// Use when straight width is covered.
        /// </summary>
        /// <param name="start">Starting coordinates (middle of the machine)</param>
        /// <param name="end">Ending coordniates (middle of the machine)</param>
        /// <param name="width">Width of covered strip</param>
        public CoveredSubArea(Coordinates start, Coordinates end, decimal width)
        {
            
        }

        public CoveredSubArea(Coordinates cord1, Coordinates cord2) {

        }

        public CoveredSubArea(string coverLineID)
        {

        }

        public CoveredSubArea(CoverLine coverLineObject)
        {

        }

    }

    public class CoverLine {

        public bool IsDivide = false;
        public Coordinates StartingCoordinates;
        public Coordinates EndingCoordinates;
        public Enumerations.CoverLinePosition CoverLinePosition;

        public string CoverLineID;
        public string MachineID;
        public string AreaToCoverID;

        public Enumerations.CoverLineStatus Status;

        public Enumerations.CoverLineDirection CoverLineDirection
        {
            get
            {
                if (StartingCoordinates.X > EndingCoordinates.X)
                    return Enumerations.CoverLineDirection.upToDown;
                else
                    return Enumerations.CoverLineDirection.downToUp;
            }

        }
        public CoverLine() { }

        /// <summary>
        /// Creates new line by copying system info of old CoverLine. Use when adding the same value to both coordinates.
        /// </summary>
        /// <param name="_oldCoverLine">CovwrLine to create new one.</param>
        /// <param name="xCoordinateAdd">Add value to x coordinate.</param>
        /// <param name="yCoordinateAdd">Add value to y coordinate.</param>
        public CoverLine(CoverLine _oldCoverLine, int xCoordinateAdd, int yCoordinateAdd,bool isDivide = false, string areaToCoverID = null)
        {
            StartingCoordinates = new Coordinates(_oldCoverLine.EndingCoordinates.X + xCoordinateAdd, _oldCoverLine.EndingCoordinates.Y + yCoordinateAdd);
            EndingCoordinates = new Coordinates(_oldCoverLine.StartingCoordinates.X + xCoordinateAdd, _oldCoverLine.StartingCoordinates.Y + yCoordinateAdd);

            this.IsDivide = isDivide;
            this.AreaToCoverID = areaToCoverID ?? _oldCoverLine.AreaToCoverID;
            this.MachineID = _oldCoverLine.MachineID;
            this.Status = Enumerations.CoverLineStatus.reserved;


        }

        internal void ReverseCoordinates()
        {
            Coordinates tempCoordinates = StartingCoordinates;
            StartingCoordinates = EndingCoordinates;
            EndingCoordinates = tempCoordinates;
        }

        internal double GetCoveringTimeSeconds(decimal speed)
        {
            return (double)(Helpers.Methods.GetDistance(StartingCoordinates, EndingCoordinates)/ speed);
        }
    }

}
