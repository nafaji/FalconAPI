using Rayna.ApiIntegration.Models.ResponseModels;
using System;
using System.Threading.Tasks;

namespace Rayna.ApiIntegration.Services
{
    public interface IFalconService
    {
        public Task<RaynaTourList> GetProductListAsync(string email, string passKey);

        public Task<RaynaTimeSlotList> CheckAvailabilityAsync(string email, string passKey, DateTime date, string productCode, int noOfPax);

        public Task<RaynaBookingDetails> BookingAsync(string email, string passKey, DateTime date, string productCode, string time, string timeSlotId, int numberOfPax, string paxType, string paxPhoneNumber, string bookingReference, string paymentType);

        //public Task<string> ReserveAsync(string email, string passKey, DateTime date, int package, string time, int slotId, int numberOfPax, int paxType, string paxPhoneNumber, string bookingReference);

        //public Task<string> BookingAsync(string email, string passKey, string bookingReference, string bookingId, int paymentType);

        public Task<string> CancelBookingAsync(string email, string passKey, string bookingReference, string bookingId);
    }
}
