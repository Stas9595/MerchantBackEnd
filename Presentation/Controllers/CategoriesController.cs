using Application.Categories.Queries.GetCategories;
using Application.Merchants.Commands.CreateMerchant;
using Application.Merchants.Commands.UpdateMerchant;
using Application.Merchants.Queries.GetMerchants;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Presentation.Controllers;

[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ISender _sender;

    public CategoriesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet(ApiEndpoints.Categories.GetAll)]
    public async Task<ActionResult<List<Category>>> GetAll(CancellationToken cancellationToken)
    {
        var command = new GetCategoriesQuery();
        var result = await _sender.Send(command, cancellationToken);

        return Ok(result);
    }
    
}