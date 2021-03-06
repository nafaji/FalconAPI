using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rayna.ApiIntegration.Models.ResponseModels;
using Rayna.ApiIntegration.Services;
using System;
using System.Threading.Tasks;

namespace Rayna.ApiIntegration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VGSController : ControllerBase
    {
        private readonly ILogger<VGSController> _logger;
        private readonly IVGSService _vgsService;

        public VGSController(ILogger<VGSController> logger, IVGSService vgsService)
        {
            _logger = logger;
            _vgsService = vgsService;
        }

        [HttpGet("GetProductList")]
        public Task<RaynaTourList> GetProductList()
        {
            var results = _vgsService.GetProductListAsync();
            return results;
        }

        [HttpGet("CheckAvailability")]
        public Task<RaynaTimeSlotList> CheckAvailability(DateTime date, string eventId, string productId, int noOfPax)
        {
            var results = _vgsService.CheckAvailabilityAsync(eventId, date, string.Empty, productId, noOfPax);
            return results;
        }

        [HttpGet("Booking")]
        public Task<RaynaBookingDetails> Booking(DateTime date, string eventId, string productId, string time, string timeSlotId, int numberOfPax, string bookingId)
        {
            var results = _vgsService.BookingAsync(date, eventId, productId, time, timeSlotId, numberOfPax, bookingId, string.Empty);
            return results;
        }

        [HttpGet("CancelBooking")]
        public Task<string> CancelBooking(string bookingId, string bookingReference)
        {
            var results = _vgsService.CancelBookingAsync(bookingId, bookingReference);
            return results;
        }
    }
}
