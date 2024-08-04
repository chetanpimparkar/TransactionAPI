using HackathonWebAPI.Models;
using HackathonWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HackathonWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("{tripId}")]
        public async Task<IActionResult> GetTransactionsByTripId(string tripId)
        {
            var transactions = await _transactionService.GetTransactionsByUserAsync(tripId);
            return Ok(transactions);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Transaction transaction)
        {
            //_logger.LogInformation($"POST request received with transactionId: {transaction.TransactionId}, tripId: {transaction.TripId}");
            transaction.DateTime = DateTime.UtcNow;
            transaction.TransactionId = Guid.NewGuid().ToString();
            await _transactionService.AddTransactionAsync(transaction);
            return Ok();
        }
    }
}
