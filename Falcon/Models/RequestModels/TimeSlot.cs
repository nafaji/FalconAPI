using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rayna.ApiIntegration.Models.RequestModels
{
    public class TimeSlot
    {
        public string EventTypeId { get; set; }

        public string ProductCode { get; set; }
        public string ResourceId { get; set; }
        public DateTime TravelDate { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int AgentId { get; set; }
        public string ApiKey { get; set; }
        public string VariantsId { get; set; }

        public int NoOfPax { get; set; }
    }
}
