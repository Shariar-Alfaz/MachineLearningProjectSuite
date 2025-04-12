using MachineLearningProjectSuite.Application.Feature.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MachineLearningProjectSuite.API.Controllers
{
    [EnableCors("Learning")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PropertyController(
        IPropertyListingService propertyListingService
        ) : ControllerBase
    {
        [HttpGet("address")]
        public async Task<IActionResult> GetAddress()
        {
            var result = await propertyListingService.GetAddressAsync();
            return Ok(result);
        }

        [HttpGet("type")]
        public async Task<IActionResult> GetTypes()
        {
            var result = await propertyListingService.GetTypesAsync();
            return Ok(result);
        }

        [HttpGet("initial")]
        public async Task<IActionResult> GetInitialData()
        {
            var result = await propertyListingService.GetInitialDataAsync();
            return Ok(result);
        }
    }
}
