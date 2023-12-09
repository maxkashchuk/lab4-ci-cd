namespace lab_4.Models.ModelsController
{
    public class PortController
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public List<Container> containers { get; set; }
        public List<Ship> history { get; set; }
        public List<Ship> current { get; set; }
    }
}
