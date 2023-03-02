namespace ReservationApi.Dtos
{
    public class ReservationRequestDto
    {
        public int LocationId { get; set; }
        public int NumPeople { get; set; }
        public DateTime Time { get; set; }
        public string ContactInfo { get; set; } = string.Empty;
    }
}
