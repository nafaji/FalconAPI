using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rayna.ApiIntegration.Models.RequestModels;
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
        private const string ApiKey = "3e5c4512-249f-4647-b443-13e1d179d08d";

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
            var tourList = new TourList();
            tourList.ApiKey = ApiKey;
            var results = _goldenToursService.GetProductListAsync(tourList);
            return results;
        }

        [HttpGet("CheckAvailability")]
        public Task<RaynaTimeSlotList> CheckAvailability(DateTime date, string productCode, string eventId, string resourceId, string variantsId, int noOfPax)
        {
            var timeSlot = new TimeSlot
            {
                EventTypeId = eventId,
                ResourceId = resourceId,
                ProductCode = productCode,
                TravelDate = date,
                ApiKey = ApiKey,
                VariantsId = variantsId,
                NoOfPax = noOfPax

            };
            var results = _goldenToursService.CheckAvailabilityAsync(timeSlot);
            return results;
        }

        [HttpGet("Booking")]
        public Task<RaynaBookingDetails> BookingAsync(DateTime date,
            string productCode,
            string eventId,
            string resourceId,
            string variantsId,
            int noOfPax,
            string timeSlotId,
            string bookingNotes,

            string resellerReference,
            string fullName,
            string emailAddress,
            string phoneNumber,
            string country)
        {


            var raynaBooking = new Req_RaynaBooking();
            raynaBooking.ReferenceNo = resellerReference;
            raynaBooking.ApiKey = ApiKey;
            raynaBooking.BookingNotes = bookingNotes;

            raynaBooking.ProductDetails.Add(new ProductDetails
            {
                TravelDate = date,
                TimeSlotId = timeSlotId,
                ProductId = productCode,
                EventTypeId = eventId,
                ResourceId = resourceId,
                VariantsId = variantsId,
                Quantity = noOfPax,
            });

            raynaBooking.CustomerDetails.Add(new CustomerDetails
            {
                FirstName = fullName,
                Email = emailAddress,
                MobNo = phoneNumber,
                CountryName = country
            });
            

            var results = _goldenToursService.BookingAsync(raynaBooking);

            return results;
        }

        [HttpGet("CancelBooking")]
        public Task<RaynaTourCancel> CancelBooking(string bookingId)
        {
            var tourCancel = new TourCancel();
            tourCancel.ApiKey = ApiKey;
            tourCancel.BookingId = bookingId;
            var results = _goldenToursService.CancelBookingAsync(tourCancel);
            return results;
        }
    }
}
