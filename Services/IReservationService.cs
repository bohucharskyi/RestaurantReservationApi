using ReservationApi.Dtos;

namespace ReservationApi.Services
{
    public interface IReservationService
    {
        Task<ReservationResponseDto> MakeReservation(int locationId, int numPeople, DateTime time, string contactInfo);
    }
}
