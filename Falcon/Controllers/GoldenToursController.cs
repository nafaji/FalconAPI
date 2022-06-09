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
    public class GoldenToursController : ControllerBase
    {
        private readonly ILogger<VGSController> _logger;
        private readonly IGoldenToursService _goldenToursService;

        public GoldenToursController(ILogger<VGSController> logger, IGoldenToursService goldenToursService)
        {
            _logger = logger;
            _goldenToursService = goldenToursService;
        }

        [HttpGet("GetProductList")]
        public Task<RaynaTourList> GetProductList()
        {
            var results = _goldenToursService.GetProductListAsync();
            return results;
        }

        [HttpGet("CheckAvailability")]
        public Task<RaynaTimeSlotList> CheckAvailability(DateTime date, string productCode, string eventId, string resourceId, string note, int noOfPax)
        {
            var results = _goldenToursService.CheckAvailabilityAsync(date, productCode, eventId, resourceId, note, noOfPax);
            return results;
        }

        [HttpGet("Booking")]
        public Task<RaynaBookingDetails> BookingAsync(DateTime date,
            string productCode,
            string eventId,
            string resourceId,
            string note,
            int noOfPax,
            string timeSlotId,
            string bookingNotes,
            string resellerReference,
            string fullName,
            string emailAddress,
            string phoneNumber,
            string country)
        {
            var results = _goldenToursService.BookingAsync(date,
            productCode,
            eventId,
            resourceId,
            note,
            noOfPax,
            timeSlotId,
            bookingNotes,
            resellerReference,
            fullName,
            emailAddress,
            phoneNumber,
            country);

            return results;
        }

        [HttpGet("CancelBooking")]
        public Task<string> CancelBooking(string bookingId)
        {
            var results = _goldenToursService.CancelBookingAsync(bookingId);
            return results;
        }
    }
}
