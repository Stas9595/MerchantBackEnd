using Application.Merchants.Commands.CreateMerchant;
using Application.Merchants.Commands.DeleteMerchant;
using Application.Merchants.Commands.UpdateMerchant;
using Application.Merchants.Queries.GetMerchants;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
public class MerchantsController : ControllerBase
{
    private readonly ISender _sender;

    public MerchantsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost(ApiEndpoints.Merchants.Create)]
    public async Task<ActionResult<Merchant>> Create([FromBody] CreateMerchantRequest request)
    {
        var command = new CreateMerchantCommand(request.Name, request.Email, request.CategoryId);
        var result = await _sender.Send(command);

        return CreatedAtAction(nameof(Create), new { id = result.Id }, result);
    }

    [HttpGet(ApiEndpoints.Merchants.GetAll)]
    public async Task<ActionResult<List<Merchant>>> GetAll(
        [FromQuery] string? category, 
        [FromQuery] string? name, 
        CancellationToken cancellationToken)
    {
        var command = new GetMerchantsQuery(category, name);
        var result = await _sender.Send(command, cancellationToken);

        return Ok(result);
    }

    [HttpPut(ApiEndpoints.Merchants.Update)]
    public async Task<ActionResult<Merchant>> Update([FromRoute] Guid id, [FromBody] UpdateMerchantRequest request)
    {
        var command = new UpdateMerchantCommand(id, request.Name, request.Email, request.CategoryId);
        var result = await _sender.Send(command);

        if (result is null)
        {
            return NotFound();
        }
        
        return Ok(result);
    }
    
    [HttpDelete(ApiEndpoints.Merchants.Delete)]
    public async Task<ActionResult> Delete(Guid id)
    {
        var result = await _sender.Send(new DeleteMerchantCommand(id));
        return result ? NoContent() : NotFound();
    }

}