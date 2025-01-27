using UTB.Restaurant.Domain.Entities;

namespace UTB.Restaurant.Infrastructure.Database.Seeding
{
    public class TableInit
    {
        public IList<Table> GetTables()
        {
            IList<Table> tables = new List<Table>();
            tables.Add(new Table
            {
                Id = 1,
                Seats = 4,
                TableNumber = 1
            });
            tables.Add(new Table
            {
                Id = 2,
                Seats = 5,
                TableNumber = 2
            });
            tables.Add(new Table
            {
                Id = 3,
                Seats = 6,
                TableNumber = 3
            });
            return tables;
        }
    }
}
