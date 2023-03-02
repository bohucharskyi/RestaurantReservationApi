namespace ReservationApi.Models
{
    public class Table : BaseEntity
    {
        public Table()
        {
        }

        public Table(int id, int locationId, TableSize size)
        {
            Id = id;
            LocationId = locationId;
            Size = size;
        }

        public enum TableSize
        {
            Small,
            Medium,
            Large
        }

        public TableSize Size { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; } = null!;
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
