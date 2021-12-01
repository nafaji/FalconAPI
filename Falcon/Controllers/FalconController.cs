using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rayna.ApiIntegration.Models.ResponseModels;
using Rayna.ApiIntegration.Services;
using System;
using System.Threading.Tasks;

namespace Rayna.ApiIntegration.Controllers
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
        public Task<RaynaTimeSlotList> CheckAvailability(string email, string passKey, DateTime date, string productCode, int noOfPax)
        {
            var results = _falconService.CheckAvailabilityAsync(email, passKey, date, productCode, noOfPax);
            return results;
        }

        [HttpGet("Booking")]
        public Task<RaynaBookingDetails> Booking(string email, string passKey, DateTime date, string productCode, string time, string timeSlotId, int numberOfPax, string paxType, string paxPhoneNumber, string bookingReference, string paymentType)
        {
            var results = _falconService.BookingAsync(email, passKey, date, productCode, time, timeSlotId, numberOfPax, paxType, paxPhoneNumber, bookingReference, paymentType);
            return results;
        }

        //[HttpGet("Booking")]
        //public Task<string> Booking(string email, string passKey, string bookingReference, string bookingId, int paymentType)
        //{
        //    var results = _falconService.BookingAsync(email, passKey, bookingReference, bookingId, paymentType);
        //    return results;
        //}

        [HttpGet("CancelBooking")]
        public Task<string> CancelBooking(string email, string passKey, string bookingReference, string bookingId)
        {
            var results = _falconService.CancelBookingAsync(email, passKey, bookingReference, bookingId);
            return results;
        }
    }
}
