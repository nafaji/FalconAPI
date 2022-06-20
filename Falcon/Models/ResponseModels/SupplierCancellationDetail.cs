using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rayna.ApiIntegration.Models.ResponseModels
{
    public class SupplierCancellationDetail
    {
        public string CancellationId { get; set; } // optional
        public int CancellationStatus { get; set; } // 1=cancellationSuccess, 0= CancellationFail
        public string Message { get; set; }  // optional
    }
}
