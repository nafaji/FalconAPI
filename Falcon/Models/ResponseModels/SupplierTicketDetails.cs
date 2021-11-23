using System;

namespace Rayna.APIIntegration.Models.ResponseModels
{
    public class SupplierTicketDetails
    {
        public string ProductCode { get; set; }
        public string ProdctName { get; set; }
        public string EventId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Barcode { get; set; }
        public int NoOfAdult { get; set; }
        public int NoOfChild { get; set; }
        public int NoOfInfant { get; set; }
        public int NoOfSeniorCitizen { get; set; }

    }
}
