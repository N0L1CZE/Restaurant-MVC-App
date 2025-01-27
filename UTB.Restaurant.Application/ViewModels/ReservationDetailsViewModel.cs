using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTB.Restaurant.Application.ViewModels
{
    public class ReservationDetailsViewModel
    {
        public int ReservationId { get; set; }
        public DateTime ReservationDate { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public List<string>? Tables { get; set; }
    }
}

