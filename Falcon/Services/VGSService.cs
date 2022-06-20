using Newtonsoft.Json;
using Rayna.ApiIntegration.Models.ResponseModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
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

    public class VGSShopCartResultDto
    {
        public VGSShopCartAnswerDto Answer { get; set; }
        public VGSHeaderDto Header { get; set; }
    }

    public class VGSShopCartAnswerDto
    {
        public VGSShopCartDto ShopCart { get; set; }
    }

    public class VGSShopCartDto
    {
        public string ShopCartId { get; set; }

        public int TotalQuantity { get; set; }

        public decimal SubTotal { get; set; }

        public decimal TotalTax { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal TotalDue { get; set; }

        public List<VGSShopCartItemDto> Items { get; set; }

        public VGSPaymentDto Payments { get; set; }
    }

    public class VGSShopCartItemDto
    {
        public string ProductCode { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public List<VGSPerformanceDto> PerformanceList { get; set; }
    }


    public class VGSPaymentDto
    {
        public decimal Balance { get; set; }

        public decimal Due { get; set; }

        public decimal Tendered { get; set; }
    }

    public class VGSValidateShopCartResultDto
    {
        public VGSValidateShopCartAnswerDto Answer { get; set; }
        public VGSHeaderDto Header { get; set; }
    }

    public class VGSValidateShopCartAnswerDto
    {
        public VGSShopCartDto ShopCart { get; set; }
        public ValidateShopCartDto ValidateShopCart { get; set; }
    }

    public class ValidateShopCartDto
    {
        public bool RestrictValidPayments { get; set; }
    }

    public class VGSTransactionResultDto
    {
        public VGSTransactionAnswerDto Answer { get; set; }
        public VGSHeaderDto Header { get; set; }
    }

    public class VGSTransactionAnswerDto
    {
        public VGSPostTransactionDto PostTransaction { get; set; }
    }

    public class VGSPostTransactionDto
    {
        public VGSFullTransactionDto FullTransaction { get; set; }

        public VGSPostTransactionRecapDto PostTransactionRecap { get; set; }
    }

    public class VGSFullTransactionDto
    {
        public int ItemCount { get; set; }

        public string LocationId { get; set; }

        public string LocationName { get; set; }

        public int MediaCount { get; set; }

        public List<VGSMediaDto> MediaList { get; set; }

        public decimal PaidAmount { get; set; }

        public decimal PaidTax { get; set; }

        public string PriorTransactionId { get; set; }

        public string SaleId { get; set; }

        public int TicketCount { get; set; }

        public List<VGSTicketDto> TicketList { get; set; }
    }

    public class VGSMediaDto
    {
        public string MainProductId { get; set; }

        public string MainProductCode { get; set; }

        public string MainProductName { get; set; }

        public string MainTicketEventId { get; set; }

        public string MainTicketPerformanceId { get; set; }

        public DateTime MainTicketPerformanceDateTimeFrom { get; set; }

        public int MainTicketGroupQuantity { get; set; }

        public List<VGSMediaCodeDto> MediaCodeList { get; set; }
    }

    public class VGSMediaCodeDto
    {
        public string MediaId { get; set; }

        public string MediaCode { get; set; }
    }

    public class VGSTicketDto
    {
        public string ProductId { get; set; }
        public string ProductCode { get; set; }

        public List<VGSTicketPerformanceDto> PerformanceList { get; set; }
    }

    public class VGSTicketPerformanceDto
    {
        public VGSPerformanceDto Performance { get; set; }

        public string SeatCategoryId { get; set; }

        public string SeatCategoryName { get; set; }
    }

    public class VGSPostTransactionRecapDto
    {
        public string PahRelativeDownloadUrl { get; set; }

        public string SaleCode { get; set; }

        public string SaleId { get; set; }

        public string TransactionId { get; set; }
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
        private const string AccountId = "CC3FEB4E-DBBB-4AD7-2677-017A382DC874";
        private const string PaymentMethodId = "A0837314-81C3-CE88-2C47-017A15EEEF2D";

        //private const string Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJTTlAiLCJpYXQiOjE2MDk0NTkyMDAsImV4cCI6MTY3Mjc5MDQwMCwiY2xpIjoiQVBJIiwid2lkIjoiQUI5NTM5N0YtRjhEOS0zMTI4LTA0Q0EtMDE3RDRDREU1QTU3In0.r8ZSmDObV6rBaAa3QFihkV4TOks6o2CbLNuf2hzH4QQ";
        private const string Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJTTlAiLCJpYXQiOjE1NTgzODQxMjEsImV4cCI6MTY3Mjc5MDQwMCwiY2xpIjoiQVBJIiwid2lkIjoiQUI5NTM5N0YtRjhEOS0zMTI4LTA0Q0EtMDE3RDRDREU1QTU3In0.yXpHAOikmGErenWD35NSsxhd8l8PDDPm_lC4F33YaNc";

        private async Task<List<string>> GetCatalogsAsync()
        {
            var url = ApiUrl + "service?format=json&cmd=CATALOG";
            List<string> eventTypes = new List<string>();

            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

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
                }
            }
            catch (Exception ex)
            {
                return eventTypes;
            }

            return eventTypes;
        }

        private async Task<List<VGSPerformanceDto>> GetPerformancesAsync(string eventTypeId, DateTime fromDate, string time)
        {
            var url = ApiUrl + "service?format=json&cmd=PERFORMANCE";
            List<VGSPerformanceDto> performances = new List<VGSPerformanceDto>();
            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

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
                            EventId = eventTypeId,
                            FromDateTime = fromDate.ToString("yyyy-MM-dd") + (string.IsNullOrEmpty(time) ? "T00:00:00" : "T" + time),
                            ToDateTime = fromDate.ToString("yyyy-MM-dd") + "T23:59:59",
                            SellableOnly = "true"
                        }
                    }
                });

                var content = new StringContent(postData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                string body = string.Empty;
                if (response.IsSuccessStatusCode)
                {
                    body = await response.Content.ReadAsStringAsync();
                    var vgsPerformanceResult = JsonConvert.DeserializeObject<VGSPerformanceResultDto>(body);

                    if (vgsPerformanceResult.Answer.Search.PerformanceList != null)
                    {
                        foreach (var performance in vgsPerformanceResult.Answer.Search.PerformanceList)
                        {
                            performances.Add(new VGSPerformanceDto
                            {
                                EventId = performance.EventId,
                                EventName = performance.EventName,
                                PerformanceId = performance.PerformanceId,
                                PerformanceDesc = performance.PerformanceDesc,
                                DateTimeFrom = performance.DateTimeFrom,
                                DateTimeTo = performance.DateTimeTo,
                                AdmDateTimeFrom = performance.AdmDateTimeFrom,
                                AdmDateTimeTo = performance.AdmDateTimeTo
                            });
                        }
                    }
                }

                return performances;
            }
            catch (Exception ex)
            {
                return performances;
            }
        }

        private async Task<List<SupplierTourList>> GetSellableProductsAsync(VGSPerformanceDto performance)
        {
            var url = ApiUrl + "service?format=json&cmd=PERFORMANCE";
            var supplierTourList = new List<SupplierTourList>();
            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

                var postData = JsonConvert.SerializeObject(new
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
                            //,
                            //TagNames = "RAYNA"
                        }
                    }
                });

                Thread.Sleep(1);

                var content = new StringContent(postData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                string body = string.Empty;

                if (response.IsSuccessStatusCode)
                {
                    body = await response.Content.ReadAsStringAsync();
                    var vgsProductResult = JsonConvert.DeserializeObject<VGSProductResultDto>(body);

                    if (vgsProductResult.Answer.GetSellableProducts.ProductList != null)
                    {
                        foreach (var vgsProduct in vgsProductResult.Answer.GetSellableProducts.ProductList)
                        {
                            supplierTourList.Add(new SupplierTourList { ProductCode = vgsProduct.ProductCode, ProductName = vgsProduct.ProductName, ProductDescription = vgsProduct.ProductNameExt, ProductPrice = vgsProduct.DisplayPrice.ToString(), IsTimeSlot = true, ResourceId = vgsProduct.ProductId, EventTypeId = performance.EventId });
                        }
                    }
                }
                return supplierTourList;
            }
            catch (Exception ex)
            {
                return supplierTourList;
            }
        }

        private async Task<List<SupplierTimeSlots>> GetTimeSlotsOfSellableProductAsync(VGSPerformanceDto performance, string productId, int numberOfPax)
        {
            var url = ApiUrl + "service?format=json&cmd=PERFORMANCE";
            var supplierTimeSlots = new List<SupplierTimeSlots>();
            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

                var postData = JsonConvert.SerializeObject(new
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
                            //,
                            //TagNames = "RAYNA"
                        }
                    }
                });

                Thread.Sleep(1);

                var content = new StringContent(postData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                string body = string.Empty;

                if (response.IsSuccessStatusCode)
                {
                    body = await response.Content.ReadAsStringAsync();
                    var vgsProductResult = JsonConvert.DeserializeObject<VGSProductResultDto>(body);

                    if (vgsProductResult.Answer.GetSellableProducts.ProductList != null)
                    {
                        foreach (var vgsProduct in vgsProductResult.Answer.GetSellableProducts.ProductList.Where(p=>p.ProductId == productId && p.SeatQuantityFree >= numberOfPax))
                        {
                            supplierTimeSlots.Add(new SupplierTimeSlots { ResourceId = vgsProduct.ProductId, EventTypeId = performance.EventId, TimeSlotId = performance.PerformanceId, StratTime = performance.DateTimeFrom, EndTime = performance.DateTimeTo, Available = vgsProduct.SeatQuantityFree, AdultPrice = vgsProduct.DisplayPrice });
                        }
                    }
                }
                return supplierTimeSlots;
            }
            catch (Exception ex)
            {
                return supplierTimeSlots;
            }
        }

        private async Task<VGSShopCartResultDto> AddToCartAsync(string productId, string timeSlotId, int numberOfPax, string shopCartId)
        {
            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

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
                        ShopCartId = string.IsNullOrEmpty(shopCartId) ? string.Empty : shopCartId,
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
                    var vgsShoppingCartResult = JsonConvert.DeserializeObject<VGSShopCartResultDto>(body);
                    return vgsShoppingCartResult;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private async Task<VGSValidateShopCartResultDto> ValidateShopCartAsync(string sessionId, string shopCartId)
        {
            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

                var url = ApiUrl + "service?format=json&cmd=SHOPCART";

                var postData = JsonConvert.SerializeObject(new
                {
                    Header = new
                    {
                        Session = sessionId,
                        WorkstationId = WorkstationId,
                        Token = Token
                    },
                    Request = new
                    {
                        Command = "ValidateShopCart",
                        ShopCartId = shopCartId,
                    }
                });

                var content = new StringContent(postData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                string body = string.Empty;
                if (response.IsSuccessStatusCode)
                {
                    body = await response.Content.ReadAsStringAsync();
                    var vgsValidateShopCartResult = JsonConvert.DeserializeObject<VGSValidateShopCartResultDto>(body);
                    return vgsValidateShopCartResult;
                }
                return null;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        

        public async Task<RaynaTourList> GetProductListAsync()
        {
            var raynaTourList = new RaynaTourList();
            var supplierTourList = new List<SupplierTourList>();

            List<string> eventTypes = new List<string>();
            List<VGSPerformanceDto> performances = new List<VGSPerformanceDto>();
            List<VGSPerformanceDto> allPerformances = new List<VGSPerformanceDto>();

            try
            {
                eventTypes = await GetCatalogsAsync();

                if (eventTypes.Count > 0)
                {
                    var fromDate = DateTime.Now.AddDays(1).Date;
                    var time = string.Empty;

                    List<Task<List<VGSPerformanceDto>>> performanceTaskList = new List<Task<List<VGSPerformanceDto>>>();

                    foreach (string eventTypeId in eventTypes)
                    {
                        performanceTaskList.Add(GetPerformancesAsync(eventTypeId, fromDate, time));
                    }

                    await Task.WhenAll(performanceTaskList);

                    foreach (var performanceTask in performanceTaskList)
                    {
                        allPerformances.AddRange(performanceTask.Result);
                    }

                    performances = allPerformances.GroupBy(p => new { p.EventId, p.PerformanceId, p.DateTimeFrom, p.DateTimeTo }).Select(g => g.First()).ToList();

                    if (performances.Count > 0)
                    {
                        List<Task<List<SupplierTourList>>> productTaskList = new List<Task<List<SupplierTourList>>>();

                        foreach (var performance in performances)
                        {
                            productTaskList.Add(GetSellableProductsAsync(performance));
                        }

                        await Task.WhenAll(productTaskList);

                        foreach (var productTask in productTaskList)
                        {
                            if (productTask.Result.Count() > 0)
                            {
                                supplierTourList.AddRange(productTask.Result);
                            }
                        }
                    }

                    if (supplierTourList.Count > 0)
                    {
                        raynaTourList.Status = SuccessStatus;
                        raynaTourList.SupplierTourList = supplierTourList.GroupBy(s => new { s.ProductCode, s.ProductName, s.ProductPrice, s.ProductTax, s.IsTimeSlot, s.EventTypeId, s.ResourceId }).Select(g => g.First()).ToList();

                        return raynaTourList;
                    }
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

        public async Task<RaynaTimeSlotList> CheckAvailabilityAsync(string eventId, DateTime date, string time, string productId, int numberOfPax)
        {
            var raynaTimeSlotList = new RaynaTimeSlotList();
            var supplierTimeSlots = new List<SupplierTimeSlots>();

            List<string> eventTypes = new List<string>();
            List<VGSPerformanceDto> performances = new List<VGSPerformanceDto>();
            List<VGSPerformanceDto> allPerformances = new List<VGSPerformanceDto>();

            try
            {
                if (string.IsNullOrEmpty(eventId))
                    eventTypes = await GetCatalogsAsync();
                else
                    eventTypes.Add(eventId);

                if (eventTypes.Count() > 0)
                {
                    var fromDate = date;
                    List<Task<List<VGSPerformanceDto>>> performanceTaskList = new List<Task<List<VGSPerformanceDto>>>();

                    foreach (string eventTypeId in eventTypes)
                    {
                        performanceTaskList.Add(GetPerformancesAsync(eventTypeId, fromDate, time));
                    }

                    await Task.WhenAll(performanceTaskList);

                    foreach (var performanceTask in performanceTaskList)
                    {
                        allPerformances.AddRange(performanceTask.Result);
                    }

                    performances = allPerformances.GroupBy(p => new { p.EventId, p.PerformanceId, p.DateTimeFrom, p.DateTimeTo }).Select(g => g.First()).ToList();
                }

                if (performances.Count > 0)
                {
                    List<Task<List<SupplierTimeSlots>>> productTimeSlotTaskList = new List<Task<List<SupplierTimeSlots>>>();

                    foreach (var performance in performances)
                    {
                        productTimeSlotTaskList.Add(GetTimeSlotsOfSellableProductAsync(performance, productId, numberOfPax));
                    }

                    await Task.WhenAll(productTimeSlotTaskList);

                    foreach (var productTimeSlotTask in productTimeSlotTaskList)
                    {
                        if (productTimeSlotTask.Result.Count() > 0)
                        {
                            supplierTimeSlots.AddRange(productTimeSlotTask.Result);
                        }
                    }
                }

                if (supplierTimeSlots.Count > 0)
                {
                    raynaTimeSlotList.Status = SuccessStatus;
                    raynaTimeSlotList.SupplierTimeSlots = supplierTimeSlots.GroupBy(s => new { s.EventTypeId, s.TimeSlotId, s.ResourceId, s.StratTime, s.EndTime, s.Available, s.AdultPrice }).Select(g => g.First()).ToList();

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

        public async Task<RaynaBookingDetails> BookingAsync(DateTime date, string eventId, string productId, string time, string timeSlotId, int numberOfPax, string bookingId, string shopCartId)
        {
            var raynaBookingDetails = new RaynaBookingDetails();
            try
            {
                var vgsShopCartResult = await AddToCartAsync(productId, timeSlotId, numberOfPax, shopCartId);

                if (vgsShopCartResult != null)
                {
                    shopCartId = vgsShopCartResult.Answer.ShopCart.ShopCartId;

                    var vgsValidateShopCartResult = await ValidateShopCartAsync(vgsShopCartResult.Header.Session, vgsShopCartResult.Answer.ShopCart.ShopCartId);

                    if (vgsValidateShopCartResult.Header.StatusCode == 200)
                    {
                        var url = ApiUrl + "service?format=json&cmd=TRANSACTION";

                        var httpClient = new HttpClient();
                        httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

                        var paymentMethod = new
                        {
                            PaymentMethodId = PaymentMethodId,
                            PaymentAmount = vgsValidateShopCartResult.Answer.ShopCart.Payments.Due,
                            PaymentType = 8,
                            PaymentStatus = 2,
                            CreditLine = new
                            {
                                Account = new { AccountId = AccountId }
                            }
                        };

                        var postData = JsonConvert.SerializeObject(new
                        {
                            Header = new
                            {
                                Session = vgsValidateShopCartResult.Header.Session,
                                WorkstationId = WorkstationId,
                                Token = Token
                            },
                            Request = new
                            {
                                Command = "PostTransaction",
                                PostTransaction = new
                                {
                                    ShopCartId = shopCartId,
                                    PreparePahDownload = true,
                                    Approved = true,
                                    Paid = true,
                                    Printed = true,
                                    Validated = true,
                                    ReturnFullTransaction = true,
                                    PaymentList = new object[] { paymentMethod }
                                }
                            }
                        });

                        var content = new StringContent(postData, Encoding.UTF8, "application/json");
                        HttpResponseMessage response = await httpClient.PostAsync(url, content);

                        string body = string.Empty;
                        if (response.IsSuccessStatusCode)
                        {
                            body = await response.Content.ReadAsStringAsync();
                            var vgsTransactionResult = JsonConvert.DeserializeObject<VGSTransactionResultDto>(body);
                            foreach (var vgsMedia in vgsTransactionResult.Answer.PostTransaction.FullTransaction.MediaList)
                            {
                                var validatedItem = vgsValidateShopCartResult.Answer.ShopCart.Items.FirstOrDefault(p => p.ProductCode == vgsMedia.MainProductCode);

                                raynaBookingDetails.SupplierTicketDetails.Add(
                                    new SupplierTicketDetails
                                    {
                                        ProductCode = vgsMedia.MainProductCode,
                                        ProdctName = vgsMedia.MainProductName,
                                        NoOfAdult = vgsMedia.MainTicketGroupQuantity,
                                        EventId = vgsMedia.MainTicketEventId,
                                        StartTime = vgsMedia.MainTicketPerformanceDateTimeFrom,
                                        EndTime = validatedItem.PerformanceList[0].DateTimeTo,
                                        Barcode = vgsMedia.MediaCodeList[0].MediaCode
                                    });
                            }
                            raynaBookingDetails.SupplierConfirmationNumber = vgsTransactionResult.Answer.PostTransaction.PostTransactionRecap.SaleId;
                            raynaBookingDetails.SupplierConfirmationCode = vgsTransactionResult.Answer.PostTransaction.PostTransactionRecap.SaleCode;

                            raynaBookingDetails.Status = SuccessStatus;
                            return raynaBookingDetails;

                        }
                    }

                    raynaBookingDetails.Status = FailedStatus;
                    raynaBookingDetails.ErrorMessage = Failed;

                    return raynaBookingDetails;
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

        public async Task<string> CancelBookingAsync(string bookingId, string bookingReference)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            var url = ApiUrl + "service?format=json&cmd=POSTTRANSACTION";

            var postData = JsonConvert.SerializeObject(new
            {
                Header = new
                {
                    WorkstationId = WorkstationId,
                    UserAccountId = AccountId,
                    Token = Token
                },
                Request = new
                {
                    Sale = new
                    {
                        SaleId = bookingId,
                        SaleCode = bookingReference
                    },
                    TransactionType = 14,
                    TransactionReason = 26,
                    SaleFlowType = 1,
                    Approved = true,
                    Paid = true,
                    Encoded = true,
                    Printed = true,
                    Validated = true,
                    Workstation = new
                    {
                        WorkstationId = WorkstationId
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
    }
}
