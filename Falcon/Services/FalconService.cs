using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Rayna.ApiIntegration.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Rayna.ApiIntegration.Services
{
    public class FalconLogInResultDto
    {
        public string Message { get; set; }

        public string JWT { get; set; }

        public string Name { get; set; }
    }

    public class FalconProductDto
    {
        public string ProductCode { get; set; }

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

    public class FalconReservationDto
    {
        public string Date { get; set; }

        public string Time { get; set; }

        public string Package { get; set; }

        [JsonProperty("Lead Passenger")]
        public string LeadPassenger { get; set; }

        [JsonProperty("Booking Ref.")]
        public string BookingReference { get; set; }

        [JsonProperty("No. of Pax.")]
        public int NumberOfPassengers { get; set; }

        [JsonProperty("Passenger Type")]
        public string PassengerType { get; set; }

        public string Weights { get; set; }

        [JsonProperty("Contact Number")]
        public string ContactNumber { get; set; }

        [JsonProperty("Passenger Email")]
        public string PassengerEmail { get; set; }

        [JsonProperty("Booking ID")]
        public string BookingId { get; set; }
    }

    public class FalconBookingDto
    {
        [JsonProperty("Booking ID")]
        public string BookingId { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public string Package { get; set; }

        public string Remarks { get; set; }

        [JsonProperty("Lead Passenger")]
        public string LeadPassenger { get; set; }

        [JsonProperty("Booking Ref.")]
        public string BookingReference { get; set; }

        [JsonProperty("No. of Pax.")]
        public int NumberOfPassengers { get; set; }

        [JsonProperty("Passenger Type")]
        public string PassengerType { get; set; }

        public string Weights { get; set; }

        [JsonProperty("Contact Number")]
        public string ContactNumber { get; set; }

        [JsonProperty("Passenger Email")]
        public string PassengerEmail { get; set; }
    }

    public class FalconService : IFalconService
    {
        private const int SuccessStatus = 1;
        private const int FailedStatus = 0;
        private const string Failed = "Failed";
        private const string ApiUrl = "https://booking.falconhelitours.com/api/fTYgDUwwdC/";
        //private const string ApiUrl = "https://partners.falconhelitours.com/api/fTYgDUwwdC/";
        private const string Secret = "mysecret";

        private string _jwt = string.Empty;
        private string _selectedProductName = string.Empty;

        private async Task<string> LoginAsync(string email, string passKey)
        {
            var httpClient = new HttpClient();

            var url = ApiUrl + "login.php";
            var postData = JsonConvert.SerializeObject(new
            {
                email = email,
                passkey = passKey,
                secret = Secret
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

        private async Task<List<FalconProductDto>> GetFalconProductListAsync(string jwt)
        {
            var falconProductList = new List<FalconProductDto>();

            try
            {
                var httpClient = new HttpClient();

                var url = ApiUrl + "retrieve_packages.php";
                var postData = JsonConvert.SerializeObject(new
                {
                    jwt = jwt,
                    secret = Secret
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

                            foreach (var location in firstPackage.Children())
                            {
                                var selectedLocation = ((JProperty)location).Value;

                                foreach (var product in selectedLocation.Children())
                                {
                                    var selectedProduct = ((JProperty)product).Value;
                                    var selectedProductAsJson = JsonConvert.SerializeObject(selectedProduct);
                                    var falconProduct = JsonConvert.DeserializeObject<FalconProductDto>(selectedProductAsJson);
                                    falconProduct.ProductCode = ((JProperty)product).Name;

                                    falconProductList.Add(falconProduct);
                                }
                            }
                        }
                    }
                }

                return falconProductList;
            }
            catch (Exception ex)
            {
                return falconProductList;
            }
        }

        public async Task<RaynaTourList> GetProductListAsync(string email, string passKey)
        {
            var raynaTourList = new RaynaTourList();

            try
            {
                _jwt = await LoginAsync(email, passKey);

                var httpClient = new HttpClient();

                var url = ApiUrl + "retrieve_packages.php";
                var postData = JsonConvert.SerializeObject(new
                {
                    jwt = _jwt,
                    secret = Secret
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

        public async Task<RaynaTimeSlotList> CheckAvailabilityAsync(string email, string passKey, DateTime date, string productCode, int noOfPax)
        {
            var raynaTimeSlotList = new RaynaTimeSlotList();

            try
            {
                _jwt = await LoginAsync(email, passKey);

                var httpClient = new HttpClient();

                var url = ApiUrl + "retrieve_slots.php";
                var postData = JsonConvert.SerializeObject(new
                {
                    jwt = _jwt,
                    date = date.Date.ToString("yyyy-MM-dd"),
                    package = productCode,
                    noofpax = noOfPax,
                    secret = Secret
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
                            var falconProductList = await GetFalconProductListAsync(_jwt);
                            FalconProductDto falconProduct;

                            if (falconProductList.Count > 0)
                            {
                                falconProduct = falconProductList.Single(s => s.ProductCode == productCode);
                                _selectedProductName = falconProduct.Title;
                            }
                            else
                            {
                                falconProduct = new FalconProductDto();
                            }

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
                                        if (string.IsNullOrEmpty(falconProduct.ProductCode))
                                        {
                                            supplierTimeSlots.Add(new SupplierTimeSlots { TimeSlotId = falconSlot.SlotId, ResourceId = falconSlot.Package, Available = Convert.ToInt32(falconSlot.AvailableSeats), StratTime = Convert.ToDateTime(date.Date.ToString("yyyy-MM-dd") + " " + falconSlot.StartTime), EndTime = Convert.ToDateTime(date.Date.ToString("yyyy-MM-dd") + " " + falconSlot.EndTime) });
                                        }
                                        else
                                        {
                                            supplierTimeSlots.Add(new SupplierTimeSlots { TimeSlotId = falconSlot.SlotId, ResourceId = falconSlot.Package, EventTypeId = "1", Available = Convert.ToInt32(falconSlot.AvailableSeats), StratTime = Convert.ToDateTime(date.Date.ToString("yyyy-MM-dd") + " " + falconSlot.StartTime), EndTime = Convert.ToDateTime(date.Date.ToString("yyyy-MM-dd") + " " + falconSlot.EndTime), AdultPrice = string.IsNullOrEmpty(falconProduct.SharingPrice) ? 0 : Convert.ToDecimal(falconProduct.SharingPrice) });
                                            supplierTimeSlots.Add(new SupplierTimeSlots { TimeSlotId = falconSlot.SlotId, ResourceId = falconSlot.Package, EventTypeId = "2", Available = Convert.ToInt32(falconSlot.AvailableSeats), StratTime = Convert.ToDateTime(date.Date.ToString("yyyy-MM-dd") + " " + falconSlot.StartTime), EndTime = Convert.ToDateTime(date.Date.ToString("yyyy-MM-dd") + " " + falconSlot.EndTime), AdultPrice = string.IsNullOrEmpty(falconProduct.ExclusivePrice) ? 0 : Convert.ToDecimal(falconProduct.ExclusivePrice) });
                                        }
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

        public async Task<RaynaBookingDetails> BookingAsync(string email, string passKey, DateTime date, string productCode, string time, string timeSlotId, int numberOfPax, string paxType, string paxPhoneNumber, string bookingReference, string paymentType)
        {
            var raynaBookingDetails = new RaynaBookingDetails();

            try
            {
                var raynaTimeSlotList = await CheckAvailabilityAsync(email, passKey, date, productCode, numberOfPax);

                if (raynaTimeSlotList.SupplierTimeSlots.Count() > 0)
                {
                    var selectedDateTime = Convert.ToDateTime(date.Date.ToString("yyyy-MM-dd") + " " + time);
                    var selectedTimeSlot = raynaTimeSlotList.SupplierTimeSlots.SingleOrDefault(s => s.StratTime == selectedDateTime &&
                    s.EventTypeId == paxType &&
                    s.TimeSlotId == timeSlotId);

                    if (!string.IsNullOrEmpty(selectedTimeSlot.TimeSlotId))
                    {
                        var endDateTime = selectedTimeSlot.EndTime;

                        _jwt = await LoginAsync(email, passKey);

                        var httpClient = new HttpClient();

                        var url = ApiUrl + "reserve_slot.php";
                        var postData = JsonConvert.SerializeObject(new
                        {
                            jwt = _jwt,
                            date = date.Date.ToString("yyyy-MM-dd"),
                            package = productCode,
                            time = time,
                            slotid = timeSlotId,
                            numberofpax = numberOfPax,
                            paxtype = paxType,
                            paxphonenumber = paxPhoneNumber,
                            bookingreference = bookingReference,
                            secret = Secret
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
                                dynamic reservation = JObject.Parse(body);
                                var reservationList = ((JContainer)reservation);

                                if (reservationList.HasValues)
                                {
                                    var firstReservation = ((JProperty)reservationList.First).Value;
                                    var falconReservationDetails = new FalconReservationDto();

                                    foreach (var reservationRecord in firstReservation.Children())
                                    {
                                        falconReservationDetails = JsonConvert.DeserializeObject<FalconReservationDto>(JsonConvert.SerializeObject(reservationRecord));
                                    }

                                    if (!string.IsNullOrEmpty(falconReservationDetails.BookingId))
                                    {
                                        var bookingUrl = ApiUrl + "book_slot.php";
                                        var bookingPostData = JsonConvert.SerializeObject(new
                                        {
                                            jwt = _jwt,
                                            bookingreference = bookingReference,
                                            bookingid = falconReservationDetails.BookingId,
                                            paymenttype = paymentType,
                                            secret = Secret
                                        });
                                        var bookingContent = new StringContent(postData, Encoding.UTF8, "application/json");
                                        HttpResponseMessage bookingResponse = await httpClient.PostAsync(bookingUrl, content);

                                        string bookingBody = string.Empty;
                                        if (response.IsSuccessStatusCode)
                                        {
                                            bookingBody = await response.Content.ReadAsStringAsync();

                                            if (!string.IsNullOrEmpty(bookingBody))
                                            {
                                                dynamic booking = JObject.Parse(bookingBody);
                                                var bookingList = ((JContainer)booking);

                                                if (bookingList.HasValues)
                                                {
                                                    var firstBookingValue = ((JProperty)bookingList.First).Value;
                                                    var falconBookingDetails = new FalconBookingDto();

                                                    foreach (var bookingRecord in firstBookingValue.Children())
                                                    {
                                                        falconBookingDetails = JsonConvert.DeserializeObject<FalconBookingDto>(JsonConvert.SerializeObject(bookingRecord));
                                                        raynaBookingDetails.SupplierTicketDetails.Add(new SupplierTicketDetails
                                                        {
                                                            ProductCode = falconBookingDetails.Package,
                                                            ProdctName = _selectedProductName,
                                                            EventId = falconBookingDetails.PassengerType,
                                                            StartTime = Convert.ToDateTime(falconBookingDetails.Date + " " + falconBookingDetails.Time),
                                                            EndTime = endDateTime,
                                                            NoOfAdult = falconBookingDetails.NumberOfPassengers,
                                                        });
                                                    }

                                                    if (!string.IsNullOrEmpty(falconBookingDetails.BookingId))
                                                    {
                                                        raynaBookingDetails.SupplierConfirmationNumber = falconBookingDetails.BookingId;
                                                        raynaBookingDetails.Status = SuccessStatus;
                                                        return raynaBookingDetails;
                                                    }
                                                    else
                                                    {
                                                        raynaBookingDetails.Status = FailedStatus;
                                                        raynaBookingDetails.ErrorMessage = Failed;

                                                        return raynaBookingDetails;
                                                    }
                                                }
                                                else
                                                {
                                                    raynaBookingDetails.Status = FailedStatus;
                                                    raynaBookingDetails.ErrorMessage = Failed;

                                                    return raynaBookingDetails;
                                                }
                                            }
                                            else
                                            {
                                                raynaBookingDetails.Status = FailedStatus;
                                                raynaBookingDetails.ErrorMessage = Failed;

                                                return raynaBookingDetails;
                                            }
                                        }
                                        else
                                        {
                                            raynaBookingDetails.Status = FailedStatus;
                                            raynaBookingDetails.ErrorMessage = Failed;

                                            return raynaBookingDetails;
                                        }
                                    }
                                    else
                                    {
                                        raynaBookingDetails.Status = FailedStatus;
                                        raynaBookingDetails.ErrorMessage = Failed;

                                        return raynaBookingDetails;
                                    }
                                }
                                else
                                {
                                    raynaBookingDetails.Status = FailedStatus;
                                    raynaBookingDetails.ErrorMessage = Failed;

                                    return raynaBookingDetails;
                                }
                            }
                            else
                            {
                                raynaBookingDetails.Status = FailedStatus;
                                raynaBookingDetails.ErrorMessage = Failed;

                                return raynaBookingDetails;
                            }
                        }
                        else
                        {
                            raynaBookingDetails.Status = FailedStatus;
                            raynaBookingDetails.ErrorMessage = Failed;

                            return raynaBookingDetails;
                        }
                    }
                    else
                    {
                        raynaBookingDetails.Status = FailedStatus;
                        raynaBookingDetails.ErrorMessage = Failed;

                        return raynaBookingDetails;
                    }
                }
                else
                {
                    raynaBookingDetails.Status = FailedStatus;
                    raynaBookingDetails.ErrorMessage = Failed;

                    return raynaBookingDetails;
                }
            }
            catch (Exception ex)
            {
                raynaBookingDetails.Status = FailedStatus;
                raynaBookingDetails.ErrorMessage = ex.Message;

                return raynaBookingDetails;
            }
        }



        //public async Task<string> ReserveAsync(string email, string passKey, DateTime date, int package, string time, int slotId, int numberOfPax, int paxType, string paxPhoneNumber, string bookingReference)
        //{
        //    jwt = await LoginAsync(email, passKey);

        //    var httpClient = new HttpClient();

        //    var url = ApiUrl + "reserve_slot.php";
        //    var postData = JsonConvert.SerializeObject(new
        //    {
        //        jwt = jwt,
        //        date = date.Date.ToString("yyyy-MM-dd"),
        //        package = package,
        //        time = time,
        //        slotid = slotId,
        //        numberofpax = numberOfPax,
        //        paxtype = paxType,
        //        paxphonenumber = paxPhoneNumber,
        //        bookingreference = bookingReference,
        //        secret = Secret
        //    });
        //    var content = new StringContent(postData, Encoding.UTF8, "application/json");
        //    HttpResponseMessage response = await httpClient.PostAsync(url, content);
        //    //Now process the response
        //    string body = string.Empty;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        body = await response.Content.ReadAsStringAsync();
        //    }

        //    return body;
        //}

        //public async Task<string> BookingAsync(string email, string passKey, string bookingReference, string bookingId, int paymentType)
        //{
        //    jwt = await LoginAsync(email, passKey);

        //    var httpClient = new HttpClient();

        //    var url = ApiUrl + "book_slot.php";
        //    var postData = JsonConvert.SerializeObject(new
        //    {
        //        jwt = jwt,
        //        bookingreference = bookingReference,
        //        bookingid = bookingId,
        //        paymenttype = paymentType,
        //        secret = Secret
        //    });
        //    var content = new StringContent(postData, Encoding.UTF8, "application/json");
        //    HttpResponseMessage response = await httpClient.PostAsync(url, content);
        //    //Now process the response
        //    string body = string.Empty;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        body = await response.Content.ReadAsStringAsync();
        //    }

        //    return body;
        //}

        public async Task<string> CancelBookingAsync(string email, string passKey, string bookingReference, string bookingId)
        {
            _jwt = await LoginAsync(email, passKey);

            var httpClient = new HttpClient();

            var url = ApiUrl + "cancel_slot.php";
            var postData = JsonConvert.SerializeObject(new
            {
                jwt = _jwt,
                bookingreference = bookingReference,
                bookingid = bookingId,
                secret = Secret
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
