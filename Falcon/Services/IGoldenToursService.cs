using Rayna.ApiIntegration.Models.ResponseModels;
using System;
using System.Threading.Tasks;

namespace Rayna.ApiIntegration.Services
{
    public interface IGoldenToursService
    {
        public Task<RaynaTourList> GetProductListAsync();

        public Task<RaynaTimeSlotList> CheckAvailabilityAsync(DateTime date, string productCode, string eventId, string resourceId, string note, int noOfPax);

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
            string country);

        public Task<string> CancelBookingAsync(string bookingId);
    }
}
