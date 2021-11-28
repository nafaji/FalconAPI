namespace Rayna.ApiIntegration.Models.ResponseModels
{
    public class SupplierTourList
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductPrice { get; set; }
        public string ProductTax { get; set; }
        public bool IsTimeSlot { get; set; }
        public string EventId { get; set; }
        public string ResourceId { get; set; }
        public string Note { get; set; }

    }
}
