namespace OrderAggregator.Models
{
    public class Order
    {
        public string Id { get; set; }

        public int ClientId { get; set; }

        public ICollection<BookDTO> Books { get; set; }

        public decimal TotalPrice { get; set; }
        public string Address { get; set; }
        public string Date { get; set; }
    }
}
