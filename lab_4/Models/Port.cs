using Microsoft.Extensions.Hosting;

namespace lab_4.Models
{
    interface IPort
    {
        void incomingShip(Ship s);
        void outgoingShip(Ship s);
    }
    public class Port : IPort
    {
        public int ID { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public List<Container> containers { get; set; }
        public List<Ship> history { get; set; }
        public List<Ship> current { get; set; }

        public Port(double latitude, double longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
            this.containers = new List<Container>();
            this.history = new List<Ship>();
            this.current = new List<Ship>();
        }

        public void incomingShip(Ship s)
        {
            current.Add(s);
        }

        public void outgoingShip(Ship s)
        {
            current.Remove(s);
            foreach (Ship el in history)
            {
                if (el.ID == s.ID)
                {
                    return;
                }
            }
            history.Add(s);
        }
        public double getDistance(Port other)
        {
            double rlat1 = Math.PI * this.latitude / 180;
            double rlat2 = Math.PI * other.latitude / 180;
            double theta = this.longitude - other.longitude;
            double rtheta = Math.PI * theta / 180;
            double dist = Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) * Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;
            return dist * 1.609344;
        }
    }
}
