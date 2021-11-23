using System.Collections.Generic;

namespace Rayna.APIIntegration.Models.ResponseModels
{
    public class RaynaTimeSlotList
    {
        public int Status { get; set; } // 1=success , 0 = fail
        public string ErrorMessage { get; set; }
        public List<SupplierTimeSlots> SupplierTimeSlots { get; set; }
    }
}
