using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoCoordinatePortable;

namespace Final_Project
{
    public class Tacobell : RestaurantLogger, ITrackable
    {
       
        static readonly RestaurantLogger logger = new RestaurantLogger();
        const string csvPath = "TacoBell-US-AL.csv";
        public string Name { get; set; }
        public Point Location { get; set; }
        public string State { get ; set ; }
        public string Address { get ; set ; }
        public string Phonenumber { get; set ; }

        public Tacobell(string name, Point location)
        {
            Name = name;
            Location = location;
        }

        public Tacobell()
        {
        }

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
            var latitude = double.Parse(cells[0]);

            var longitude = double.Parse(cells[1]);

            var name = cells[2];

            var point = new Point();
            point.Latitude = latitude;
            point.Longitude = longitude;

            var tacoBell = new Tacobell()
            {
                Name = name,
                Location = point,

            };

            logger.LogInfo($"Finished parsing location {tacoBell.Name}");

            return tacoBell;










        }
        public void FindFarthestAppart()
        {
            logger.LogInfo("Log initialized");

            

            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");


            var tacoparser = new Tacobell();


            var locations = lines.Select(tacoparser.Parse).ToArray();


            ITrackable tacoBellA = null;
            ITrackable tacoBellB = null;
            const double MetersToMiles = 0.000621371;

            double distance = 0;
            for (int i = 0; i < locations.Length; i++)
            {
                var locationA = locations[i];
                var coordinateA = new GeoCoordinate
                {
                    Latitude = locationA.Location.Latitude,
                    Longitude = locationA.Location.Longitude,
                };
                for (int j = 0; j < locations.Length; j++)
                {
                    var locationB = locations[j];
                    var coordinateB = new GeoCoordinate();

                    coordinateB.Latitude = locationB.Location.Latitude;
                    coordinateB.Longitude = locationB.Location.Longitude;


                    if (coordinateA.GetDistanceTo(coordinateB) > distance)
                    {
                        distance = coordinateA.GetDistanceTo(coordinateB);
                        tacoBellA = locationA;
                        tacoBellB = locationB;
                    }
                }
            }
            logger.LogInfo($"{tacoBellA.Name} and {tacoBellB.Name} are the farthest apart from eachother and are {Convert.ToUInt32(distance) * MetersToMiles} miles apart");
        }
    }
}
