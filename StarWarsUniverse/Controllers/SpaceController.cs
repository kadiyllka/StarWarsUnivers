using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarWarsUniverse.Services;

namespace StarWarsUniverse.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpaceController : ControllerBase
    {
        private readonly ILogger<SpaceController> _logger;
        private readonly CannonLoaderService _cannonLoaderService;
        public SpaceController(ILogger<SpaceController> logger, CannonLoaderService cannonLoaderService)
        {
            _logger = logger;
            _cannonLoaderService = cannonLoaderService;
        }

        private static readonly uint[] heights = new uint[] { 1, 6, 4, 5, 4, 5, 1, 2, 3, 4, 7, 2 };

        [HttpGet]
        public int GetCannonNumberForExampleHeights()
        {
            var respo = _cannonLoaderService.GetCannonCount(heights);

            return respo;

        }
    }
}
