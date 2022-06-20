using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rayna.ApiIntegration.Models.RequestModels
{
    public class CustomerDetails
    {
        public string EventTypeId { get; set; }
        public string ResourceId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CountryName { get; set; }
        public string Email { get; set; }
        public string MobNo { get; set; }
    }
}
