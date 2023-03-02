namespace ReservationApi.Models
{
    public class Restaurant : BaseEntity
    {
        public Restaurant()
        {
        }

        public Restaurant(int id, string name, TimeSpan openingTime, TimeSpan closingTime)
        {
            Id = id;
            Name = name;
            OpeningTime = openingTime;
            ClosingTime = closingTime;
        }

        public string Name { get; set; } = null!;
        public TimeSpan OpeningTime { get; set; }
        public TimeSpan ClosingTime { get; set; }

        public ICollection<Location> Locations { get; set; } = new List<Location>();
    }
}
