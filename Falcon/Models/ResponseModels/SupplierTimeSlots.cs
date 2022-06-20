using System;

namespace Rayna.ApiIntegration.Models.ResponseModels
{
    public class SupplierTimeSlots
    {
        public string ResourceId { get; set; }  // in case of single id productid save in resourceid
        public string EventTypeId { get; set; } // assign transfer type/paxtype for falcon
        public string TimeSlotId { get; set; }
        public DateTime StratTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Available { get; set; } // available pax
        public decimal AdultPrice { get; set; }
        public decimal ChildPrice { get; set; }
        public bool IsDynamicPrice { get; set; }
    }
}
