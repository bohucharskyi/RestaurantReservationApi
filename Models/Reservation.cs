namespace ReservationApi.Models
{
    public class Reservation : BaseEntity
    {
        public Reservation(int tableId, DateTime time, string contactInfo)
        {
            TableId = tableId;
            Time = time;
            ContactInfo = contactInfo;
        }

        public DateTime Time { get; set; }
        public string ContactInfo { get; set; }

        public int TableId { get; set; }
        public Table Table { get; set; } = null!;
    }
}
