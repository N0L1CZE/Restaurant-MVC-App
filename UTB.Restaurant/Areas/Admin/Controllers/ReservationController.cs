using Microsoft.AspNetCore.Mvc;
using UTB.Restaurant.Infrastructure.Database;
using UTB.Restaurant.Domain.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UTB.Restaurant.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReservationController(RestaurantDbContext context) : Controller
    {

        public async Task<IActionResult> Select()
        {
            var reservations = await context.Reservations
                .Include(r => r.User)
                .Include(r => r.Table)
                .ToListAsync();

            return View(reservations);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatus(int id, bool status)
        {
            var reservation = await context.Reservations.FindAsync(id);
            if (reservation != null)
            {
                reservation.Status = status;
                await context.SaveChangesAsync();
            }

            return RedirectToAction("Select");
        }
    }
}
