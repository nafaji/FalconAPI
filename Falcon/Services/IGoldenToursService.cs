using Rayna.ApiIntegration.Models.RequestModels;
using Rayna.ApiIntegration.Models.ResponseModels;
using System;
using System.Threading.Tasks;

namespace Rayna.ApiIntegration.Services
{
    public interface IGoldenToursService
    {
        public Task<RaynaTourList> GetProductListAsync(TourList tourList);

        public Task<RaynaTimeSlotList> CheckAvailabilityAsync(TimeSlot timeSlot);

        public Task<RaynaBookingDetails> BookingAsync(Req_RaynaBooking raynaBooking);

        public Task<RaynaBookingDetails> GetBookingDetailsAsync(Req_RaynaBooking raynaBooking);

        public Task<RaynaTourCancel> CancelBookingAsync(TourCancel tourCancel);
    }
}
