using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UTB.Restaurant.Domain.Entities;
using UTB.Restaurant.Infrastructure.Database;

namespace UTB.Restaurant.Application.Services
{
    public class TableService : ITableService
    {
        private readonly RestaurantDbContext _context;

        public TableService(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<List<Table>> GetTablesAsync()
        {
            return await _context.Tables.ToListAsync();
        }

        public async Task<Table> GetTableByIdAsync(int tableId)
        {
            return await _context.Tables
                                 .FirstOrDefaultAsync(t => t.Id == tableId);
        }

        public async Task CreateTableAsync(Table table)
        {
            await _context.Tables.AddAsync(table);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTableAsync(Table table)
        {
            _context.Tables.Update(table);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTableAsync(int tableId)
        {
            var table = await _context.Tables.FindAsync(tableId);
            if (table != null)
            {
                _context.Tables.Remove(table);
                await _context.SaveChangesAsync();
            }
        }
    }
}
