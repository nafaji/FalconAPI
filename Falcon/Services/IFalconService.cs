using System;
using System.Threading.Tasks;

namespace Falcon.Services
{
    public interface IFalconService
    {
        public Task<string> GetProductListAsync(string email, string passKey);

        public Task<string> CheckAvailabilityAsync(string email, string passKey, DateTime date, int package, int noOfPax);

        public Task<string> ReserveAsync(string email, string passKey, DateTime date, int package, string time, int slotId, int numberOfPax, int paxType, string paxPhoneNumber, string bookingReference);

        public Task<string> BookingAsync(string email, string passKey, string bookingReference, string bookingId, int paymentType);

        public Task<string> CancelBookingAsync(string email, string passKey, string bookingReference, string bookingId);
    }
}
