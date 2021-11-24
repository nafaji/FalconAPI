using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Rayna.APIIntegration.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Rayna.APIIntegration.Services
{
    public class FalconLogInResultDto
    {
        public string Message { get; set; }

        public string JWT { get; set; }

        public string Name { get; set; }
    }

    public class FalconProductDto
    {
        public string Title { get; set; }

        public string SharingPrice { get; set; }

        public string ExclusivePrice { get; set; }

        public string PaxType { get; set; }
    }

    public class FalconSlotDto
    {
        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string Package { get; set; }

        public string SlotId { get; set; }

        public string AvailableSeats { get; set; }
    }

    public class FalconService : IFalconService
    {
        private const int SuccessStatus = 1;
        private const int FailedStatus = 0;
        private const string Failed = "Failed";
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
            var loginResultDto = new FalconLogInResultDto();

            if (response.IsSuccessStatusCode)
            {
                body = await response.Content.ReadAsStringAsync();
                loginResultDto = JsonConvert.DeserializeObject<FalconLogInResultDto>(body);
            }

            return loginResultDto.JWT;
        }

        public async Task<RaynaTourList> GetProductListAsync(string email, string passKey)
        {
            var raynaTourList = new RaynaTourList();

            try
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

                    if (!string.IsNullOrEmpty(body))
                    {
                        dynamic packages = JObject.Parse(body);
                        var packageList = ((JContainer)packages);

                        if (packageList.HasValues)
                        {
                            var firstPackage = ((JProperty)packageList.First).Value;

                            var supplierTourList = new List<SupplierTourList>();

                            foreach (var location in firstPackage.Children())
                            {
                                var selectedLocation = ((JProperty)location).Value;

                                foreach (var product in selectedLocation.Children())
                                {
                                    var selectedProduct = ((JProperty)product).Value;
                                    var selectedProductAsJson = JsonConvert.SerializeObject(selectedProduct);
                                    var falconProduct = JsonConvert.DeserializeObject<FalconProductDto>(selectedProductAsJson);

                                    supplierTourList.Add(new SupplierTourList { ProductCode = ((JProperty)product).Name, ProductName = falconProduct.Title, ProductPrice = falconProduct.SharingPrice, ProductDescription = ((JProperty)location).Name });
                                }
                            }

                            raynaTourList.SupplierTourList = supplierTourList;

                            raynaTourList.Status = SuccessStatus;
                            return raynaTourList;
                        }
                        else
                        {
                            raynaTourList.Status = FailedStatus;
                            raynaTourList.ErrorMessage = Failed;
                            return raynaTourList;
                        }
                    }
                    else
                    {
                        raynaTourList.Status = FailedStatus;
                        raynaTourList.ErrorMessage = Failed;
                        return raynaTourList;
                    }
                }
                else
                {
                    raynaTourList.Status = FailedStatus;
                    raynaTourList.ErrorMessage = Failed;
                    return raynaTourList;
                }
            }
            catch (Exception ex)
            {
                raynaTourList.Status = FailedStatus;
                raynaTourList.ErrorMessage = ex.Message;

                return raynaTourList;
            }
        }

        public async Task<RaynaTimeSlotList> CheckAvailabilityAsync(string email, string passKey, DateTime date, int package, int noOfPax)
        {
            var raynaTimeSlotList = new RaynaTimeSlotList();

            try
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

                    if (!string.IsNullOrEmpty(body))
                    {
                        dynamic slots = JObject.Parse(body);
                        var slotList = ((JContainer)slots);

                        if (slotList.HasValues)
                        {
                            var firstSlot = ((JProperty)slotList.First).Value;

                            var supplierTimeSlots = new List<SupplierTimeSlots>();

                            foreach (var slot in firstSlot.Children())
                            {
                                var selectedSlots = ((JProperty)slot).Value;
                                var selectedSlotsAsJson = JsonConvert.SerializeObject(selectedSlots);

                                if (!selectedSlotsAsJson.Contains("message"))
                                {
                                    var falconSlots = JsonConvert.DeserializeObject<List<FalconSlotDto>>(selectedSlotsAsJson);
                                    foreach (var falconSlot in falconSlots)
                                    {
                                        supplierTimeSlots.Add(new SupplierTimeSlots { TimeSlotId = falconSlot.SlotId, Available = Convert.ToInt32(falconSlot.AvailableSeats), StratTime = Convert.ToDateTime(date.Date.ToString("yyyy-MM-dd") + " " + falconSlot.StartTime), EndTime = Convert.ToDateTime(date.Date.ToString("yyyy-MM-dd") + " " + falconSlot.EndTime) });
                                    }
                                }
                            }

                            raynaTimeSlotList.SupplierTimeSlots = supplierTimeSlots;

                            raynaTimeSlotList.Status = SuccessStatus;
                            return raynaTimeSlotList;
                        }
                        else
                        {
                            raynaTimeSlotList.Status = FailedStatus;
                            raynaTimeSlotList.ErrorMessage = Failed;

                            return raynaTimeSlotList;
                        }
                    }
                    else
                    {
                        raynaTimeSlotList.Status = FailedStatus;
                        raynaTimeSlotList.ErrorMessage = Failed;

                        return raynaTimeSlotList;
                    }
                }
                else
                {
                    raynaTimeSlotList.Status = FailedStatus;
                    raynaTimeSlotList.ErrorMessage = Failed;

                    return raynaTimeSlotList;
                }
            }
            catch (Exception ex)
            {
                raynaTimeSlotList.Status = FailedStatus;
                raynaTimeSlotList.ErrorMessage = ex.Message;

                return raynaTimeSlotList;
            }
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
