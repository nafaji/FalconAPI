using System.Collections.Generic;

namespace Rayna.ApiIntegration.Models.ResponseModels
{
    public class RaynaBookingDetails
    {
        public string SupplierConfirmationNumber { get; set; }
        public int Status { get; set; } // 1=success , 0 = fail
        public string ErrorMessage { get; set; }
        public List<SupplierTicketDetails> SupplierTicketDetails { get; set; }

    }
}
