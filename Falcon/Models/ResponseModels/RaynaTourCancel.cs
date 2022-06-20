using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rayna.ApiIntegration.Models.ResponseModels
{
    public class RaynaTourCancel
    {
        public int Status { get; set; } // 1=success { get; set; }  public   0 = fail
        public string ErrorMessage { get; set; }
        public SupplierCancellationDetail SupplierCancellationDetails { get; set; }

    }
}
