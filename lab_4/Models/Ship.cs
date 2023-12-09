namespace lab_4.Models
{
    public interface IShip
    {
        bool sailTo(Port p);
        void reFuel(double newFuel);
        bool load(Container count);
        bool unLoad(Container count);
    }
    public class Ship : IShip
    {
        public int ID { get; set; }
        public double fuel { get; set; }
        public Port currentPort { get; set; }
        public int totalWeightCapacity { get; set; }
        public int maxNumberOfAllContainers { get; set; }
        public int maxNumberOfHeavyContainers { get; set; }
        public int maxNumberOfRefrigeratedContainers { get; set; }
        public int maxNumberOfLiquidContainers { get; set; }
        public double fuelConsumptionPerKM { get; set; }

        public Ship() { }

        public Ship(double fuel, Port currentPort, int totalWeightCapacity, int maxNumberOfAllContainers,
                    int maxNumberOfHeavyContainers, int maxNumberOfRefrigeratedContainers, int maxNumberOfLiquidContainers,
                    double fuelConsumptionPerKM)
        {
            this.fuel = fuel;
            this.currentPort = currentPort;
            this.totalWeightCapacity = totalWeightCapacity;
            this.maxNumberOfAllContainers = maxNumberOfAllContainers;
            this.maxNumberOfHeavyContainers = maxNumberOfHeavyContainers;
            this.maxNumberOfLiquidContainers = maxNumberOfLiquidContainers;
            this.maxNumberOfRefrigeratedContainers = maxNumberOfRefrigeratedContainers;
            this.fuelConsumptionPerKM = fuelConsumptionPerKM;
        }

        public bool load(Container cont)
        {
            if (Convert.ToInt32(cont.weight) <= 3000)
            {
                if (cont.weight.Last() == 'R' || cont.weight.Last() == 'L')
                {
                    return false;
                }
                BasicContainer container = new BasicContainer(cont.weight);
                currentPort.containers.Add(container);
            }
            else
            {
                if (cont.weight.Last() == 'R')
                {
                    RefrigiratedContainer container = new RefrigiratedContainer(cont.weight);
                    currentPort.containers.Add(container);
                }
                else if (cont.weight.Last() == 'L')
                {
                    LiquidContainer container = new LiquidContainer(cont.weight);
                    currentPort.containers.Add(container);
                }
                else
                {
                    HeavyContainer container = new HeavyContainer(cont.weight);
                    currentPort.containers.Add(container);
                }
            }
            return true;
        }

        public void reFuel(double newFuel)
        {
            this.fuel += newFuel;
        }

        public bool sailTo(Port p)
        {
            bool res = (this.currentPort.ID == p.ID);
            return res;
        }

        public bool unLoad(Container cont)
        {
            currentPort.containers.Remove(currentPort.containers.Where(el => el.ID == cont.ID).Single());
            return true;
        }
    }

    public class LightShip : Ship, IShip
    {
        public LightShip(int ID, double fuel, Port currentPort, int totalWeightCapacity,
            int maxNumberOfAllContainers, int maxNumberOfHeavyContainers, int maxNumberOfRefrigeratedContainers,
            int maxNumberOfLiquidContainers, double fuelConsumptionPerKM)
            : base(fuel, currentPort, totalWeightCapacity, maxNumberOfAllContainers,
                  maxNumberOfHeavyContainers, maxNumberOfRefrigeratedContainers,
                  maxNumberOfLiquidContainers, fuelConsumptionPerKM)
        { }
    }

    public class MediumShip : Ship, IShip
    {
        public MediumShip(int ID, double fuel, Port currentPort, int totalWeightCapacity,
            int maxNumberOfAllContainers, int maxNumberOfHeavyContainers, int maxNumberOfRefrigeratedContainers,
            int maxNumberOfLiquidContainers, double fuelConsumptionPerKM)
            : base(fuel, currentPort, totalWeightCapacity, maxNumberOfAllContainers,
                  maxNumberOfHeavyContainers, maxNumberOfRefrigeratedContainers,
                  maxNumberOfLiquidContainers, fuelConsumptionPerKM)
        { }
    }

    public class HeavyShip : Ship, IShip
    {
        public HeavyShip(int ID, double fuel, Port currentPort, int totalWeightCapacity,
            int maxNumberOfAllContainers, int maxNumberOfHeavyContainers, int maxNumberOfRefrigeratedContainers,
            int maxNumberOfLiquidContainers, double fuelConsumptionPerKM)
            : base(fuel, currentPort, totalWeightCapacity, maxNumberOfAllContainers,
                  maxNumberOfHeavyContainers, maxNumberOfRefrigeratedContainers,
                  maxNumberOfLiquidContainers, fuelConsumptionPerKM)
        { }
    }
}
