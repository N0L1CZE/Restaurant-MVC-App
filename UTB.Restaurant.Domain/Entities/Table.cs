using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UTB.Restaurant.Domain.Entities
{
    public class Table : Entity<int>
    {
        [Required]
        public int TableNumber { get; set; }
        public int Seats { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
