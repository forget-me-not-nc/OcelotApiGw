namespace OrderAggregator.Models
{
    public class OrderCreateModel
    {
        public int ClientId { get; set; }

        public Address Address { get; set; }
    }
}
