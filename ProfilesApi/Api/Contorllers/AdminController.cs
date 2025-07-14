using Application.Admins.Models;
using Application.Admins.UseCases.CreateAdmin;
using Application.Admins.UseCases.DeleteAdmin;
using Application.Admins.UseCases.GetAllAdmins;
using Application.Admins.UseCases.GetAdminById;
using Application.Admins.UseCases.UpdateAdmin;
using Domain.Entities.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Domain.RequestFeatures;

namespace Api.Controllers;

[ApiController]
[Route("api/admins")]
public class AdminController : ControllerBase
{
    private readonly IMediator _mediator;

    public AdminController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<PagedList<AdminDTO>>> GetAdmins([FromQuery] AdminParameters adminParameters)
    {
        var query = new GetAllAdminsQuery() {AdminParameters = adminParameters};

        return Ok(await _mediator.Send(query));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AdminDTO>> GetAdminById(Guid id)
    {
        var query = new GetAdminByIdQuery() { Id = id };
        
        return Ok(await _mediator.Send(query));
    }

    [HttpPost]
    public async Task<ActionResult<AdminDTO>> CreateAdmin([FromBody] CreateAdminCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpPut]
    public async Task<ActionResult<AdminDTO>> UpdateAdmin([FromBody] UpdateAdminCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<AdminDTO>> DeleteAdmin(Guid id)
    {
        var command = new DeleteAdminCommand() { Id = id };

        await _mediator.Send(command);
        
        return Ok();
    }    

}