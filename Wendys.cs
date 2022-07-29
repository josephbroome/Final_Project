using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    public class Wendys : RestaurantLogger, ITrackable
    {
        static readonly RestaurantLogger logger = new RestaurantLogger();
        const string csvPath = "Wendys-US-AL.csv";
        public string Name { get; set; }
        public Point Location { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public string Phonenumber { get; set; }

        public Wendys(string name, Point location)
        {
            Name = name;
            Location = location;
        }

        public Wendys()
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
            var longitude = double.Parse(cells[0]);

            var latitude = double.Parse(cells[1]);

            var name = cells[2];
            var state = cells[3];
            var address = cells[4];
            var phonenumber = cells[5];





            var point = new Point();
            point.Latitude = latitude;
            point.Longitude = longitude;

            var wendys = new Wendys()
            {
                Name = name,
                Location = point,
                State = state,
                Address = address,
                Phonenumber = phonenumber,


            };

            logger.LogInfo($"Finished parsing location {wendys.Name}");

            return wendys;
        }

        public void FindFarthestAppart()
        {
            logger.LogInfo("Log initialized");



            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");


            var wendysparser = new Wendys();


            var locations = lines.Select(wendysparser.Parse).ToArray();


            ITrackable wendysA = null;
            ITrackable wendysB = null;
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
                for (int j = 0; j < locations.Length - 1; j++)
                {
                    var locationB = locations[j];
                    var coordinateB = new GeoCoordinates();

                    coordinateB.Latitude = locationB.Location.Latitude;
                    coordinateB.Longitude = locationB.Location.Longitude;


                    if (coordinateA.GetDistanceTo(coordinateB) > distance)
                    {
                        distance = coordinateA.GetDistanceTo(coordinateB);
                        wendysA = locationA;
                        wendysB = locationB;
                    }
                }
            }
            logger.LogInfo($"{wendysA.Name},{wendysA.State},{wendysA.Address},{wendysA.Phonenumber} and {wendysB.Name},{wendysB.State}, {wendysB.Address}, {wendysB.Phonenumber} are the farthest apart from eachother and are {Convert.ToUInt32(distance) * MetersToMiles} miles apart");






        }
    }
}
