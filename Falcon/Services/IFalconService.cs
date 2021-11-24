using Rayna.APIIntegration.Models.ResponseModels;
using System;
using System.Threading.Tasks;

namespace Rayna.APIIntegration.Services
{
    public interface IFalconService
    {
        public Task<RaynaTourList> GetProductListAsync(string email, string passKey);

        public Task<RaynaTimeSlotList> CheckAvailabilityAsync(string email, string passKey, DateTime date, int package, int noOfPax);

        public Task<string> ReserveAsync(string email, string passKey, DateTime date, int package, string time, int slotId, int numberOfPax, int paxType, string paxPhoneNumber, string bookingReference);

        public Task<string> BookingAsync(string email, string passKey, string bookingReference, string bookingId, int paymentType);

        public Task<string> CancelBookingAsync(string email, string passKey, string bookingReference, string bookingId);
    }
}
