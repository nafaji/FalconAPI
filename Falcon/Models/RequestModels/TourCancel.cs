using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rayna.ApiIntegration.Models.RequestModels
{
    public class TourCancel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ApiKey { get; set; }
        public string ReferenceNo { get; set; }
        public string BookingId { get; set; }
        public string SupplierConfirmationNumber { get; set; }
        public int AgentId { get; set; }
        public string Supplier { get; set; }
        public string Website { get; set; }
    }
}
