using Delosi.Application.DTO;
using Delosi.Application.Interface;
using Delosi.Application.Main;
using DelosiWebApi.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DelosiWebApi.Controllers.v2
{
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class DelosiController : Controller
    {
        private readonly ILogicApplication _logicApplication;
        private readonly AppSettings _appSettings;
        public DelosiController(ILogicApplication logicApplication, IOptions<AppSettings> appSettings)
        {
            _logicApplication = logicApplication;
            _appSettings = appSettings.Value;
        }

        [HttpPost("Rotate")]
        public IActionResult Index([FromBody] MatrixDTO Request)
        {
           
            var response = _logicApplication.Rotate(Request);
            if (response.IsSuccess)
            {
                if (response.Data != null)
                {

                    return Ok(response.Data);
                }
                else
                    return NotFound(response);
            }

            return BadRequest(response);


        }
    }
}
