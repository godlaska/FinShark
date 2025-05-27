using api.Models;
using api.DTOs.Stock;
using api.Helpers;

namespace api.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync(QueryObject query); // QueryObject for filtering
        Task<Stock?> GetByIdAsync(int id);  // ? since FirstOrDefault can return null
        Task<Stock> CreateAsync(Stock stockModel);
        Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto);
        Task<Stock?> DeleteAsync(int id);
        Task<bool> StockExists(int id);
    }
}