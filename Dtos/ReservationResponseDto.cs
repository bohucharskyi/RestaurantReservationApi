namespace ReservationApi.Dtos
{
    public class ReservationResponseDto
    {
        public ReservationResponseDto(string result)
        {
            Result = result;
        }

        public string Result { get; set; }
    }
}
