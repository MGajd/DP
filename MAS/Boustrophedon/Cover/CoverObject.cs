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
    class CoverObject
    {
        private Coordinates _machinePosition;
        private AreaToCover _coverArea;
        private MachineObject _machine;
        private Coordinates _direction;


        public CoverObject() { }

        public CoverObject(AreaToCover coverArea, MachineObject machine, Coordinates machinePosition, Coordinates direction)
        {
            CoverArea = coverArea;
            Machine = machine;
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

        public MachineObject Machine
        {
            get
            {
                return _machine;
            }

            set
            {
                _machine = value;
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
