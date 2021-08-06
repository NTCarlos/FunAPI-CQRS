using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using MediatR;
using Application.Queries.Settings;
using Common.DTO;

namespace FunApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DefaultController : ControllerBase
    {
        //private readonly IDefaultService _defaultService;
        private readonly IMediator _mediator;
        public DefaultController(IMediator mediator)
        {
            //_defaultService = defaultService ?? throw new ArgumentNullException(nameof(defaultService));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }   

        // The Web API will only accept tokens 1) for users, and 2) having the "access_as_user" scope for this API
        //static readonly string[] scopeRequiredByApi = new string[] { "access_as_user" };

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllSettingsQuery();
            return Ok(await _mediator.Send(query));
        }
        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetSettingByIdQuery(id);
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SettingDto setting)
        {
            return Ok();
            // var result = await _defaultService.Add(setting)
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] SettingDto setting, int id)
        {
            //var result = await _defaultService.Update(setting, id);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            //var result = await _defaultService.Delete(id);
            return Ok();
        }
    }
}
