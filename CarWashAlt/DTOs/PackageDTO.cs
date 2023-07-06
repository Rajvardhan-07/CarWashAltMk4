namespace CarWashAlt.DTOs
{
    public class PackageDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string Status { get; set; } = "Available";
    }
}
