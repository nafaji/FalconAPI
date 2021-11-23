using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rayna.APIIntegration.Models.ResponseModels;
using Rayna.APIIntegration.Services;
using System;
using System.Threading.Tasks;

namespace Rayna.APIIntegration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FalconController : ControllerBase
    {
        private readonly ILogger<FalconController> _logger;
        private readonly IFalconService _falconService;

        public FalconController(ILogger<FalconController> logger, IFalconService falconService)
        {
            _logger = logger;
            _falconService = falconService;
        }

        [HttpGet("GetProductList")]
        public Task<RaynaTourList> GetProductList(string email, string passKey)
        {
            var results = _falconService.GetProductListAsync(email, passKey);
            return results;
        }

        [HttpGet("CheckAvailability")]
        public Task<string> CheckAvailability(string email, string passKey, DateTime date, int package, int noOfPax)
        {
            var results = _falconService.CheckAvailabilityAsync(email, passKey, date, package, noOfPax);
            return results;
        }

        [HttpGet("Reserve")]
        public Task<string> Reserve(string email, string passKey, DateTime date, int package, string time, int slotId, int numberOfPax, int paxType, string paxPhoneNumber, string bookingReference)
        {
            var results = _falconService.ReserveAsync(email, passKey, date, package, time, slotId, numberOfPax, paxType, paxPhoneNumber, bookingReference);
            return results;
        }

        [HttpGet("Booking")]
        public Task<string> Booking(string email, string passKey, string bookingReference, string bookingId, int paymentType)
        {
            var results = _falconService.BookingAsync(email, passKey, bookingReference, bookingId, paymentType);
            return results;
        }

        [HttpGet("CancelBooking")]
        public Task<string> CancelBooking(string email, string passKey, string bookingReference, string bookingId)
        {
            var results = _falconService.CancelBookingAsync(email, passKey, bookingReference, bookingId);
            return results;
        }
    }
}
