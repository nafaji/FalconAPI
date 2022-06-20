using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rayna.ApiIntegration.Models.RequestModels
{
    public class Req_RaynaBooking
    {
        public string ReferenceNo { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ApiKey { get; set; }
        public int AgentId { get; set; }
        public string Token { get; set; }
        public string Website { get; set; }

        public string BookingNotes { get; set; }

        public List<ProductDetails> ProductDetails { get; set; }

        public List<CustomerDetails> CustomerDetails { get; set; }

        public Req_RaynaBooking()
        {
            ProductDetails = new List<ProductDetails>();
            CustomerDetails = new List<CustomerDetails>();
        }
    }
}
