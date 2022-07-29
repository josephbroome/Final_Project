using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Final_Project
{
    public class GeoCoordinates
    {
        public static readonly GeoCoordinates Unknown = new GeoCoordinates();

        private double _course;

        private double _horizontalAccuracy;

        private double _latitude;

        private double _longitude;

        private double _speed;

        private double _verticalAccuracy;

        public  double Latitude
        {
            get
            {
                return _latitude;
            }
            set
            {
                if (value > 90.0 || value < -90.0)
                {
                    throw new ArgumentOutOfRangeException("Latitude", "Argument must be in range of -90 to 90");
                }

                _latitude = value;
            }
        }

        public double Longitude
        {
            get
            {
                return _longitude;
            }
            set
            {
                if (value > 180.0 || value < -180.0)
                {
                    throw new ArgumentOutOfRangeException("Longitude", "Argument must be in range of -180 to 180");
                }

                _longitude = value;
            }
        }

        public double HorizontalAccuracy
        {
            get
            {
                return _horizontalAccuracy;
            }
            set
            {
                if (value < 0.0)
                {
                    throw new ArgumentOutOfRangeException("HorizontalAccuracy", "Argument must be non negative");
                }

                _horizontalAccuracy = ((value == 0.0) ? double.NaN : value);
            }
        }

        public double VerticalAccuracy
        {
            get
            {
                return _verticalAccuracy;
            }
            set
            {
                if (value < 0.0)
                {
                    throw new ArgumentOutOfRangeException("VerticalAccuracy", "Argument must be non negative");
                }

                _verticalAccuracy = ((value == 0.0) ? double.NaN : value);
            }
        }

        public double Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                if (value < 0.0)
                {
                    throw new ArgumentOutOfRangeException("speed", "Argument must be non negative");
                }

                _speed = value;
            }
        }

        public double Course
        {
            get
            {
                return _course;
            }
            set
            {
                if (value < 0.0 || value > 360.0)
                {
                    throw new ArgumentOutOfRangeException("course", "Argument must be in range 0 to 360");
                }

                _course = value;
            }
        }

        public bool IsUnknown => Equals(Unknown);

        public double Altitude { get; set; }

        public GeoCoordinates()
            : this(double.NaN, double.NaN)
        {
        }

        public GeoCoordinates(double latitude, double longitude)
            : this(latitude, longitude, double.NaN)
        {
        }

        public GeoCoordinates(double latitude, double longitude, double altitude)
            : this(latitude, longitude, altitude, double.NaN, double.NaN, double.NaN, double.NaN)
        {
        }

        public GeoCoordinates(double latitude, double longitude, double altitude, double horizontalAccuracy, double verticalAccuracy, double speed, double course)
        {
            Latitude = latitude;
            Longitude = longitude;
            Altitude = altitude;
            HorizontalAccuracy = horizontalAccuracy;
            VerticalAccuracy = verticalAccuracy;
            Speed = speed;
            Course = course;
        }

        public bool Equals(GeoCoordinates other)
        {
            if ((object)other == null)
            {
                return false;
            }

            if (!Latitude.Equals(other.Latitude))
            {
                return false;
            }

            return Longitude.Equals(other.Longitude);
        }

        public static bool operator ==(GeoCoordinates left, GeoCoordinates right)
        {
            return left?.Equals(right) ?? ((object)right == null);
        }

        public static bool operator !=(GeoCoordinates left, GeoCoordinates right)
        {
            return !(left == right);
        }

        public double GetDistanceTo(GeoCoordinates other)
        {
            if (double.IsNaN(Latitude) || double.IsNaN(Longitude) || double.IsNaN(other.Latitude) || double.IsNaN(other.Longitude))
            {
                throw new ArgumentException("Argument latitude or longitude is not a number");
            }

            double num = Latitude * (Math.PI / 180.0);
            double num2 = Longitude * (Math.PI / 180.0);
            double num3 = other.Latitude * (Math.PI / 180.0);
            double num4 = other.Longitude * (Math.PI / 180.0) - num2;
            double num5 = Math.Pow(Math.Sin((num3 - num) / 2.0), 2.0) + Math.Cos(num) * Math.Cos(num3) * Math.Pow(Math.Sin(num4 / 2.0), 2.0);
            return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(num5), Math.Sqrt(1.0 - num5)));
        }

        public override int GetHashCode()
        {
            return Latitude.GetHashCode() ^ Longitude.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as GeoCoordinates);
        }

        public override string ToString()
        {
            if (this == Unknown)
            {
                return "Unknown";
            }

            return string.Format("{0}, {1}", Latitude.ToString("G", CultureInfo.InvariantCulture), Longitude.ToString("G", CultureInfo.InvariantCulture));
        }
    }
}
