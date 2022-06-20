using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rayna.ApiIntegration.Models.RequestModels
{
    public class ProductDetails
    {
        public string EventId { get; set; }
        public string EventTypeId { get; set; }
        public string ResourceId { get; set; }
        public DateTime TravelDate { get; set; }
        public string BookingId { get; set; }
        public string BookingDetailId { get; set; }
        public string SupplierName { get; set; }
        public int SupplierId { get; set; }
        public string StartTime { get; set; }
        public int Adult { get; set; }
        public int Child { get; set; }
        public int Quantity { get; set; }
        public int Infant { get; set; }
        public int Guides { get; set; }
        public bool ChildAsAdult { get; set; }
        public bool InfantRequired { get; set; }
        public bool IsTourGuide { get; set; }
        public string TimeSlotId { get; set; }
        public int SupplierTourId { get; set; }
        public string VariantsId { get; set; }
        public string ProductName { get; set; }
        public string ChildOptionName { get; set; }
        public string ProductId { get; set; }
    }
}
