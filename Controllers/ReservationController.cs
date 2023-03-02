using Microsoft.AspNetCore.Mvc;
using ReservationApi.Dtos;
using ReservationApi.Services;

namespace ReservationApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly ILogger<ReservationController> _logger;
        private readonly IReservationService _reservationService;

        public ReservationController(ILogger<ReservationController> logger, IReservationService reservationService)
        {
            _logger = logger;
            _reservationService = reservationService;
        }

        [HttpPost("Make")]
        public async Task<ReservationResponseDto> MakeReservation(ReservationRequestDto requestDto)
        {
            try
            {
                var makeReservation = await _reservationService.MakeReservation(requestDto.LocationId,
                       requestDto.NumPeople, requestDto.Time, requestDto.ContactInfo);
                return makeReservation;
            }
            catch (ArgumentOutOfRangeException e)
            {
                return new ReservationResponseDto($"No. {e.Message}");
            }
        }
    }
}
