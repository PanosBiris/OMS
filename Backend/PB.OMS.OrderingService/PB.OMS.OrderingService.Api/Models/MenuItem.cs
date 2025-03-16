namespace PB.OMS.OrderingService.Api.Models
{
    public class MenuItem
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public double Price { get; set; }
    }
}
