using Boustrophedon.Area;
using Boustrophedon.AreaObjects;
using Boustrophedon.Machine;
using System.Collections.Generic;


namespace Boustrophedon.WorldToCover
{
    public class Initialization
    {
        public Initialization()
        {

            List<double> polygonAreaLatLong = new List<double>() { 17.67187122670222, 48.32100658917706, 17.67484528773948, 48.32276918841107, 17.6676882146302, 48.32648733112465, 17.66670214849421, 48.32374398467304, 17.66727282922581, 48.32347466588006, 17.66717808563941, 48.32291408299006, 17.67187122670222, 48.32100658917706,};



            MachineObject machine = new MachineObject();
            machine.CoverSpeed = 1;
            machine.Position = new Coordinates(0, 0);
            machine.TransportSpeed = (decimal)3.33;
            machine.TurningRadius = 10;
            machine.WorkingWidth = (decimal)7.4;


            machine = new MachineObject();
            machine.CoverSpeed = 1;
            machine.Position = new Coordinates(0, 0);
            machine.TransportSpeed = (decimal)3.33;
            machine.TurningRadius = 10;
            machine.WorkingWidth = (decimal)7.4;


            //Machines.AddMachineToList(machine);


            //machine = new MachineObject();
            //machine.CoverSpeed = (decimal)1.5;
            //machine.Position = new Coordinates(0, 0);
            //machine.TransportSpeed = (decimal)3.33;
            //machine.TurningRadius = 10;
            //machine.WorkingWidth = (decimal)6.6;


            //machine = new MachineObject();
            //machine.CoverSpeed = (decimal)1.8;
            //machine.Position = new Coordinates(0, 0);
            //machine.TransportSpeed = (decimal)3.33;
            //machine.TurningRadius = 10;
            //machine.WorkingWidth = (decimal)6.6;

            //Machines.AddMachineToList(machine);


            List<Coordinates> coordinatesList = new List<Coordinates>();
            //coordinatesList.Add(new Coordinates(0, 0));
            //coordinatesList.Add(new Coordinates(100, 0));
            //coordinatesList.Add(new Coordinates(50, 50));


            //Coordinates for Krizovany: 60.38657388264

            //coordinatesList.Add(new Coordinates((decimal)127.2397627,0));
            //coordinatesList.Add(new Coordinates((decimal)419.7334444,0));
            //coordinatesList.Add(new Coordinates((decimal)298.567374, (decimal)659.4758929));
            //coordinatesList.Add(new Coordinates(45, (decimal)444.2060641));
            //coordinatesList.Add(new Coordinates(40, (decimal)409.2714597));
            //coordinatesList.Add(new Coordinates(0, (decimal)375.7627803));

            //coordinatesList.Add(new Coordinates((decimal)57.24240453, (decimal)52.85539337));
            //coordinatesList.Add(new Coordinates((decimal)344.9208035,0));
            //coordinatesList.Add(new Coordinates((decimal)344.9208035, (decimal)670.5));
            //coordinatesList.Add(new Coordinates((decimal)56.62729036, (decimal)504.6097819));
            //coordinatesList.Add(new Coordinates((decimal)45.39670844, (decimal)471.1538316));
            //coordinatesList.Add(new Coordinates(0, (decimal)445.425045));



            //Horenicka Horka
            coordinatesList.Add(new Coordinates((decimal)41.9216369, 0));
            coordinatesList.Add(new Coordinates((decimal)156.9923198, (decimal)15.38859396));
            coordinatesList.Add(new Coordinates((decimal)233.0452109, (decimal)174.7612497));
            coordinatesList.Add(new Coordinates((decimal)341.6539338, (decimal)331.6318502));
            coordinatesList.Add(new Coordinates((decimal)406.1837036, (decimal)517.4414539));
            coordinatesList.Add(new Coordinates((decimal)418.1232184, (decimal)595.8130295));
            coordinatesList.Add(new Coordinates((decimal)310.1985024, (decimal)576.7681963));
            coordinatesList.Add(new Coordinates((decimal)276.7277039, (decimal)874.9837989));
            coordinatesList.Add(new Coordinates((decimal)41.9216369, (decimal)936.7125686));
            coordinatesList.Add(new Coordinates((decimal)14.81192476, (decimal)480.4148294));
            coordinatesList.Add(new Coordinates(0, (decimal)230.1323951));


            //AreaToCover area = new AreaToCover(new Coordinates(100, 100));
            AreaToCover area = new AreaToCover(coordinatesList);

            World.AreasToCover = new List<AreaToCover>();
            World.AreasToCover.Add(area);

            World.CoverLinesList = new List<CoverLine>();


        }


    }
}

