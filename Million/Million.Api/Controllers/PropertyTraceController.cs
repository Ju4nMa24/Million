using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Million.Application.Database.Commands.PropertyTrace.CreatePropertyTraceCommand;
using Million.Application.Database.Commands.PropertyTrace.DeleteAddressCommand;
using Million.Application.Database.Commands.PropertyTrace.UpdatePropertyTraceCommand;
using Million.Application.Database.Queries.GetPropertyTraceQuery;
using Million.Application.Features;

namespace Million.Api.Controllers
{
    /// <summary>
    /// This controller is used to manage property traces.
    /// </summary>
    /// 
    [Authorize]
    [ApiController]
    [Route("api/property-trace")]
    public class PropertyTraceController : ControllerBase
    {
        /// <summary>
        /// This method is used to create a property trace.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="command"></param>
        /// <param name="validator"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] CreatePropertyTraceModel model,
                                               [FromServices] ICreatePropertyTraceCommand command)
        {
            CreatePropertyTraceModel? result = await command.Execute(model);
            return Ok(ResponseApiService.Response(201, "Created", result));
        }
        /// <summary>
        /// This method is used to update a property trace by id.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="command"></param>
        /// <param name="validator"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public async Task<ActionResult> Update([FromBody] UpdatePropertyTraceModel model,
                                       [FromServices] IUpdatePropertyTraceCommand command)
        {
            UpdatePropertyTraceModel? result = await command.Execute(model);
            return Ok(ResponseApiService.Response(200, "Updated", result));
        }
        /// <summary>
        /// this method is used to delete a property trace by id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(Guid id, [FromServices] IDeletePropertyTraceCommand command)
        {
            bool result = await command.Execute(id);
            if (!result)
                return NotFound(ResponseApiService.Response(404, "Not Found", null));

            return Ok(ResponseApiService.Response(200, "Deleted", result));
        }
        /// <summary>
        /// This method is used to get a property trace by id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("get/{id}")]
        public async Task<ActionResult> GetById(Guid id,[FromServices]IGetPropertyTraceQuery query)
        {
            GetPropertyTraceModel? result = await query.Execute(id);
            if (result == null)
                return NotFound(ResponseApiService.Response(404, "Not Found", null));

            return Ok(ResponseApiService.Response(200, "OK", result));
        }
    }

}
