namespace ReservationApi.Dtos
{
    public class RestaurantDto
    {
        public RestaurantDto(int id, string name, TimeSpan openingTime, TimeSpan closingTime)
        {
            Id = id;
            Name = name;
            OpeningTime = openingTime;
            ClosingTime = closingTime;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan OpeningTime { get; set; }
        public TimeSpan ClosingTime { get; set; }
    }
}
