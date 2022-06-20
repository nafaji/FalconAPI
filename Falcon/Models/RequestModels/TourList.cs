using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rayna.ApiIntegration.Models.RequestModels
{
    public class TourList
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int AgentId { get; set; }
        public string ApiKey { get; set; }
        public string SupplierName { get; set; }
    }
}
