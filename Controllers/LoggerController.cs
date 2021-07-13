using Test.Logger.Services.Model;
using Test.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using Test.Logger.Services.Extensions;
using Test.Logger.Services.Common;
using System.Threading.Tasks;

namespace Test.Logger.Services.Logger.Services.Controllers
{
    [Route("api/logger")]
    [ApiController]
    public class LoggerController : ControllerBase
    {
        private readonly IFileService fileServices;
        public LoggerController(IFileService fileServices)
        {
            this.fileServices = fileServices;
        }

        [HttpPost]
        [Route("info")]
        public async Task<IActionResult> Info(Message message)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(new { message = ModelState.ToError() });
            }
          
            message.Id = message.Id == 0? RandomGenerator.RandomNumber() : message.Id;
            await this.fileServices.WriteLineAsync(message);

            return Ok();
        }

    }
}
