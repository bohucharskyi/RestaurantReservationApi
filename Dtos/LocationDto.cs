namespace ReservationApi.Dtos
{
    public class LocationDto
    {
        public LocationDto(int id, string address)
        {
            Id = id;
            Address = address;
        }

        public int Id { get; set; }
        public string Address { get; set; }
    }
}
