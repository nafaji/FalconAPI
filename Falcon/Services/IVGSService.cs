using Rayna.ApiIntegration.Models.ResponseModels;
using System;
using System.Threading.Tasks;

namespace Rayna.ApiIntegration.Services
{
    public interface IVGSService
    {
        public Task<RaynaTourList> GetProductListAsync();

        //public Task<RaynaTimeSlotList> CheckAvailabilityAsync(DateTime date, string productId, int numberOfPax);

        public Task<RaynaTimeSlotList> CheckAvailabilityAsync(string eventId, DateTime date, string time, string productId, int numberOfPax);

        public Task<RaynaBookingDetails> BookingAsync(DateTime date, string eventId, string productId, string time, string timeSlotId, int numberOfPax, string bookingId, string shopCartId);

        public Task<string> CancelBookingAsync(string bookingId, string bookingReference);
    }
}
