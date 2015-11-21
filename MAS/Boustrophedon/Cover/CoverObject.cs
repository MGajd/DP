using Boustrophedon.Area;
using Boustrophedon.AreaObjects;
using Boustrophedon.Machine;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Boustrophedon.Cover
{
    public partial class CoverObject
    {
        private Coordinates _machinePosition;
        private AreaToCover _coverArea;
        private MachineObject _machineObject;
        private Coordinates _direction;


        private CoverLine _oldCoverLine;
        private CoverLine _newCoverLine;


        public CoverObject() { }

        public CoverObject(AreaToCover coverArea, MachineObject machine, Coordinates machinePosition, Coordinates direction)
        {
            CoverArea = coverArea;
            MachineObject = machine;
            MachinePosition = machinePosition;
            Direction = direction;
        }

        public Coordinates MachinePosition
        {
            get
            {
                return _machinePosition;
            }

            set
            {
                _machinePosition = value;
            }
        }

        internal AreaToCover CoverArea
        {
            get
            {
                return _coverArea;
            }

            set
            {
                _coverArea = value;
            }
        }

        public MachineObject MachineObject
        {
            get
            {
                return _machineObject;
            }

            set
            {
                _machineObject = value;
            }
        }

        public Coordinates Direction
        {
            get
            {
                return _direction;
            }

            set
            {
                _direction = value;
            }
        }

       

    }
}
