using Microsoft.AspNetCore.Mvc;
using WebAPIOrdering.Interfaces;
using WebAPIOrdering.Models;

namespace WebAPIOrdering.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class WebAPIOrderingController : Controller
    {
        private readonly IIntegerArrayService _integerArrayService;
        private readonly IJsonFileHandlerService _jsonFileHandlerService;

        public WebAPIOrderingController(IIntegerArrayService integerArrayService, IJsonFileHandlerService jsonFileHandlerService)
        {
            _integerArrayService = integerArrayService;
            _jsonFileHandlerService = jsonFileHandlerService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _jsonFileHandlerService.TryReadFromFile(out string data);

            return Ok(data);
        }

        [HttpPost]
        [Route("post")]
        public IActionResult Post([FromBody] IntegerArray data)
        {
            _integerArrayService.TryOrderIntegerArray(data.Value, out int[] orderedData);

            _jsonFileHandlerService.TryWriteToFile(orderedData);

            return Ok(orderedData);
        }


    }
}
