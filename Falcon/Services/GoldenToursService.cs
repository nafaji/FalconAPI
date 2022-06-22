using Newtonsoft.Json;
using Rayna.ApiIntegration.Models.RequestModels;
using Rayna.ApiIntegration.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Rayna.ApiIntegration.Services
{
    public class GoldenToursErrorDto
    {
        public string Error { get; set; }

        public string ErrorMessage { get; set; }

        public string ProductId { get; set; }

        public string OptionId { get; set; }

        public string UnitId { get; set; }

        public string AvailabilityId { get; set; }
    }

    public class GoldenToursProductDto
    {
        public string Id { get; set; }
        public string InternalName { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public bool AvailabilityRequired { get; set; }
        public string PricingPer { get; set; }
        public List<GoldenToursProductOptionDto> Options { get; set; }
    }

    public class GoldenToursProductOptionDto 
    {
        public string Id { get; set; }
        public string InternalName { get; set; }
        public List<GoldenToursProductUnitDto> Units { get; set; }

        public List<GoldenToursProductPricingFromDto> PricingFrom { get; set; }
    }

    public class GoldenToursProductUnitDto
    {
        public string Id { get; set; }
        public string InternalName { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public List<GoldenToursProductPricingFromDto> PricingFrom { get; set; }
    }

    public class GoldenToursProductPricingFromDto
    {
        public decimal? Original { get; set; }
        public decimal? Retail { get; set; }
        public decimal? Net { get; set; }
        public string Currency { get; set; }
        public int? CurrencyPrecision { get; set; }

        public List<GoldenToursIncludedTaxesDto> IncludedTaxes { get; set; }
    }

    public class GoldenToursIncludedTaxesDto
    {
        public string Name { get; set; }
        public decimal? Original { get; set; }
        public decimal? Retail { get; set; }
        public decimal? Net { get; set; }
    }

    public class GoldenToursAvailabilityDto
    {
        public string Id { get; set; }

        public DateTime LocalDateTimeStart { get; set; }

        public DateTime LocalDateTimeEnd { get; set; }

        public bool Available { get; set; }

        public int? Vacancies { get; set; }

        public GoldenToursProductPricingFromDto Pricing { get; set; }
    }

    public class GoldenToursBookingReservationDto
    {
        public string Id { get; set; }

        public string UUId { get; set; }

        public string ProductId { get; set; }

        public GoldenToursProductDto Product { get; set; }

        public string OptionId { get; set; }

        public GoldenToursAvailabilityDto Availability { get; set; }
    }

    public class GoldenToursBookingConfirmationDto
    {
        public string Id { get; set; }

        public string UUId { get; set; }

        public string Status { get; set; }

        public string SupplierReference { get; set; }

        public string ProductId { get; set; }

        public GoldenToursProductDto Product { get; set; }

        public string OptionId { get; set; }

        public GoldenToursAvailabilityDto Availability { get; set; }

        public List<GoldenToursBookingConfirmationUnitItemDto> UnitItems { get; set; }
    }

    public class GoldenToursBookingConfirmationUnitItemDto
    {
        public string UUId { get; set; }

        public string UnitId { get; set; }

        public GoldenToursBookingConfirmationUnitDto Unit { get; set; }

        public GoldenToursBookingConfirmationUnitItemTicketDto Ticket { get; set; }
    }


    public class GoldenToursBookingConfirmationUnitDto
    {
        public string Id { get; set; }

        public string InternalName { get; set; }

        public string Type { get; set; }

    }

    public class GoldenToursBookingConfirmationUnitItemTicketDto
    {
        public List<GoldenToursBookingConfirmationUnitItemTicketDeliveryOptionDto> DeliveryOptions {get; set;}
    }

    public class GoldenToursBookingConfirmationUnitItemTicketDeliveryOptionDto
    {
        public string DeliveryFormat { get; set; }

        public string DeliveryValue { get; set; }
    }

    public class GoldenToursService : IGoldenToursService
    {
        private const int SuccessStatus = 1;
        private const int FailedStatus = 0;
        private const string Failed = "Failed";

        private const string ApiUrl = "https://api.ventrata.com/octo";
        

        public async Task<RaynaTourList> GetProductListAsync(TourList tourList)
        {
            var raynaTourList = new RaynaTourList();

            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tourList.ApiKey);

                var url = ApiUrl + "/products";
                
                HttpResponseMessage response = await httpClient.GetAsync(url);
                //Now process the response
                string body = string.Empty;
                if (response.IsSuccessStatusCode)
                {
                    body = await response.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(body))
                    {
                        var goldenToursProductResult = JsonConvert.DeserializeObject<List<GoldenToursProductDto>>(body);
                        var supplierTourList = new List<SupplierTourList>();

                        foreach (var product in goldenToursProductResult)
                        {
                            if (product.Options[0] != null)
                            {
                                foreach (var option in product.Options)
                                {
                                    string productPrice = string.Empty;
                                    string productTax = string.Empty;

                                    if (product.PricingPer == "BOOKING")
                                    {
                                        if (option.PricingFrom != null)
                                        {
                                            var pricingFrom = option.PricingFrom.SingleOrDefault(p => p.Currency == "USD");
                                            productPrice = pricingFrom.Original.ToString();

                                            if (pricingFrom.IncludedTaxes.Count > 0)
                                            {
                                                productTax = pricingFrom.IncludedTaxes.SingleOrDefault().Original.ToString();
                                            }
                                            else
                                            {
                                                productTax = "0.00";
                                            }
                                        }
                                        else
                                        {
                                            productPrice = "0.00";
                                            productTax = "0.00";
                                        }
                                    }

                                    foreach (var unit in option.Units)
                                    {
                                        if (product.PricingPer == "UNIT")
                                        {
                                            if (unit.PricingFrom != null)
                                            {
                                                var pricingFrom = unit.PricingFrom.SingleOrDefault(p => p.Currency == "USD");
                                                productPrice = pricingFrom.Original.ToString();

                                                if (pricingFrom.IncludedTaxes.Count > 0)
                                                {
                                                    productTax = pricingFrom.IncludedTaxes.SingleOrDefault().Original.ToString();
                                                }
                                                else
                                                {
                                                    productTax = "0.00";
                                                }
                                            }
                                            else
                                            {
                                                productPrice = "0.00";
                                                productTax = "0.00";
                                            }
                                        }

                                        supplierTourList.Add(new SupplierTourList
                                        {
                                            ProductCode = product.Id,
                                            //ProductName = product.Title + " | " + option.InternalName + " | " + unit.InternalName,
                                            ProductName = product.Title,
                                            ProductDescription = product.ShortDescription,
                                            ProductPrice = (Convert.ToDecimal(productPrice) / 100).ToString("N2"),
                                            ProductTax = (Convert.ToDecimal(productTax) / 100).ToString("N2"),
                                            ResourceId = unit.Id,
                                            EventTypeId = option.Id,
                                            IsTimeSlot = product.AvailabilityRequired,
                                            VariantsId = unit.InternalName.ToLower()
                                        });
                                    }
                                }
                            }
                        }

                        raynaTourList.Status = SuccessStatus;
                        raynaTourList.SupplierTourList = supplierTourList;
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
            catch (Exception ex)
            {
                raynaTourList.Status = FailedStatus;
                raynaTourList.ErrorMessage = ex.Message;

                return raynaTourList;
            }
        }

        public async Task<RaynaTimeSlotList> CheckAvailabilityAsync(TimeSlot timeSlot)
        {
            var raynaTimeSlotList = new RaynaTimeSlotList();

            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", timeSlot.ApiKey);

                var url = ApiUrl + "/availability";
                var date = timeSlot.TravelDate;

                var postData = JsonConvert.SerializeObject(new
                {
                    productId = timeSlot.ProductCode,
                    optionId = timeSlot.EventTypeId,
                    localDateStart = date.Date.ToString("yyyy-MM-dd"),
                    localDateEnd = date.Date.ToString("yyyy-MM-dd"),
                    units = new object[] { new { id = timeSlot.VariantsId, quantity = timeSlot.NoOfPax } }

                });
                var content = new StringContent(postData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                string body = string.Empty;
                if (response.IsSuccessStatusCode)
                {
                    body = await response.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(body) && body != "[]")
                    {
                        var goldenToursAvailabilityResult = JsonConvert.DeserializeObject<List<GoldenToursAvailabilityDto>>(body);
                        var supplierTimeSlots = new List<SupplierTimeSlots>();

                        var availableResult = goldenToursAvailabilityResult.Where(t => t.Available == true && t.Vacancies != null).ToList();

                        if (availableResult.Count > 0)
                        {
                            foreach (var goldenToursAvailability in goldenToursAvailabilityResult)
                            {
                                supplierTimeSlots.Add(
                                    new SupplierTimeSlots
                                    {
                                        TimeSlotId = goldenToursAvailability.Id,
                                        EventTypeId = timeSlot.EventTypeId,
                                        StratTime = goldenToursAvailability.LocalDateTimeStart,
                                        EndTime = goldenToursAvailability.LocalDateTimeEnd,
                                        Available = goldenToursAvailability.Vacancies == null ? 0 : Convert.ToInt32(goldenToursAvailability.Vacancies),
                                        ResourceId = timeSlot.ResourceId
                                    });
                            }

                            raynaTimeSlotList.Status = SuccessStatus;
                            raynaTimeSlotList.SupplierTimeSlots = supplierTimeSlots;
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

        public async Task<RaynaBookingDetails> BookingAsync(Req_RaynaBooking raynaBooking)
        {
            var raynaBookingDetails = new RaynaBookingDetails();
            try
            {
                var timeSlot = new TimeSlot
                {
                    EventTypeId = raynaBooking.ProductDetails[0].EventTypeId,
                    ResourceId = raynaBooking.ProductDetails[0].ResourceId,
                    ProductCode = raynaBooking.ProductDetails[0].ProductId,
                    TravelDate = raynaBooking.ProductDetails[0].TravelDate,
                    ApiKey = raynaBooking.ApiKey,
                    VariantsId = raynaBooking.ProductDetails[0].VariantsId,
                    NoOfPax = raynaBooking.ProductDetails[0].Quantity

                };

                var raynaTimeSlotList = await CheckAvailabilityAsync(timeSlot);

                if (raynaTimeSlotList.SupplierTimeSlots.Count > 0)
                {
                    var timeSlotId = raynaBooking.ProductDetails[0].TimeSlotId;
                    var selectedTimeSlot = raynaTimeSlotList.SupplierTimeSlots.SingleOrDefault(s => s.TimeSlotId == timeSlotId);

                    if (!string.IsNullOrEmpty(selectedTimeSlot.TimeSlotId))
                    {

                        var httpClient = new HttpClient();
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", raynaBooking.ApiKey);

                        var noOfPax = raynaBooking.ProductDetails[0].Quantity;
                        var totalUnitItems = new object[noOfPax];

                        for (int i = 0; i < noOfPax; i++)
                        {
                            totalUnitItems[i] = new { unitId = raynaBooking.ProductDetails[0].VariantsId };
                        }

                        var url = ApiUrl + "/bookings";
                        var postData = JsonConvert.SerializeObject(new
                        {
                            productId = raynaBooking.ProductDetails[0].ProductId,
                            optionId = raynaBooking.ProductDetails[0].EventTypeId,
                            availabilityId = timeSlotId,
                            notes = raynaBooking.BookingNotes,
                            unitItems = totalUnitItems
                        });
                        var content = new StringContent(postData, Encoding.UTF8, "application/json");
                        HttpResponseMessage response = await httpClient.PostAsync(url, content);

                        string body = string.Empty;
                        if (response.IsSuccessStatusCode)
                        {
                            body = await response.Content.ReadAsStringAsync();

                            if (!string.IsNullOrEmpty(body))
                            {
                                var goldenToursBookingReservationResult = JsonConvert.DeserializeObject<GoldenToursBookingReservationDto>(body);
                                
                                if (!string.IsNullOrEmpty(goldenToursBookingReservationResult.Id))
                                {
                                    url = url + "/" + goldenToursBookingReservationResult.UUId + "/confirm";

                                    postData = JsonConvert.SerializeObject(new
                                    {
                                        resellerReference = raynaBooking.ReferenceNo,
                                        contact = new
                                        {
                                            fullName = raynaBooking.CustomerDetails[0].FirstName,
                                            emailAddress = raynaBooking.CustomerDetails[0].Email,
                                            phoneNumber = raynaBooking.CustomerDetails[0].MobNo,
                                            locales = new string[] { "en-GB", "en-US", "en" },
                                            country = raynaBooking.CustomerDetails[0].CountryName
                                        }

                                    });
                                    content = new StringContent(postData, Encoding.UTF8, "application/json");
                                    response = await httpClient.PostAsync(url, content);

                                    body = string.Empty;

                                    if (response.IsSuccessStatusCode)
                                    {
                                        body = await response.Content.ReadAsStringAsync();

                                        if (!string.IsNullOrEmpty(body))
                                        {
                                            //raynaBookingDetails.SupplierConfirmationNumber = goldenToursBookingReservationResult.UUId;
                                            var goldenToursBookingConfirmationResult = JsonConvert.DeserializeObject<GoldenToursBookingConfirmationDto>(body);

                                            foreach(var unitItem in goldenToursBookingConfirmationResult.UnitItems)
                                            {
                                                var qrCode = unitItem.Ticket.DeliveryOptions.SingleOrDefault(d => d.DeliveryFormat == "QRCODE").DeliveryValue;

                                                var supplierTicketDetail = new SupplierTicketDetails();
                                                supplierTicketDetail.Barcode = qrCode;
                                                supplierTicketDetail.ProductCode = goldenToursBookingConfirmationResult.Product.Id;
                                                supplierTicketDetail.ProdctName = goldenToursBookingConfirmationResult.Product.Title;
                                                supplierTicketDetail.EventId = goldenToursBookingConfirmationResult.OptionId;
                                                supplierTicketDetail.StartTime = goldenToursBookingConfirmationResult.Availability.LocalDateTimeStart;
                                                supplierTicketDetail.EndTime = goldenToursBookingConfirmationResult.Availability.LocalDateTimeEnd;

                                                if (raynaBooking.ProductDetails[0].VariantsId == "adult")
                                                {
                                                    supplierTicketDetail.NoOfAdult = 1;
                                                }
                                                else
                                                {
                                                    supplierTicketDetail.NoOfChild = 1;
                                                }

                                                raynaBookingDetails.SupplierTicketDetails.Add(supplierTicketDetail);
                                            }

                                            raynaBookingDetails.SupplierConfirmationNumber = goldenToursBookingConfirmationResult.UUId;
                                            raynaBookingDetails.SupplierConfirmationCode = goldenToursBookingConfirmationResult.SupplierReference;
                                            raynaBookingDetails.Status = SuccessStatus;

                                            return raynaBookingDetails;
                                        }

                                        raynaBookingDetails.Status = FailedStatus;
                                        raynaBookingDetails.ErrorMessage = Failed;

                                        return raynaBookingDetails;
                                    }

                                    raynaBookingDetails.Status = FailedStatus;
                                    raynaBookingDetails.ErrorMessage = Failed;

                                    return raynaBookingDetails;
                                }

                                raynaBookingDetails.Status = FailedStatus;
                                raynaBookingDetails.ErrorMessage = Failed;

                                return raynaBookingDetails;
                            }

                            raynaBookingDetails.Status = FailedStatus;
                            raynaBookingDetails.ErrorMessage = Failed;

                            return raynaBookingDetails;
                        }

                        raynaBookingDetails.Status = FailedStatus;
                        raynaBookingDetails.ErrorMessage = Failed;

                        return raynaBookingDetails;
                    }

                    raynaBookingDetails.Status = FailedStatus;
                    raynaBookingDetails.ErrorMessage = Failed;

                    return raynaBookingDetails;
                }

                raynaBookingDetails.Status = FailedStatus;
                raynaBookingDetails.ErrorMessage = Failed;

                return raynaBookingDetails;

            }
            catch (Exception ex)
            {
                raynaBookingDetails.Status = FailedStatus;
                raynaBookingDetails.ErrorMessage = ex.Message;

                return raynaBookingDetails;
            }
        }

        public async Task<RaynaBookingDetails> GetBookingDetailsAsync(Req_RaynaBooking raynaBooking)
        {
            var raynaBookingDetails = new RaynaBookingDetails();
            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", raynaBooking.ApiKey);

                var url = ApiUrl + "/bookings/" + raynaBooking.BookingId;

                HttpResponseMessage response = await httpClient.GetAsync(url);
                //Now process the response
                string body = string.Empty;

                if (response.IsSuccessStatusCode)
                {
                    body = await response.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(body))
                    {
                        var goldenToursBookingConfirmationResult = JsonConvert.DeserializeObject<GoldenToursBookingConfirmationDto>(body);

                        foreach (var unitItem in goldenToursBookingConfirmationResult.UnitItems)
                        {
                            var qrCode = unitItem.Ticket.DeliveryOptions.SingleOrDefault(d => d.DeliveryFormat == "QRCODE").DeliveryValue;

                            var supplierTicketDetail = new SupplierTicketDetails();
                            supplierTicketDetail.Barcode = qrCode;
                            supplierTicketDetail.ProductCode = goldenToursBookingConfirmationResult.Product.Id;
                            supplierTicketDetail.ProdctName = goldenToursBookingConfirmationResult.Product.Title;
                            supplierTicketDetail.EventId = goldenToursBookingConfirmationResult.OptionId;
                            supplierTicketDetail.StartTime = goldenToursBookingConfirmationResult.Availability.LocalDateTimeStart;
                            supplierTicketDetail.EndTime = goldenToursBookingConfirmationResult.Availability.LocalDateTimeEnd;

                            if (unitItem.Unit.InternalName.ToLower() == "adult")
                            {
                                supplierTicketDetail.NoOfAdult = 1;
                            }
                            else
                            {
                                supplierTicketDetail.NoOfChild = 1;
                            }

                            raynaBookingDetails.SupplierTicketDetails.Add(supplierTicketDetail);
                        }

                        raynaBookingDetails.SupplierConfirmationNumber = goldenToursBookingConfirmationResult.UUId;
                        raynaBookingDetails.SupplierConfirmationCode = goldenToursBookingConfirmationResult.SupplierReference;
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
            catch (Exception ex)
            {
                raynaBookingDetails.Status = FailedStatus;
                raynaBookingDetails.ErrorMessage = ex.Message;

                return raynaBookingDetails;
            }
        }

        public async Task<RaynaTourCancel> CancelBookingAsync(TourCancel tourCancel)
        {
            var raynaTourCancel = new RaynaTourCancel();
            var supplierCancellationDetail = new SupplierCancellationDetail();

            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tourCancel.ApiKey);
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

                var url = ApiUrl + "/bookings/" + tourCancel.BookingId;

                HttpResponseMessage response = await httpClient.DeleteAsync(url);
                
                string body = string.Empty;

                if (response.IsSuccessStatusCode)
                {

                    body = await response.Content.ReadAsStringAsync();

                    raynaTourCancel.Status = SuccessStatus;
                    raynaTourCancel.SupplierCancellationDetails = supplierCancellationDetail;
                    return raynaTourCancel;
                }

                raynaTourCancel.Status = FailedStatus;
                raynaTourCancel.ErrorMessage = Failed;
                return raynaTourCancel;
            }
            catch (Exception ex)
            {
                raynaTourCancel.Status = FailedStatus;
                raynaTourCancel.ErrorMessage = ex.Message;
                return raynaTourCancel;
            }
        }
    }
}
