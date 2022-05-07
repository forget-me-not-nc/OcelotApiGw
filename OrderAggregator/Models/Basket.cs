namespace OrderAggregator.Models
{
    public class Basket
    {
        public int ClientId { get; set; }
        public List<int> ItemIds { get; set; }
    }
}
