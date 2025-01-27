using UTB.Restaurant.Application.ViewModels;
using UTB.Restaurant.Domain.Entities;

public interface IReservationService
{
    Task<List<Reservation>> GetReservationsAsync();
    Task<ReservationDetailsViewModel> GetReservationByIdAsync(int reservationId);
    Task CreateReservationAsync(Reservation reservation);
    Task UpdateReservationAsync(Reservation reservation);
    Task DeleteReservationAsync(int reservationId);
    Task<List<Reservation>> GetReservationByUserIdAsync(int userId);
}
