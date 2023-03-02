using ReservationApi.Dtos;

namespace ReservationApi.Services
{
    public interface IRestaurantService
    {
        Task<IEnumerable<RestaurantDto>> GesRestaurants();
        Task<IEnumerable<LocationDto>> GesRestaurantLocations(int restaurantId);
    }
}
