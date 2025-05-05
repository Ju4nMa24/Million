using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Million.Application.Database.Commands.Address.CreateAddressCommand;
using Million.Application.Database.Commands.Property.CreatePropertyCommand;
using Million.Application.Database.Commands.Property.DeleteAddressCommand;
using Million.Application.Database.Commands.Property.UpdatePropertyCommand;
using Million.Application.Database.Queries.GetPropertyQuery;
using Million.Application.Features;
using Million.Common.Constants;

namespace Million.Api.Controllers
{
    /// <summary>
    /// This controller is used to manage properties.
    /// </summary>
    [Route("api/v1/property")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        /// <summary>
        /// This method is used to create a new property in the database.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="command"></param>
        /// <param name="validator"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] CreatePropertyModel model, 
            [FromServices] ICreatePropertyCommand command, 
            [FromServices] IValidator<CreatePropertyModel> validator)
        {
            ValidationResult validate = await validator.ValidateAsync(model);
            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status400BadRequest, Errors.FAILED_WITH_DESCRIPTION, validate.Errors));

            CreatePropertyModel? result = await command.Execute(model);

            return StatusCode(StatusCodes.Status201Created,
                ResponseApiService.Response(StatusCodes.Status201Created, Correct.SUCCESSFULLY, result));
        }
        /// <summary>
        /// This method is used to update the property info in the database.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="command"></param>
        /// <param name="validator"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public async Task<ActionResult> Update(
            [FromBody] UpdatePropertyModel model,
            [FromServices] IUpdatePropertyCommand command,
            [FromServices] IValidator<UpdatePropertyModel> validator)
        {
            ValidationResult validate = await validator.ValidateAsync(model);
            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest,
                    ResponseApiService.Response(StatusCodes.Status400BadRequest, Errors.FAILED_WITH_DESCRIPTION, validate.Errors));

            UpdatePropertyModel? result = await command.Execute(model);

            return StatusCode(StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, Correct.SUCCESSFULLY, result));
        }
        /// <summary>
        /// This method is used to delete the property from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id, [FromServices]IDeletePropertyCommand command)
        {
            bool deleted = await command.Execute(new DeletePropertyModel { IdProperty = id});

            if (!deleted)
                return BadRequest(ResponseApiService.Response(StatusCodes.Status400BadRequest, Errors.FAILED_WITH_DESCRIPTION, string.Empty));

            return StatusCode(StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, Correct.SUCCESSFULLY));
        }
        /// <summary>
        /// This method is used to get the property info from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("get/{id}")]
        public async Task<ActionResult> GetById([FromRoute] Guid id,[FromServices]IGetPropertyQuery query)
        {
            GetPropertyModel? result = await query.Execute(id);
            if (result == null)
                return BadRequest(ResponseApiService.Response(StatusCodes.Status400BadRequest, Errors.FAILED_WITH_DESCRIPTION, string.Empty));

            return StatusCode(StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, Correct.SUCCESSFULLY, result));
        }
    }
}
