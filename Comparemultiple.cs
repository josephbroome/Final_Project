using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    public class Comparemultiple : RestaurantLogger, ITrackable

    {
        static readonly RestaurantLogger logger = new RestaurantLogger();
        const string McDonaldsCSVPath = "McDonalds-US-AL.csv";
        const string WendysCSVPath = "Wendys-US-AL.csv";
        const string BurgerKingCSVPath = "BurgerKing-US-AL.csv";
        const string TacoBellCSVPath = "TacoBell-US-AL.csv";

        public string Name { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public string Phonenumber { get; set; }
        public Point Location { get; set; }
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");
            if (line == null)
                return null;
            if (line.Length == 0)
                return null;
            if (line.Length < 3)
                return null;

            var cells = line.Split(',');

            if (cells.Length < 3)
            {
                return null;
            }
            var longitude = double.Parse(cells[0]);

            var latitude = double.Parse(cells[1]);

            var name = cells[2];
            var state = cells[3];
            var address = cells[4];
            var phonenumber = cells[5];





            var point = new Point();
            point.Latitude = latitude;
            point.Longitude = longitude;

            var mcDonalds = new McDonalds()
            {
                Name = name,
                Location = point,
                State = state,
                Address = address,
                Phonenumber = phonenumber,


            };

            logger.LogInfo($"Finished parsing location {mcDonalds.Name}");

            return mcDonalds;

            var point1 = new Point();

            point1.Latitude = latitude;
            point1.Longitude = longitude;

            var wendys = new Wendys()
            {
                Name = name,
                Location = point1,
                State = state,
                Address = address,
                Phonenumber = phonenumber,
            };



        }
        public void McdonaldsandWendys()
        {
            logger.LogInfo("Log initialized");



            var lines = File.ReadAllLines(McDonaldsCSVPath);
            var line = File.ReadLines(WendysCSVPath);

            logger.LogInfo($"Lines: {lines[0]}");
            logger.LogInfo($"Lines: {lines[0]}");


            var mcdonaldsparser = new McDonalds();
            var wendysparser = new Wendys();


            var locations = lines.Select(mcdonaldsparser.Parse).ToArray();
            var locations2 = line.Select(wendysparser.Parse).ToArray();


            ITrackable mcDonalds = null;
            ITrackable wendys = null;
            const double MetersToMiles = 0.000621371;

            double distance = 0;
            for (int i = 0; i < locations.Length - 1; i++)
            {
                var locationA = locations[i];
                var coordinateA = new GeoCoordinates
                {
                    Latitude = locationA.Location.Latitude,
                    Longitude = locationA.Location.Longitude,
                };
                for (int j = 0; j < locations2.Length - 1; j++)
                {
                    var locationB = locations2[j];
                    var coordinateB = new GeoCoordinates();

                    coordinateB.Latitude = locationB.Location.Latitude;
                    coordinateB.Longitude = locationB.Location.Longitude;


                    if (coordinateA.GetDistanceTo(coordinateB) > distance)
                    {
                        distance = coordinateA.GetDistanceTo(coordinateB);
                        mcDonalds = locationA;
                        wendys = locationB;
                    }
                }
            }
            logger.LogInfo($"{mcDonalds.Name},{mcDonalds.State},{mcDonalds.Address},{mcDonalds.Phonenumber} and {wendys.Name},{wendys.State}, {wendys.Address}, {wendys.Phonenumber} are the farthest apart from eachother and are {Convert.ToUInt32(distance) * MetersToMiles} miles apart");





        }

        public void McdonaldsandBugerKing()
        {
            logger.LogInfo("Log initialized");



            var lines = File.ReadAllLines(McDonaldsCSVPath);
            var line = File.ReadLines(BurgerKingCSVPath);

            logger.LogInfo($"Lines: {lines[0]}");
            logger.LogInfo($"Lines: {lines[0]}");


            var mcdonaldsparser = new McDonalds();
            var burgerkingparser = new BurgerKing();


            var locations = lines.Select(mcdonaldsparser.Parse).ToArray();
            var locations2 = line.Select(burgerkingparser.Parse).ToArray();


            ITrackable mcDonalds = null;
            ITrackable burgerking = null;
            const double MetersToMiles = 0.000621371;

            double distance = 0;
            for (int i = 0; i < locations.Length - 1; i++)
            {
                var locationA = locations[i];
                var coordinateA = new GeoCoordinates
                {
                    Latitude = locationA.Location.Latitude,
                    Longitude = locationA.Location.Longitude,
                };
                for (int j = 0; j < locations2.Length - 1; j++)
                {
                    var locationB = locations2[j];
                    var coordinateB = new GeoCoordinates();

                    coordinateB.Latitude = locationB.Location.Latitude;
                    coordinateB.Longitude = locationB.Location.Longitude;


                    if (coordinateA.GetDistanceTo(coordinateB) > distance)
                    {
                        distance = coordinateA.GetDistanceTo(coordinateB);
                        mcDonalds = locationA;
                        burgerking = locationB;
                    }
                }
            }
            logger.LogInfo($"{mcDonalds.Name},{mcDonalds.State},{mcDonalds.Address},{mcDonalds.Phonenumber} and {burgerking.Name},{burgerking.State}, {burgerking.Address}, {burgerking.Phonenumber} are the farthest apart from eachother and are {Convert.ToUInt32(distance) * MetersToMiles} miles apart");



        }
    
       public void McdonaldsandTacoBell()
        {

            logger.LogInfo("Log initialized");



            var lines = File.ReadAllLines(McDonaldsCSVPath);
            var line = File.ReadLines(TacoBellCSVPath);

            logger.LogInfo($"Lines: {lines[0]}");
            logger.LogInfo($"Lines: {lines[0]}");


            var mcdonaldsparser = new McDonalds();
            var tacobellparser = new Tacobell();


            var locations = lines.Select(mcdonaldsparser.Parse).ToArray();
            var locations2 = line.Select(tacobellparser.Parse).ToArray();


            ITrackable mcDonalds = null;
            ITrackable tacoBell = null;
            const double MetersToMiles = 0.000621371;

            double distance = 0;
            for (int i = 0; i < locations.Length - 1; i++)
            {
                var locationA = locations[i];
                var coordinateA = new GeoCoordinates
                {
                    Latitude = locationA.Location.Latitude,
                    Longitude = locationA.Location.Longitude,
                };
                for (int j = 0; j < locations2.Length - 1; j++)
                {
                    var locationB = locations2[j];
                    var coordinateB = new GeoCoordinates();

                    coordinateB.Latitude = locationB.Location.Latitude;
                    coordinateB.Longitude = locationB.Location.Longitude;


                    if (coordinateA.GetDistanceTo(coordinateB) > distance)
                    {
                        distance = coordinateA.GetDistanceTo(coordinateB);
                        mcDonalds = locationA;
                        tacoBell = locationB;
                    }
                }
            }
            logger.LogInfo($"{mcDonalds.Name},{mcDonalds.State},{mcDonalds.Address},{mcDonalds.Phonenumber} and {tacoBell.Name},{tacoBell.State}, {tacoBell.Address}, {tacoBell.Phonenumber} are the farthest apart from eachother and are {Convert.ToUInt32(distance) * MetersToMiles} miles apart");






        }




    }
}
