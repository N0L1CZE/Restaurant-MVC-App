using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UTB.Restaurant.Domain.Entities.Interfaces;

namespace UTB.Restaurant.Domain.Entities
{
    public class Reservation : Entity<int>
    {
        [Required]
        public DateTime ReservationDate { get; set; }

        public bool? Status { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }

        [ValidateNever]
        public virtual IUser<int> User { get; set; }

        [ForeignKey("Table")]
        public int TableId { get; set; }
        [ValidateNever]
        public virtual Table Table { get; set; }
    }
}

