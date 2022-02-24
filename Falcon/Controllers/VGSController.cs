using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rayna.ApiIntegration.Models.ResponseModels;
using Rayna.ApiIntegration.Services;
using System;
using System.Threading.Tasks;

namespace Rayna.ApiIntegration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VGSController : ControllerBase
    {
        private readonly ILogger<VGSController> _logger;
        private readonly IVGSService _vgsService;

        public VGSController(ILogger<VGSController> logger, IVGSService vgsService)
        {
            _logger = logger;
            _vgsService = vgsService;
        }

        [HttpGet("GetProductList")]
        public Task<RaynaTourList> GetProductList()
        {
            var results = _vgsService.GetProductListAsync();
            return results;
        }

        //[HttpGet("CheckAvailability")]
        //public Task<RaynaTimeSlotList> CheckAvailability(DateTime date, string productCode, int noOfPax)
        //{
        //    var results = _vgsService.CheckAvailabilityAsync(date, productCode, noOfPax);
        //    return results;
        //}
    }
}
