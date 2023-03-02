using Microsoft.EntityFrameworkCore;
using ReservationApi.Dtos;
using ReservationApi.Models;

namespace ReservationApi.Services
{
    public class ReservationService : IReservationService
    {
        private readonly RestaurantReservationContext _context;

        public ReservationService(RestaurantReservationContext context)
        {
            _context = context;
        }

        public async Task<ReservationResponseDto> MakeReservation(int locationId, int numPeople, DateTime time,
            string contactInfo)
        {
            ValidateParams(numPeople, time);

            var location = await _context.Locations
                .Include(l => l.Restaurant)
                .FirstOrDefaultAsync(l => l.Id == locationId);

            if (location == null)
            {
                throw new ArgumentOutOfRangeException(nameof(locationId), locationId,
                    "There is no location with such id");
            }

            var restaurant = location.Restaurant;
            if (restaurant.OpeningTime > time.TimeOfDay ||
                restaurant.ClosingTime < time.TimeOfDay)
            {
                return new ReservationResponseDto("No - Restaurant is not open");
            }

            var size = GetTableSize(numPeople);
            var tables = await _context.Tables
                .Include(t => t.Reservations.Where(r => r.Time == time))
                .Where(t => t.LocationId == locationId && t.Size == size)
                .ToListAsync();

            var totalTableCount = tables.Count;
            var availableTables = tables
                .Where(t => !t.Reservations.Any())
                .ToList();
            var availableTableCount = availableTables.Count;

            if (availableTableCount > 0)
            {
                var availableTable = availableTables.First();

                var newReservation = new Reservation(availableTable.Id, time, contactInfo);
                _context.Reservations.Add(newReservation);
                await _context.SaveChangesAsync();

                var reservedTablesCount = totalTableCount - availableTableCount;
                string result;
                if (reservedTablesCount == 0)
                {
                    result = $"all {size} tables are available";
                }
                else if (reservedTablesCount == 1)
                {
                    result = $"only 1 {size} table booked so far";
                }
                else
                {
                    result = $"{availableTableCount} {size} tables are available";
                }

                return new ReservationResponseDto($"Yes - {result}");
            }

            return new ReservationResponseDto($"No - there are already {totalTableCount} {size} tables booked");
        }

        private void ValidateParams(int numPeople, DateTime time)
        {
            if (numPeople <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(numPeople), numPeople,
                    "Number of people should be positive");
            }

            if (numPeople > 8)
            {
                throw new ArgumentOutOfRangeException(nameof(numPeople), numPeople,
                    "Reservations for more than 8 people are not allowed");
            }

            if (time.Minute != 0)
            {
                throw new ArgumentOutOfRangeException(nameof(time), time,
                    "Reservations can only be booked on the hour");
            }

            if (time < DateTime.UtcNow)
            {
                throw new ArgumentOutOfRangeException(nameof(time), time,
                    "Reservations can only be booked in the future");
            }
        }

        private Table.TableSize GetTableSize(int numPeople)
        {
            Table.TableSize size;
            if (numPeople <= 2)
            {
                size = Table.TableSize.Small;
            }
            else if (numPeople <= 4)
            {
                size = Table.TableSize.Medium;
            }
            else
            {
                size = Table.TableSize.Large;
            }

            return size;
        }
    }
}
