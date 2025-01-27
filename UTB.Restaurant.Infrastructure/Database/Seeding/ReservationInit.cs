using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.Restaurant.Domain.Entities;
using UTB.Restaurant.Infrastructure.Identity;

namespace UTB.Restaurant.Infrastructure.Database.Seeding
{
    public class ReservationInit
    {
        public IList<Reservation> GetReservations(IList<User> users, IList<Table> tables)
        {
            IList<Reservation> reservations = new List<Reservation>();
            if (users.Count > 0 && tables.Count > 0)
            {
                reservations.Add(new Reservation
                {
                    Id = 1,
                    ReservationDate = DateTime.Now,
                    UserId = users[0].Id,
                    TableId = tables[0].Id
                });
                reservations.Add(new Reservation
                {
                    Id = 2,
                    ReservationDate = DateTime.Now,
                    UserId = users[1].Id,
                    TableId = tables[1].Id
                });
                reservations.Add(new Reservation
                {
                    Id = 3,
                    ReservationDate = DateTime.Now,
                    UserId = users[2].Id,
                    TableId = tables[2].Id
                });
            }
            return reservations;
        }
    }
}

