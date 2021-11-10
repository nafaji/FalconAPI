using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.Services
{
    public class LogInResultDto
    {
        public string Message { get; set; }

        public string JWT { get; set; }

        public string Name { get; set; }
    }

    public class FalconService : IFalconService
    {
        private const string apiUrl = "https://booking.falconhelitours.com/api/fTYgDUwwdC/";
        //private const string apiUrl = "https://partners.falconhelitours.com/api/fTYgDUwwdC/";
        private const string secret = "mysecret";

        private string jwt = string.Empty;

        private async Task<string> LoginAsync(string email, string passKey)
        {
            var httpClient = new HttpClient();

            var url = apiUrl + "login.php";
            var postData = JsonConvert.SerializeObject(new
            {
                email = email,
                passkey = passKey,
                secret = secret
            });
            var content = new StringContent(postData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(url, content);
            //Now process the response
            string body = string.Empty;
            var loginResultDto = new LogInResultDto();

            if (response.IsSuccessStatusCode)
            {
                body = await response.Content.ReadAsStringAsync();
                loginResultDto = JsonConvert.DeserializeObject<LogInResultDto>(body);
            }

            return loginResultDto.JWT;
        }

        public async Task<string> GetProductListAsync(string email, string passKey)
        {
            jwt = await LoginAsync(email, passKey);

            var httpClient = new HttpClient();

            var url = apiUrl + "retrieve_packages.php";
            var postData = JsonConvert.SerializeObject(new
            {
                jwt = jwt,
                secret = secret
            });
            var content = new StringContent(postData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(url, content);
            //Now process the response
            string body = string.Empty;
            if (response.IsSuccessStatusCode)
            {
                body = await response.Content.ReadAsStringAsync();
            }

            return body;
        }

        public async Task<string> CheckAvailabilityAsync(string email, string passKey, DateTime date, int package, int noOfPax)
        {
            jwt = await LoginAsync(email, passKey);

            var httpClient = new HttpClient();

            var url = apiUrl + "retrieve_slots.php";
            var postData = JsonConvert.SerializeObject(new
            {
                jwt = jwt,
                date = date.Date.ToString("yyyy-MM-dd"),
                package = package,
                noofpax = noOfPax,
                secret = secret
            });
            var content = new StringContent(postData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(url, content);
            //Now process the response
            string body = string.Empty;
            if (response.IsSuccessStatusCode)
            {
                body = await response.Content.ReadAsStringAsync();
            }

            return body;
        }

        public async Task<string> ReserveAsync(string email, string passKey, DateTime date, int package, string time, int slotId, int numberOfPax, int paxType, string paxPhoneNumber, string bookingReference)
        {
            jwt = await LoginAsync(email, passKey);

            var httpClient = new HttpClient();

            var url = apiUrl + "reserve_slot.php";
            var postData = JsonConvert.SerializeObject(new
            {
                jwt = jwt,
                date = date.Date.ToString("yyyy-MM-dd"),
                package = package,
                time = time,
                slotid = slotId,
                numberofpax = numberOfPax,
                paxtype = paxType,
                paxphonenumber = paxPhoneNumber,
                bookingreference = bookingReference,
                secret = secret
            });
            var content = new StringContent(postData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(url, content);
            //Now process the response
            string body = string.Empty;
            if (response.IsSuccessStatusCode)
            {
                body = await response.Content.ReadAsStringAsync();
            }

            return body;
        }

        public async Task<string> BookingAsync(string email, string passKey, string bookingReference, string bookingId, int paymentType)
        {
            jwt = await LoginAsync(email, passKey);

            var httpClient = new HttpClient();

            var url = apiUrl + "book_slot.php";
            var postData = JsonConvert.SerializeObject(new
            {
                jwt = jwt,
                bookingreference = bookingReference,
                bookingid = bookingId,
                paymenttype = paymentType,
                secret = secret
            });
            var content = new StringContent(postData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(url, content);
            //Now process the response
            string body = string.Empty;
            if (response.IsSuccessStatusCode)
            {
                body = await response.Content.ReadAsStringAsync();
            }

            return body;
        }

        public async Task<string> CancelBookingAsync(string email, string passKey, string bookingReference, string bookingId)
        {
            jwt = await LoginAsync(email, passKey);

            var httpClient = new HttpClient();

            var url = apiUrl + "cancel_slot.php";
            var postData = JsonConvert.SerializeObject(new
            {
                jwt = jwt,
                bookingreference = bookingReference,
                bookingid = bookingId,
                secret = secret
            });
            var content = new StringContent(postData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(url, content);
            //Now process the response
            string body = string.Empty;
            if (response.IsSuccessStatusCode)
            {
                body = await response.Content.ReadAsStringAsync();
            }

            return body;
        }
    }
}
