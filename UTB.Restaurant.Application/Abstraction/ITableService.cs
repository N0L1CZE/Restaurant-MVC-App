using System.Collections.Generic;
using System.Threading.Tasks;
using UTB.Restaurant.Domain.Entities;

namespace UTB.Restaurant.Application.Services
{
    public interface ITableService
    {
        Task<List<Table>> GetTablesAsync();
        Task<Table> GetTableByIdAsync(int tableId);
        Task CreateTableAsync(Table table);
        Task UpdateTableAsync(Table table);
        Task DeleteTableAsync(int tableId);
    }
}
