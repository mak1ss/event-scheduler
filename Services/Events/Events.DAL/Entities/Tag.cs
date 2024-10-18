
using Events.DAL.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Events.DAL.Entities
{
    [Table("Tag")]
    public class Tag : IEntity<int>, ITrackable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public ICollection<Event> Event { get; set; } = new List<Event>();
    }
}
