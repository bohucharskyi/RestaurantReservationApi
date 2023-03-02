namespace ReservationApi.Models
{
    public class Location : BaseEntity
    {
        public Location()
        {
        }

        public Location(int id, int restaurantId, string address)
        {
            Id = id;
            RestaurantId = restaurantId;
            Address = address;
        }

        public string Address { get; set; } = null!;

        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; } = null!;
        public ICollection<Table> Tables { get; set; } = new List<Table>();
    }
}
