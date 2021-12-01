using Newtonsoft.Json;
using Rayna.ApiIntegration.Models.ResponseModels;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Rayna.ApiIntegration.Services
{
    public class VGSService : IVGSService
    {
        private const string ApiUrl = "https://snappstagingweb.meraas.ae/";
        private const string WorkstationId = "AB95397F-F8D9-3128-04CA-017D4CDE5A57";
        private const string ApiKey = "T8JC5B7DW6QEEZVJJ0GY33S0GWB3VH1UDTXBBB6YP11BWH9SQW";
        private const string CatalogId = "16EC62F7-E5AC-5ECA-28FB-017BE91790DF";

        //private const string Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJTTlAiLCJpYXQiOjE2MDk0NTkyMDAsImV4cCI6MTY3Mjc5MDQwMCwiY2xpIjoiQVBJIiwid2lkIjoiQUI5NTM5N0YtRjhEOS0zMTI4LTA0Q0EtMDE3RDRDREU1QTU3In0.r8ZSmDObV6rBaAa3QFihkV4TOks6o2CbLNuf2hzH4QQ";
        private const string Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJTTlAiLCJpYXQiOjE2MDk0NTkyMDAsImV4cCI6MTY3Mjc5MDQwMCwiY2xpIjoiQVBJIiwid2lkIjoiQUI5NTM5N0YtRjhEOS0zMTI4LTA0Q0EtMDE3RDRDREU1QTU3In0.NLV1zO-JUanHMtH0bgSRXYrJjdY37M7KukAq65v-6ro";

        public Task<string> BookingAsync(string email, string passKey, string bookingReference, string bookingId, int paymentType)
        {
            throw new NotImplementedException();
        }

        public Task<string> CancelBookingAsync(string email, string passKey, string bookingReference, string bookingId)
        {
            throw new NotImplementedException();
        }

        public Task<RaynaTimeSlotList> CheckAvailabilityAsync(string email, string passKey, DateTime date, int package, int noOfPax)
        {
            throw new NotImplementedException();
        }

        public async Task<RaynaTourList> GetProductListAsync()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            //httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            var url = ApiUrl + "/service?format=json&cmd=CATALOG";
            //            
            var postData = JsonConvert.SerializeObject(new
            {
                Header = new
                {
                    WorkstationId = WorkstationId
                },
                Request = new
                {
                    Command = "LoadEntCatalog",
                    LoadEntCatalog = new
                    {
                        CatalogId = CatalogId
                    }
                }
            });

            var content = new StringContent(postData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(url, content);

            string body = string.Empty;
            if (response.IsSuccessStatusCode)
            {
                body = await response.Content.ReadAsStringAsync();
            }

            return null;
        }

        public Task<string> ReserveAsync(string email, string passKey, DateTime date, int package, string time, int slotId, int numberOfPax, int paxType, string paxPhoneNumber, string bookingReference)
        {
            throw new NotImplementedException();
        }
    }
}
