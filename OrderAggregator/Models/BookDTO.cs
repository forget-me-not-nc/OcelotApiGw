namespace OrderAggregator.Models
{
    public class BookDTO
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string PublishingHouse { get; set; }
        public ICollection<CategoryDTO> Categories { get; set; }
        public ICollection<AuthorDTO> Authors { get; set; }
    }
}
