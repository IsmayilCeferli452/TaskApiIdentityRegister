using Domain.Common;

namespace Domain.Entities
{
    public class City:BaseEntity
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }
    }
}
