using Microsoft.EntityFrameworkCore;
using ReservationApi.Dtos;
using ReservationApi.Models;

namespace ReservationApi.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly RestaurantReservationContext _context;

        public RestaurantService(RestaurantReservationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RestaurantDto>> GesRestaurants()
        {
            var restaurants = await _context.Restaurants.ToListAsync();
            var restaurantDtos = restaurants.Select(ConvertToDto).ToList();
            return restaurantDtos;
        }

        public async Task<IEnumerable<LocationDto>> GesRestaurantLocations(int restaurantId)
        {
            var locations = await _context.Locations
                .Where(l => l.RestaurantId == restaurantId)
                .ToListAsync();
            var locationDtos = locations.Select(ConvertToDto).ToList();
            return locationDtos;
        }

        private RestaurantDto ConvertToDto(Restaurant model)
        {
            return new RestaurantDto(model.Id, model.Name, model.OpeningTime, model.ClosingTime);
        }

        private LocationDto ConvertToDto(Location model)
        {
            return new LocationDto(model.Id, model.Address);
        }
    }
}
