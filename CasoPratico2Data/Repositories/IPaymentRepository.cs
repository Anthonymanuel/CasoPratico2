using CasoPratico2Models.Models;

namespace CasoPratico2Data.Repositories;

public interface IPaymentRepository
{
    Task<Payment> CreatePaymentAsync(Payment payment);
    Task DeletePaymentAsync(int id);
    Task<Payment?> GetPaymentByIdAsync(int id);
    Task<IEnumerable<Payment>> GetPaymentsAsync();
    Task UpdatePaymentAsync(Payment payment);
}