using Api.Constants;
using Application.Specializations.Models;
using Application.Specializations.UseCases.CreateSpecialization;
using Application.Specializations.UseCases.GetAllSpecializations;
using Application.Specializations.UseCases.GetSpecializationById;
using Application.Specializations.UseCases.UpdateSpecialization;
using Domain.Entities.Parameters;   
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Authorize]
[ApiController]
[Route("api/specializations")]
public class SpecializationController : ControllerBase
{
    private readonly IMediator _mediator;

    public SpecializationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<List<SpecializationDTO>>> GetSpecializations([FromQuery] SpecializationParameters specializationParameters)
    {
        var query = new GetAllSpecializationsQuery()
        {
            SpecializationParameters = specializationParameters
        };

        return Ok(await _mediator.Send(query));
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<SpecializationDTO>> GetSpecializationById(Guid id)
    {
        var query = new GetSpecializationByIdQuery()
        {
            Id = id
        };

        return Ok(await _mediator.Send(query));
    }

    [Authorize(Policy = PolicyConstants.ADMIN_ONLY_POLICY)]
    [HttpPost]
    public async Task<ActionResult<SpecializationDTO>> CreateSpecialization([FromBody] CreateSpecializationCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [Authorize(Policy = PolicyConstants.ADMIN_ONLY_POLICY)]
    [HttpPut]
    public async Task<ActionResult<SpecializationDTO>> UpdateSpecialization([FromBody] UpdateSpecializationCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
}