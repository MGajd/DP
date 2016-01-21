using Boustrophedon.Area;
using Boustrophedon.AreaObjects;
using Boustrophedon.Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boustrophedon.WorldToCover
{
    public class Initialization
    {
        public Initialization()
        {
            MachineObject machine = new MachineObject();
            machine.CoverSpeed = (decimal)1;
            machine.Position = new Coordinates(0, 0);
            machine.TransportSpeed = (decimal)3.33;
            machine.TurningRadius = (decimal)10;
            machine.WorkingWidth = (decimal)7.5;

            //Machines.AddMachineToList(machine);


            machine = new MachineObject();
            machine.CoverSpeed = (decimal)1.5;
            machine.Position = new Coordinates(0, 0);
            machine.TransportSpeed = (decimal)3.33;
            machine.TurningRadius = (decimal)10;
            machine.WorkingWidth = (decimal)6.6;


            machine = new MachineObject();
            machine.CoverSpeed = (decimal)1.8;
            machine.Position = new Coordinates(0, 0);
            machine.TransportSpeed = (decimal)3.33;
            machine.TurningRadius = (decimal)10;
            machine.WorkingWidth = (decimal)6.6;

            //Machines.AddMachineToList(machine);


            AreaToCover area = new AreaToCover(new Coordinates(100, 100));
            area.AreaToCoverID = World.AreaToCoverIDCounter++.ToString() ;

            World.AreasToCover = new List<AreaToCover>();
            World.AreasToCover.Add(area);

            World.CoverLinesList = new List<CoverLine>();


        }


    }
}

