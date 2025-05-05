using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Million.Application.Database.Commands.PropertyImage.CreatePropertyImageCommand;
using Million.Application.Database.Commands.PropertyImage.DeletePropertyImageCommand;
using Million.Application.Database.Commands.PropertyImage.UpdatePropertyImageCommand;
using Million.Application.Database.Queries.GetPropertyImageQuery;
using Million.Application.Features;

namespace Million.Api.Controllers
{
    /// <summary>
    /// This controller is used to manage property images.
    /// </summary>
    /// 
    [Authorize]
    [ApiController]
    [Route("api/property-image")]
    public class PropertyImageController : ControllerBase
    {
        /// <summary>
        /// This method is used to create a property image.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="command"></param>
        /// <param name="validator"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] CreatePropertyImageModel model,
                                               [FromServices] ICreatePropertyImageCommand command)
        {
            var result = await command.Execute(model);
            return Ok(ResponseApiService.Response(201, "Created", result));
        }
        /// <summary>
        /// This method is used to update a property image by id.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="command"></param>
        /// <param name="validator"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public async Task<ActionResult> Update([FromBody] UpdatePropertyImageModel model,
                                               [FromServices] IUpdatePropertyImageCommand command)
        {
            UpdatePropertyImageModel? result = await command.Execute(model);
            return Ok(ResponseApiService.Response(200, "Updated", result));
        }
        /// <summary>
        /// This method is used to delete a property image by id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(Guid id,[FromServices] IDeletePropertyImageCommand command)
        {
            bool result = await command.Execute(new DeletePropertyImageModel { IdPropertyImage = id });
            if (!result)
                return NotFound(ResponseApiService.Response(404, "Not Found", null));

            return Ok(ResponseApiService.Response(200, "Deleted", result));
        }
        /// <summary>
        /// This method is used to get a property image by id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("get/{id}")]
        public async Task<ActionResult> GetById(Guid id,[FromServices]IGetPropertyImageQuery query)
        {
            GetPropertyImageModel? result = await query.Execute(id);
            if (result == null)
                return NotFound(ResponseApiService.Response(404, "Not Found", null));

            return Ok(ResponseApiService.Response(200, "OK", result));
        }

    }

}
