using Events.DAL.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Events.DAL.Entities
{
    [Table("Event")]
    public class Event : IEntity<int>, ITrackable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    }
}
