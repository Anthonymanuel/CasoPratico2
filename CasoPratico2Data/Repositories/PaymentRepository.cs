
using CasoPratico2Data.Context;
using CasoPratico2Models.Models;
using Microsoft.EntityFrameworkCore;

namespace CasoPratico2Data.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly SakilaContext _context;

    public PaymentRepository(SakilaContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Payment>> GetPaymentsAsync()
    {
        return await _context.Payment.ToListAsync();
    }

    public async Task<Payment?> GetPaymentByIdAsync(int id)
    {
        return await _context.Payment.FindAsync(id);
    }

    public async Task<Payment> CreatePaymentAsync(Payment payment)
    {
        _context.Payment.Add(payment);
        await _context.SaveChangesAsync();
        return payment;
    }

    public async Task UpdatePaymentAsync(Payment payment)
    {
        _context.Payment.Update(payment);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePaymentAsync(int id)
    {
        var payment = await _context.Payment.FindAsync(id);
        if (payment != null)
        {
            _context.Payment.Remove(payment);
            await _context.SaveChangesAsync();
        }
    }
}
