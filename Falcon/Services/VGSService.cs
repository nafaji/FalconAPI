using Newtonsoft.Json;
using Rayna.ApiIntegration.Models.ResponseModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Rayna.ApiIntegration.Services
{
    public class VGSCatalogResultDto
    {
        public VGSAnswerDto Answer { get; set; }
        public VGSHeaderDto Header { get; set; }
    }

    public class VGSAnswerDto
    {
        public VGSLoadEntCatalogDto LoadEntCatalog { get; set; }
    }

    public class VGSLoadEntCatalogDto
    {
        public VGSLoadEntCatalogCatalogDto Catalog { get; set; }

        public VGSLoadEntCatalogHeaderDto Header { get; set; }
    }

    public class VGSLoadEntCatalogCatalogDto
    {
        public bool AuthNeeded { get; set; }

        public string BackgroundColor { get; set; }

        public string ButtonDisplayType { get; set; }

        public string CatalogCode { get; set; }

        public string CatalogId { get; set; }

        public string CatalogName { get; set; }

        public string CatalogNameExt { get; set; }

        public int CatalogType { get; set; }

        public string EntityId { get; set; }

        public string EntityType { get; set; }

        public int FlowType { get; set; }

        public string ForegroundColor { get; set; }

        public string IconName { get; set; }

        public DateTime? LastUpdate { get; set; }

        public List<VGSNodeDto> Nodes { get; set; }

        public string ParentCatalogId { get; set; }

        public int PriorityOrder { get; set; }

        public string ProfilePictureId { get; set; }

        public List<VGSLoadEntCatalogCatalogRichDescListDto> RichDescList { get; set; }

        public string RootCatalogId { get; set; }

        public bool ShowInFullMenu { get; set; }

        public bool ShowInMainContent { get; set; }

        public bool ShowInQuickMenu { get; set; }

        public bool ShowNameExt { get; set; }

        public string TemplateCode { get; set; }
    }

    public class VGSLoadEntCatalogCatalogRichDescListDto
    {
        public string Description { get; set; }

        public string IconName { get; set; }

        public string LangISO { get; set; }
    }

    public class VGSNodeDto
    {
        public bool AuthNeeded { get; set; }

        public string BackgroundColor { get; set; }

        public string ButtonDisplayType { get; set; }

        public string CatalogCode { get; set; }

        public string CatalogId { get; set; }

        public string CatalogName { get; set; }

        public string CatalogNameExt { get; set; }

        public int CatalogType { get; set; }

        public string EntityId { get; set; }

        public string EntityType { get; set; }

        public int FlowType { get; set; }

        public string ForegroundColor { get; set; }

        public string IconName { get; set; }

        public DateTime? LastUpdate { get; set; }

        public List<VGSEventNodeDto> Nodes { get; set; }

        public string ParentCatalogId { get; set; }

        public int PriorityOrder { get; set; }

        public string ProfilePictureId { get; set; }

        public string RootCatalogId { get; set; }

        public bool ShowInFullMenu { get; set; }

        public bool ShowInMainContent { get; set; }

        public bool ShowInQuickMenu { get; set; }

        public bool ShowNameExt { get; set; }

        public string TemplateCode { get; set; }
    }

    public class VGSEventNodeDto
    {
        public bool AuthNeeded { get; set; }

        public string BackgroundColor { get; set; }

        public string ButtonDisplayType { get; set; }

        public string CatalogCode { get; set; }

        public string CatalogId { get; set; }

        public string CatalogName { get; set; }

        public string CatalogNameExt { get; set; }

        public int CatalogType { get; set; }

        public string EntityId { get; set; }

        public string EntityType { get; set; }

        public int FlowType { get; set; }

        public string ForegroundColor { get; set; }

        public string IconName { get; set; }

        public DateTime? LastUpdate { get; set; }

        public string ParentCatalogId { get; set; }

        public int PriorityOrder { get; set; }

        public string ProfilePictureId { get; set; }

        public string RootCatalogId { get; set; }

        public bool ShowInFullMenu { get; set; }

        public bool ShowInMainContent { get; set; }

        public bool ShowInQuickMenu { get; set; }

        public bool ShowNameExt { get; set; }

        public string TemplateCode { get; set; }
    }

    public class VGSLoadEntCatalogHeaderDto
    {
        public string EntityId { get; set; }
        public int EntityType { get; set; }
        public DateTime LastUpdate { get; set; }
    }

    public class VGSHeaderDto
    {
        public string ClientVersion { get; set; }
        public int ETime { get; set; }
        public string RequestCode { get; set; }
        public int ServerId { get; set; }

        public string Session { get; set; }

        public int StatusCode { get; set; }

        [JsonProperty("SystemTimestamp")]
        public DateTime SystemTimeStamp { get; set; }

        [JsonProperty("Ver")]
        public string Version { get; set; }

    }

    public class VGSPerformanceResultDto
    {
        public VGSPerformanceAnswerDto Answer { get; set; }
        public VGSHeaderDto Header { get; set; }
    }

    public class VGSPerformanceAnswerDto
    {
        public VGSPerformanceSearchDto Search { get; set; }
    }

    public class VGSPerformanceSearchDto
    {
        public List<VGSPerformanceDto> PerformanceList { get; set; }
    }

    public class VGSPerformanceDto
    {
        public string EventId { get; set; }
        public string EventName { get; set; }
        public string PerformanceId { get; set; }
        public string PerformanceDesc { get; set; }
        public DateTime AdmDateTimeFrom { get; set; }
        public DateTime AdmDateTimeTo { get; set; }
        public DateTime DateTimeFrom { get; set; }
        public DateTime DateTimeTo { get; set; }
    }

    public class VGSProductResultDto
    {
        public VGSProductAnswerDto Answer { get; set; }
        public VGSHeaderDto Header { get; set; }
    }

    public class VGSProductAnswerDto
    {
        public VGSSellableProductsDto GetSellableProducts { get; set; }
    }

    public class VGSSellableProductsDto
    {
        public string PerformanceId { get; set; }

        public List<VGSProductDto> ProductList { get; set; }
    }

    public class VGSProductDto
    {
        public decimal DisplayFacePrice { get; set; }

        public decimal DisplayPrice { get; set; }

        public decimal FacePrice { get; set; }

        public decimal Price { get; set; }

        public string ProductCode { get; set; }

        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductNameExt { get; set; }

        public string SeatCategoryCode { get; set; }

        public string SeatCategoryId { get; set; }

        public string SeatCategoryName { get; set; }

        public int SeatQuantityFree { get; set; }

        public int SeatQuantityMax { get; set; }
    }

    public class VGSShoppingCartResultDto
    {
        public VGSShoppingCartAnswerDto Answer { get; set; }
        public VGSHeaderDto Header { get; set; }
    }

    public class VGSShoppingCartAnswerDto
    {
        public VGSShoppingCartDto ShopCart { get; set; }
    }

    public class VGSShoppingCartDto
    {
        public string ShopCartId { get; set; }
        public List<VGSShoppingCartItemDto> Items { get; set; }
    }

    public class VGSShoppingCartItemDto
    {
        public string ProductCode { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }
    }

    public class VGSService : IVGSService
    {
        private const int SuccessStatus = 1;
        private const int FailedStatus = 0;
        private const string Failed = "Failed";
        private const string ApiUrl = "https://snappstagingweb.meraas.ae/";
        private const string WorkstationId = "AB95397F-F8D9-3128-04CA-017D4CDE5A57";
        private const string ApiKey = "T8JC5B7DW6QEEZVJJ0GY33S0GWB3VH1UDTXBBB6YP11BWH9SQW";
        private const string CatalogId = "16EC62F7-E5AC-5ECA-28FB-017BE91790DF";
        private const string SaleChannelId = "B6668F6A-E429-EAC6-2FA3-017A19D32C91";

        //private const string Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJTTlAiLCJpYXQiOjE2MDk0NTkyMDAsImV4cCI6MTY3Mjc5MDQwMCwiY2xpIjoiQVBJIiwid2lkIjoiQUI5NTM5N0YtRjhEOS0zMTI4LTA0Q0EtMDE3RDRDREU1QTU3In0.r8ZSmDObV6rBaAa3QFihkV4TOks6o2CbLNuf2hzH4QQ";
        private const string Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJTTlAiLCJpYXQiOjE1NTgzODQxMjEsImV4cCI6MTY3Mjc5MDQwMCwiY2xpIjoiQVBJIiwid2lkIjoiQUI5NTM5N0YtRjhEOS0zMTI4LTA0Q0EtMDE3RDRDREU1QTU3In0.yXpHAOikmGErenWD35NSsxhd8l8PDDPm_lC4F33YaNc";

        public async Task<RaynaBookingDetails> BookingAsync(DateTime date, string eventId, string productId, string time, string timeSlotId, int numberOfPax, string bookingId)
        {
            var raynaBookingDetails = new RaynaBookingDetails();
            try
            {
                var raynaTimeSlotList = await CheckAvailabilityAsync(date, eventId, productId, numberOfPax);

                if (raynaTimeSlotList.SupplierTimeSlots.Count() > 0)
                {
                    var selectedDateTime = Convert.ToDateTime(date.Date.ToString("yyyy-MM-dd") + " " + time);
                    var selectedTimeSlot = raynaTimeSlotList.SupplierTimeSlots.SingleOrDefault(s => s.StratTime <= selectedDateTime &&
                    s.EndTime >= selectedDateTime &&
                    s.TimeSlotId == timeSlotId);

                    if (!string.IsNullOrEmpty(selectedTimeSlot.TimeSlotId))
                    {
                        var httpClient = new HttpClient();
                        httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                        httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

                        var url = ApiUrl + "service?format=json&cmd=SHOPCART";

                        var product = new
                        {
                            Product = new
                            {
                                ProductId = productId
                            },
                            QuantityDelta = numberOfPax,
                            PerformanceIDs = timeSlotId
                        };

                        var postData = JsonConvert.SerializeObject(new
                        {
                            Header = new
                            {
                                WorkstationId = WorkstationId,
                                Token = Token
                            },
                            Request = new
                            {
                                Command = "AddToCart",
                                ShopCartId = string.IsNullOrEmpty(bookingId) ? string.Empty : bookingId,
                                FillApplicablePromoList = false,
                                AddToCart = new
                                {
                                    ItemList = new object[] { product }
                                }
                            }
                        });
                        var content = new StringContent(postData, Encoding.UTF8, "application/json");
                        HttpResponseMessage response = await httpClient.PostAsync(url, content);

                        string body = string.Empty;
                        if (response.IsSuccessStatusCode)
                        {
                            body = await response.Content.ReadAsStringAsync();

                            var vgsShoppingCartResult = JsonConvert.DeserializeObject<VGSShoppingCartResultDto>(body);


                            foreach (var vgsShoppingCartItem in vgsShoppingCartResult.Answer.ShopCart.Items)
                            {
                                raynaBookingDetails.SupplierTicketDetails.Add(
                                    new SupplierTicketDetails
                                    {
                                        ProductCode = vgsShoppingCartItem.ProductCode,
                                        ProdctName = vgsShoppingCartItem.ProductName,
                                        NoOfAdult = vgsShoppingCartItem.Quantity,
                                        EventId = selectedTimeSlot.EventId,
                                        StartTime = selectedTimeSlot.StratTime,
                                        EndTime = selectedTimeSlot.EndTime 
                                    });
                            }
                            raynaBookingDetails.SupplierConfirmationNumber = vgsShoppingCartResult.Answer.ShopCart.ShopCartId;
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
            catch (Exception ex)
            {
                raynaBookingDetails.Status = FailedStatus;
                raynaBookingDetails.ErrorMessage = ex.Message;

                return raynaBookingDetails;
            }
        }

        public async Task<string> CancelBookingAsync(string bookingReference, string bookingId)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

            var url = ApiUrl + "service?format=json&cmd=SHOPCART";

            var postData = JsonConvert.SerializeObject(new
            {
                Header = new
                {
                    WorkstationId = WorkstationId,
                    Token = Token
                },
                Request = new
                {
                    Command = "EmptyShopCart",
                    ShopCartId = bookingId,
                    EmptyShopCart = new
                    {
                        HoldReleaseIfNeeded = true
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
            return body;
        }

        //public async Task<RaynaTimeSlotList> CheckAvailabilityAsync(DateTime date, string productId, int numberOfPax)
        //{
        //    var raynaTimeSlotList = new RaynaTimeSlotList();
        //    var supplierTimeSlots = new List<SupplierTimeSlots>();

        //    List<string> eventTypes = new List<string>();
        //    List<VGSPerformanceDto> performances = new List<VGSPerformanceDto>();

        //    try
        //    {
        //        var httpClient = new HttpClient();
        //        httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        //        httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

        //        var url = ApiUrl + "service?format=json&cmd=CATALOG";

        //        var postData = JsonConvert.SerializeObject(new
        //        {
        //            Header = new
        //            {
        //                WorkstationId = WorkstationId,
        //                Token = Token
        //            },
        //            Request = new
        //            {
        //                Command = "LoadEntCatalog",
        //                LoadEntCatalog = new
        //                {
        //                    CatalogId = CatalogId
        //                }
        //            }
        //        });

        //        var content = new StringContent(postData, Encoding.UTF8, "application/json");
        //        HttpResponseMessage response = await httpClient.PostAsync(url, content);


        //        string body = string.Empty;
        //        if (response.IsSuccessStatusCode)
        //        {
        //            body = await response.Content.ReadAsStringAsync();
        //            var vgsCatalogResult = JsonConvert.DeserializeObject<VGSCatalogResultDto>(body);

        //            foreach (VGSNodeDto productFamily in vgsCatalogResult.Answer.LoadEntCatalog.Catalog.Nodes)
        //            {
        //                foreach (var eventNode in productFamily.Nodes)
        //                {
        //                    if (!eventTypes.Contains(eventNode.EntityId))
        //                        eventTypes.Add(eventNode.EntityId);
        //                }
        //            }

        //            if (eventTypes.Count > 0)
        //            {
        //                var fromDate = date;

        //                foreach (string eventTypeId in eventTypes)
        //                {
        //                    url = ApiUrl + "service?format=json&cmd=PERFORMANCE";

        //                    postData = JsonConvert.SerializeObject(new
        //                    {
        //                        Header = new
        //                        {
        //                            WorkstationId = WorkstationId,
        //                            Token = Token
        //                        },
        //                        Request = new
        //                        {
        //                            Command = "Search",
        //                            Search = new
        //                            {
        //                                SearchRecap = new { PagePos = 1, RecordPerPage = 999 },
        //                                EventId = eventTypeId,
        //                                FromDateTime = fromDate.ToString("yyyy-MM-dd") + "T00:00:00",
        //                                ToDateTime = fromDate.ToString("yyyy-MM-dd") + "T23:59:59",
        //                                SellableOnly = "true"
        //                            }
        //                        }
        //                    });

        //                    content = new StringContent(postData, Encoding.UTF8, "application/json");
        //                    response = await httpClient.PostAsync(url, content);


        //                    body = string.Empty;
        //                    if (response.IsSuccessStatusCode)
        //                    {
        //                        body = await response.Content.ReadAsStringAsync();
        //                        var vgsPerformanceResult = JsonConvert.DeserializeObject<VGSPerformanceResultDto>(body);

        //                        if (vgsPerformanceResult.Answer.Search.PerformanceList != null)
        //                        {
        //                            foreach (var performance in vgsPerformanceResult.Answer.Search.PerformanceList)
        //                            {
        //                                var currentPerformance = performances.FirstOrDefault(p => p.PerformanceId == performance.PerformanceId);
        //                                if (currentPerformance == null)
        //                                {
        //                                    performances.Add(new VGSPerformanceDto { EventId = performance.EventId, EventName = performance.EventName, PerformanceId = performance.PerformanceId, PerformanceDesc = performance.PerformanceDesc, AdmDateTimeFrom = performance.AdmDateTimeFrom, AdmDateTimeTo = performance.AdmDateTimeTo, DateTimeFrom = performance.DateTimeFrom, DateTimeTo = performance.DateTimeTo });
        //                                }
        //                            }
        //                        }
        //                    }
        //                }

        //                if (performances.Count > 0)
        //                {
        //                    foreach (var performance in performances)
        //                    {
        //                        postData = JsonConvert.SerializeObject(new
        //                        {
        //                            Header = new
        //                            {
        //                                WorkstationId = WorkstationId,
        //                                Token = Token
        //                            },
        //                            Request = new
        //                            {
        //                                Command = "GetSellableProducts",
        //                                GetSellableProducts = new
        //                                {
        //                                    PerformanceId = performance.PerformanceId,
        //                                    SaleChannelId = SaleChannelId
        //                                }
        //                            }
        //                        });

        //                        content = new StringContent(postData, Encoding.UTF8, "application/json");
        //                        response = await httpClient.PostAsync(url, content);

        //                        if (response.IsSuccessStatusCode)
        //                        {
        //                            body = await response.Content.ReadAsStringAsync();
        //                            var vgsProductResult = JsonConvert.DeserializeObject<VGSProductResultDto>(body);

        //                            if (vgsProductResult.Answer.GetSellableProducts.ProductList != null)
        //                            {
        //                                foreach (var vgsProduct in vgsProductResult.Answer.GetSellableProducts.ProductList)
        //                                {
        //                                    if (vgsProduct.ProductId == productId && vgsProduct.SeatQuantityFree >= numberOfPax)
        //                                    {
        //                                        supplierTimeSlots.Add(new SupplierTimeSlots { EventId = performance.EventId, TimeSlotId = performance.PerformanceId, ResourceId = vgsProduct.ProductId, Available = vgsProduct.SeatQuantityFree, AdultPrice = vgsProduct.DisplayPrice, StratTime = performance.AdmDateTimeFrom, EndTime = performance.AdmDateTimeTo });
        //                                    }
        //                                }
        //                            }
        //                        }
        //                    }
        //                }

        //                if (supplierTimeSlots.Count > 0)
        //                {
        //                    raynaTimeSlotList.Status = SuccessStatus;
        //                    raynaTimeSlotList.SupplierTimeSlots = supplierTimeSlots;

        //                    return raynaTimeSlotList;
        //                }
        //            }

        //            raynaTimeSlotList.Status = FailedStatus;
        //            raynaTimeSlotList.ErrorMessage = Failed;

        //            return raynaTimeSlotList;
        //        }


        //        raynaTimeSlotList.Status = FailedStatus;
        //        raynaTimeSlotList.ErrorMessage = Failed;

        //        return raynaTimeSlotList;
        //    }
        //    catch (Exception ex)
        //    {
        //        raynaTimeSlotList.Status = FailedStatus;
        //        raynaTimeSlotList.ErrorMessage = ex.Message;

        //        return raynaTimeSlotList;
        //    }
        //}

        public async Task<RaynaTimeSlotList> CheckAvailabilityAsync(DateTime date, string eventId, string productId, int numberOfPax)
        {
            var raynaTimeSlotList = new RaynaTimeSlotList();
            var supplierTimeSlots = new List<SupplierTimeSlots>();

            List<string> eventTypes = new List<string>();
            List<VGSPerformanceDto> performances = new List<VGSPerformanceDto>();

            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

                string body = string.Empty;
                var fromDate = date;


                var url = ApiUrl + "service?format=json&cmd=PERFORMANCE";

                var postData = JsonConvert.SerializeObject(new
                {
                    Header = new
                    {
                        WorkstationId = WorkstationId,
                        Token = Token
                    },
                    Request = new
                    {
                        Command = "Search",
                        Search = new
                        {
                            SearchRecap = new { PagePos = 1, RecordPerPage = 999 },
                            EventId = eventId,
                            FromDateTime = fromDate.ToString("yyyy-MM-dd") + "T00:00:00",
                            ToDateTime = fromDate.ToString("yyyy-MM-dd") + "T23:59:59",
                            SellableOnly = "true"
                        }
                    }
                });

                var content = new StringContent(postData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                body = string.Empty;
                if (response.IsSuccessStatusCode)
                {
                    body = await response.Content.ReadAsStringAsync();
                    var vgsPerformanceResult = JsonConvert.DeserializeObject<VGSPerformanceResultDto>(body);

                    if (vgsPerformanceResult.Answer.Search.PerformanceList != null)
                    {
                        foreach (var performance in vgsPerformanceResult.Answer.Search.PerformanceList)
                        {
                            var currentPerformance = performances.FirstOrDefault(p => p.PerformanceId == performance.PerformanceId);
                            if (currentPerformance == null)
                            {
                                performances.Add(new VGSPerformanceDto { EventId = performance.EventId, EventName = performance.EventName, PerformanceId = performance.PerformanceId, PerformanceDesc = performance.PerformanceDesc, AdmDateTimeFrom = performance.AdmDateTimeFrom, AdmDateTimeTo = performance.AdmDateTimeTo, DateTimeFrom = performance.DateTimeFrom, DateTimeTo = performance.DateTimeTo });
                            }
                        }
                    }
                }


                if (performances.Count > 0)
                {
                    foreach (var performance in performances)
                    {
                        postData = JsonConvert.SerializeObject(new
                        {
                            Header = new
                            {
                                WorkstationId = WorkstationId,
                                Token = Token
                            },
                            Request = new
                            {
                                Command = "GetSellableProducts",
                                GetSellableProducts = new
                                {
                                    PerformanceId = performance.PerformanceId,
                                    SaleChannelId = SaleChannelId
                                }
                            }
                        });

                        content = new StringContent(postData, Encoding.UTF8, "application/json");
                        response = await httpClient.PostAsync(url, content);

                        if (response.IsSuccessStatusCode)
                        {
                            body = await response.Content.ReadAsStringAsync();
                            var vgsProductResult = JsonConvert.DeserializeObject<VGSProductResultDto>(body);

                            if (vgsProductResult.Answer.GetSellableProducts.ProductList != null)
                            {
                                foreach (var vgsProduct in vgsProductResult.Answer.GetSellableProducts.ProductList)
                                {
                                    if (vgsProduct.ProductId == productId && vgsProduct.SeatQuantityFree >= numberOfPax)
                                    {
                                        supplierTimeSlots.Add(new SupplierTimeSlots { EventId = performance.EventId, TimeSlotId = performance.PerformanceId, ResourceId = vgsProduct.ProductId, Available = vgsProduct.SeatQuantityFree, AdultPrice = vgsProduct.DisplayPrice, StratTime = performance.AdmDateTimeFrom, EndTime = performance.AdmDateTimeTo });
                                    }
                                }
                            }
                        }
                    }
                }

                if (supplierTimeSlots.Count > 0)
                {
                    raynaTimeSlotList.Status = SuccessStatus;
                    raynaTimeSlotList.SupplierTimeSlots = supplierTimeSlots;

                    return raynaTimeSlotList;
                }


                raynaTimeSlotList.Status = FailedStatus;
                raynaTimeSlotList.ErrorMessage = Failed;

                return raynaTimeSlotList;
            }
            catch (Exception ex)
            {
                raynaTimeSlotList.Status = FailedStatus;
                raynaTimeSlotList.ErrorMessage = ex.Message;

                return raynaTimeSlotList;
            }
        }

        public async Task<RaynaTourList> GetProductListAsync()
        {
            var raynaTourList = new RaynaTourList();
            var supplierTourList = new List<SupplierTourList>();

            List<string> eventTypes = new List<string>();
            List<VGSPerformanceDto> performances = new List<VGSPerformanceDto>();

            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                //httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

                var url = ApiUrl + "service?format=json&cmd=CATALOG";
                //            
                var postData = JsonConvert.SerializeObject(new
                {
                    Header = new
                    {
                        WorkstationId = WorkstationId,
                        Token = Token
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
                    var vgsCatalogResult = JsonConvert.DeserializeObject<VGSCatalogResultDto>(body);

                    foreach (VGSNodeDto productFamily in vgsCatalogResult.Answer.LoadEntCatalog.Catalog.Nodes)
                    {
                        foreach (var eventNode in productFamily.Nodes)
                        {
                            if (!eventTypes.Contains(eventNode.EntityId))
                                eventTypes.Add(eventNode.EntityId);
                        }
                    }

                    if (eventTypes.Count > 0)
                    {
                        //eventTypes = eventTypes.Take(1).ToList();

                        var fromDate = DateTime.Now.Date;
                        var toDate = DateTime.Now.Date.AddDays(1);

                        foreach (string eventTypeId in eventTypes)
                        {
                            url = ApiUrl + "service?format=json&cmd=PERFORMANCE";

                            //            
                            postData = JsonConvert.SerializeObject(new
                            {
                                Header = new
                                {
                                    WorkstationId = WorkstationId,
                                    Token = Token
                                },
                                Request = new
                                {
                                    Command = "Search",
                                    Search = new
                                    {
                                        SearchRecap = new { PagePos = 1, RecordPerPage = 999 },
                                        EventId = eventTypeId,
                                        FromDateTime = fromDate.ToString("yyyy-MM-dd") + "T00:00:00",
                                        ToDateTime = fromDate.ToString("yyyy-MM-dd") + "T23:59:59",
                                        SellableOnly = "true"
                                    }
                                }
                            });

                            content = new StringContent(postData, Encoding.UTF8, "application/json");
                            response = await httpClient.PostAsync(url, content);

                            body = string.Empty;
                            if (response.IsSuccessStatusCode)
                            {
                                body = await response.Content.ReadAsStringAsync();
                                var vgsPerformanceResult = JsonConvert.DeserializeObject<VGSPerformanceResultDto>(body);

                                if (vgsPerformanceResult.Answer.Search.PerformanceList != null)
                                {
                                    foreach (var performance in vgsPerformanceResult.Answer.Search.PerformanceList)
                                    {
                                        var currentPerformance = performances.FirstOrDefault(p => p.PerformanceId == performance.PerformanceId);
                                        if (currentPerformance == null)
                                        {
                                            performances.Add(new VGSPerformanceDto { EventId = performance.EventId, EventName = performance.EventName, PerformanceId = performance.PerformanceId, PerformanceDesc = performance.PerformanceDesc });
                                        }
                                    }
                                }
                            }
                        }
                        if (performances.Count > 0)
                        {
                            foreach (var performance in performances)
                            {
                                postData = JsonConvert.SerializeObject(new
                                {
                                    Header = new
                                    {
                                        WorkstationId = WorkstationId,
                                        Token = Token
                                    },
                                    Request = new
                                    {
                                        Command = "GetSellableProducts",
                                        GetSellableProducts = new
                                        {
                                            PerformanceId = performance.PerformanceId,
                                            SaleChannelId = SaleChannelId
                                        }
                                    }
                                });

                                content = new StringContent(postData, Encoding.UTF8, "application/json");
                                response = await httpClient.PostAsync(url, content);

                                if (response.IsSuccessStatusCode)
                                {
                                    body = await response.Content.ReadAsStringAsync();
                                    var vgsProductResult = JsonConvert.DeserializeObject<VGSProductResultDto>(body);

                                    if (vgsProductResult.Answer.GetSellableProducts.ProductList != null)
                                    {
                                        foreach (var vgsProduct in vgsProductResult.Answer.GetSellableProducts.ProductList)
                                        {
                                            var currentProduct = supplierTourList.FirstOrDefault(p => p.ResourceId == vgsProduct.ProductId && p.ProductCode == vgsProduct.ProductCode && p.ProductName == vgsProduct.ProductName && p.ProductPrice == vgsProduct.DisplayPrice.ToString() && p.ProductDescription == vgsProduct.ProductNameExt);
                                            if (currentProduct == null)
                                            {
                                                supplierTourList.Add(new SupplierTourList { EventId = performance.EventId, ProductCode = vgsProduct.ProductCode, ProductName = vgsProduct.ProductName, ProductPrice = vgsProduct.DisplayPrice.ToString(), ProductDescription = vgsProduct.ProductNameExt, ResourceId = vgsProduct.ProductId });
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        if (supplierTourList.Count > 0)
                        {
                            raynaTourList.Status = SuccessStatus;
                            raynaTourList.SupplierTourList = supplierTourList;

                            return raynaTourList;
                        }
                    }

                    raynaTourList.Status = FailedStatus;
                    raynaTourList.ErrorMessage = Failed;

                    return raynaTourList;
                }

                raynaTourList.Status = FailedStatus;
                raynaTourList.ErrorMessage = Failed;

                return raynaTourList;
            }
            catch (Exception ex)
            {
                raynaTourList.Status = FailedStatus;
                raynaTourList.ErrorMessage = ex.Message;

                return raynaTourList;
            }
        }
    }
}
