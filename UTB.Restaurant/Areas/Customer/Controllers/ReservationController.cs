using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UTB.Restaurant.Application.Services;
using UTB.Restaurant.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using UTB.Restaurant.Infrastructure.Database;

namespace UTB.Restaurant.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class ReservationController : Controller
    {
        private readonly ITableService tableService;
        private readonly IReservationService reservationService;
        private readonly RestaurantDbContext _context;

        // Konstruktor pro injektování služeb
        public ReservationController(ITableService tableService, IReservationService reservationService, RestaurantDbContext context)
        {
            this.tableService = tableService;
            this.reservationService = reservationService;
            this._context = context;
        }

        public async Task<IActionResult> Create()
        {
            var tables = await tableService.GetTablesAsync();
            ViewBag.Tables = tables;
            return View("~/Areas/Customer/Views/Reservation/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reservation reservation)
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (ModelState.IsValid)
            {
                if (int.TryParse(userIdString, out int userId))
                {
                    reservation.UserId = userId; 
                }
                else
                {
                    ModelState.AddModelError("", "Nepodařilo se získat platné ID uživatele.");
                    var tables = await tableService.GetTablesAsync();
                    ViewBag.Tables = tables;
                    return View(reservation); 
                }

                await reservationService.CreateReservationAsync(reservation);
                return RedirectToAction("Index", "Home", new { area = "" }); 
            }

            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(error.ErrorMessage); 
            }

            var tablesList = await tableService.GetTablesAsync();
            ViewBag.Tables = tablesList;
            return View(reservation); 
        }

        public async Task<IActionResult> MyReservation()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var reservations = await _context.Reservations
                .Include(r => r.Table)
                .Where(r => r.UserId == int.Parse(userId))
                .ToListAsync();

            if (!reservations.Any())
            {
                return View("NoReservation");
            }

            return View(reservations);
        }

        public IActionResult NoReservation()
        {
            return View();
        }
    }
}
