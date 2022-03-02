using Rayna.ApiIntegration.Models.ResponseModels;
using System;
using System.Threading.Tasks;

namespace Rayna.ApiIntegration.Services
{
    public interface IVGSService
    {
        public Task<RaynaTourList> GetProductListAsync();

        public Task<RaynaTimeSlotList> CheckAvailabilityAsync(DateTime date, string productId, int numberOfPax);

        public Task<RaynaBookingDetails> BookingAsync(DateTime date, string productId, string time, string timeSlotId, int numberOfPax, string bookingId);

        public Task<string> CancelBookingAsync(string bookingReference, string bookingId);
    }
}
