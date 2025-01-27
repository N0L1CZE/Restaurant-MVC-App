using Microsoft.EntityFrameworkCore;
using UTB.Restaurant.Application.ViewModels;
using UTB.Restaurant.Domain.Entities;
using UTB.Restaurant.Infrastructure.Database;
using System.Linq;


namespace UTB.Restaurant.Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly RestaurantDbContext _context;

        public ReservationService(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<List<Reservation>> GetReservationsAsync()
        {
            return await _context.Reservations
                                 .Include(r => r.User)
                                 .Include(r => r.Table)
                                 .ToListAsync();
        }

        public async Task<ReservationDetailsViewModel> GetReservationByIdAsync(int reservationId)
        {
            var reservation = await _context.Reservations
                                             .Include(r => r.User)
                                             .Include(r => r.Table)
                                             .FirstOrDefaultAsync(r => r.Id == reservationId);

            if (reservation == null)
                return null;

            var viewModel = new ReservationDetailsViewModel
            {
                ReservationId = reservation.Id,
                ReservationDate = reservation.ReservationDate,
                UserName = reservation.User?.UserName,
                Email = reservation.User?.Email,
                Tables = new List<string> { reservation.Table?.TableNumber.ToString() }
            };

            return viewModel;
        }
        public async Task<List<Reservation>> GetReservationByUserIdAsync(int userId)
        {
            return await _context.Reservations
                                 .Include(r => r.Table)
                                 .Where(r => r.UserId == userId)
                                 .ToListAsync();
        }


        public async Task CreateReservationAsync(Reservation reservation)
        {
            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReservationAsync(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReservationAsync(int reservationId)
        {
            var reservation = await _context.Reservations.FindAsync(reservationId);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();
            }
        }
    }
}
