using Microsoft.AspNetCore.Mvc;
using ReservationApi.Dtos;
using ReservationApi.Services;

namespace ReservationApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet]
        public async Task<IEnumerable<RestaurantDto>> GetRestaurants()
        {
            var restaurantDtos = await _restaurantService.GesRestaurants();
            return restaurantDtos;
        }

        [HttpGet("Locations/{restaurantId}")]
        public async Task<IEnumerable<LocationDto>> GetLocations(int restaurantId)
        {
            var locationDtos = await _restaurantService.GesRestaurantLocations(restaurantId);
            return locationDtos;
        }
    }
}
