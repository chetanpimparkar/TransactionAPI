using HackathonWebAPI.Models;

namespace HackathonWebAPI.Services
{
    public interface ITransactionService
    {
        Task AddTransactionAsync(Transaction transaction);
        Task<List<Transaction>> GetTransactionsByUserAsync(string tripId);
    }
}
