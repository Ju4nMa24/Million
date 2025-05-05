using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Million.Application.Database.Commands.Owner.CreateOwnerCommand;
using Million.Application.Database.Commands.Owner.DeleteOwnerCommand;
using Million.Application.Database.Commands.Owner.UpdateOwnerCommand;
using Million.Application.Database.Commands.OwnerContact.CreateOwnerContactCommand;
using Million.Application.Database.Commands.OwnerContact.DeleteOwnerContactCommand;
using Million.Application.Database.Commands.OwnerContact.UpdateOwnerContactCommand;
using Million.Application.Database.Queries.GetOwnerContactByIdQuery;
using Million.Application.Database.Queries.GetOwnerQuery;
using Million.Application.Features;
using Million.Common.Constants;
using Million.Domain.Entities.OwnerContact;

namespace Million.Api.Controllers
{
    /// <summary>
    /// This controller is used to manage owners.
    /// </summary>
    [Route("api/v1/owner")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        /// <summary>
        /// This method is used to create a new owner in the database.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="command"></param>
        /// <param name="validator"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]CreateOwnerModel model, 
            [FromServices]ICreateOwnerCommand command, 
            [FromServices]ICreateOwnerContactCommand contact, 
            [FromServices] IValidator<CreateOwnerModel> validator)
        {
            ValidationResult validation = await validator.ValidateAsync(model);
            if (!validation.IsValid)
                return BadRequest(ResponseApiService.Response(StatusCodes.Status400BadRequest, Errors.FAILED_WITH_DESCRIPTION, validation.Errors));

            CreateOwnerModel? result = await command.Execute(model);
            if (result != null)
            {
                model.Contact.IdOwner = result.IdOwner;
                await contact.Execute(model.Contact);
            }
            return Ok(ResponseApiService.Response(StatusCodes.Status201Created, Correct.SUCCESSFULLY, result));
        }

        /// <summary>
        /// This method is used to update the owner info in the database.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="command"></param>
        /// <param name="validator"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateOwnerModel model,
            [FromServices]IUpdateOwnerCommand command,
            [FromServices]IUpdateOwnerContactCommand contactCommand,
            [FromServices] IValidator<UpdateOwnerModel> validator)
        {
            ValidationResult validation = await validator.ValidateAsync(model);
            if (!validation.IsValid)
                return BadRequest(ResponseApiService.Response(StatusCodes.Status400BadRequest, Errors.FAILED_WITH_DESCRIPTION, validation.Errors));

            UpdateOwnerModel? result = await command.Execute(model);
            if (result != null)
                await contactCommand.Execute(model?.Contact);

            return Ok(ResponseApiService.Response(StatusCodes.Status200OK, Correct.SUCCESSFULLY, result));
        }
        /// <summary>
        /// This method is used to delete the owner info in the database.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id,[FromServices] IDeleteOwnerCommand command, [FromServices]IDeleteOwnerContactCommand contactCommand)
        {
            bool result = await command.Execute(new DeleteOwnerModel { IdOwner = id });
            bool contactResult = false;
            if (result)
                contactResult = await contactCommand.Execute(id);

            if (!contactResult && !result)
                return BadRequest(ResponseApiService.Response(StatusCodes.Status400BadRequest, Errors.FAILED_WITH_DESCRIPTION, string.Empty));

            return Ok(ResponseApiService.Response(StatusCodes.Status200OK, Correct.SUCCESSFULLY, result));
        }
        /// <summary>
        /// This method is used to get the owner info by id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("get_owner_by_owner_id/{id}")]
        public async Task<IActionResult> GetAll(Guid id, [FromServices]IGetOwnerQuery query)
        {
            GetOwnerModel? result = await query.Execute(id);
            return Ok(ResponseApiService.Response(StatusCodes.Status200OK, "SUCCESS", result));
        }
        /// <summary>
        /// This method is used to get the owner contact by id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("get_owner_contact_by_owner_id/{id}")]
        public async Task<IActionResult> GetById(Guid id,[FromServices] IGetOwnerContactByIdQuery query)
        {
            OwnerContactEntity? result = await query.Execute(id);
            if (result == null)
                return NotFound(ResponseApiService.Response(StatusCodes.Status404NotFound, "NOT_FOUND"));

            return Ok(ResponseApiService.Response(StatusCodes.Status200OK, "SUCCESS", result));
        }
    }
}
