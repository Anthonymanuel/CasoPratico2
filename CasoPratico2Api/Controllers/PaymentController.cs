using CasoPratico2Data.Repositories;
using CasoPratico2Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace CasoPratico2Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly ILogger<PaymentController> _logger;

    public PaymentController(IPaymentRepository paymentRepository, ILogger<PaymentController> logger)
    {
        _paymentRepository = paymentRepository;
        _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult> AddPayment([FromBody] Payment payment)
    {
        try
        {
            var createdPayment = await _paymentRepository.CreatePaymentAsync(payment);
            return CreatedAtAction(nameof(GetPaymentById), new { id = createdPayment.PaymentId }, createdPayment);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating payment");
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePayment([FromBody] Payment paymentToUpdate)
    {
        try
        {
            var existingPayment = await _paymentRepository.GetPaymentByIdAsync(paymentToUpdate.PaymentId);
            if (existingPayment == null)
            {
                return NotFound(new
                {
                    statusCode = 404,
                    message = "Record not found"
                });
            }

            existingPayment.CustomerId = paymentToUpdate.CustomerId;
            existingPayment.StaffId = paymentToUpdate.StaffId;
            existingPayment.RentalId = paymentToUpdate.RentalId;
            existingPayment.Amount = paymentToUpdate.Amount;
            existingPayment.PaymentDate = paymentToUpdate.PaymentDate;
            existingPayment.LatUpdate = DateTime.Now;

            await _paymentRepository.UpdatePaymentAsync(existingPayment);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating payment");
            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                statusCode = 500,
                message = ex.Message
            });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePayment(int id)
    {
        try
        {
            var existingPayment = await _paymentRepository.GetPaymentByIdAsync(id);
            if (existingPayment == null)
            {
                return NotFound(new
                {
                    statusCode = 404,
                    message = "Record not found"
                });
            }

            await _paymentRepository.DeletePaymentAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting payment");
            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                statusCode = 500,
                message = ex.Message
            });
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Payment>>> GetPayments()
    {
        try
        {
            var payments = await _paymentRepository.GetPaymentsAsync();
            return Ok(payments);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving payments");
            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                statusCode = 500,
                message = ex.Message
            });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPaymentById(int id)
    {
        try
        {
            var payment = await _paymentRepository.GetPaymentByIdAsync(id);
            if (payment == null)
                return NotFound(new { message = "Record not found" });

            return Ok(payment);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving payment by id");
            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                statusCode = 500,
                message = ex.Message
            });
        }
    }
}


