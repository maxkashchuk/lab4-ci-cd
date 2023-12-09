namespace lab_4.Models.ModelsController
{
    public class ShipController
    {
        public double fuel { get; set; }
        public Port currentPort { get; set; }
        public int totalWeightCapacity { get; set; }
        public int maxNumberOfAllContainers { get; set; }
        public int maxNumberOfHeavyContainers { get; set; }
        public int maxNumberOfRefrigeratedContainers { get; set; }
        public int maxNumberOfLiquidContainers { get; set; }
        public double fuelConsumptionPerKM { get; set; }
    }
}
