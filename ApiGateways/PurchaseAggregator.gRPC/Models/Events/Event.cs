namespace Models.Events
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    }
}
