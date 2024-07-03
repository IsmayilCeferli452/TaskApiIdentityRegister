using Domain.Common;

namespace Domain.Entities
{
    public class Room : BaseEntity
    {
        public string Name { get; set; }
        public int SeatCount { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}
