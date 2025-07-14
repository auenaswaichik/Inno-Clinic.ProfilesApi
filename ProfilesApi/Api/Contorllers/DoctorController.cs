using Application.Doctors.Models;
using Application.Doctors.UseCases.CreateDoctor;
using Application.Doctors.UseCases.DeleteDoctor;
using Application.Doctors.UseCases.GetAllDoctors;
using Application.Doctors.UseCases.GetDoctorById;
using Application.Doctors.UseCases.UpdateDoctor;
using Domain.Entities.Extensions;
using Domain.RequestFeatures;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/doctors")]
public class DoctorController : ControllerBase
{
    private readonly IMediator _mediator;

    public DoctorController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<PagedList<DoctorDTO>>> GetDoctors([FromQuery] DoctorParameters doctorParameters)
    {
        var query = new GetAllDoctorsQuery(){DoctorParameters = doctorParameters};

        var response = await _mediator.Send(query);

        return Ok(response.Items);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DoctorDTO>> GetDoctorById(Guid id)
    {
        var query = new GetDoctorByIdQuery() { Id = id };
        
        return Ok(await _mediator.Send(query));
    }

    [HttpPost]
    public async Task<ActionResult<DoctorDTO>> CreateDoctor([FromBody] CreateDoctorCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpPut]
    public async Task<ActionResult<DoctorDTO>> UpdateDoctor([FromBody] UpdateDoctorCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DoctorDTO>> DeleteDoctor(Guid id)
    {
        var command = new DeleteDoctorCommand() { Id = id };

        await _mediator.Send(command);
        
        return Ok();
    }    

}