using Application.Patients.Models;
using Application.Patients.UseCases.CreatePatient;
using Application.Patients.UseCases.DeletePatient;
using Application.Patients.UseCases.GetAllPatients;
using Application.Patients.UseCases.GetPatientById;
using Application.Patients.UseCases.UpdatePatient;
using Domain.Entities.Extensions;
using Domain.RequestFeatures;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/patients")]
public class PatientController : ControllerBase
{
    private readonly IMediator _mediator;

    public PatientController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<PagedList<PatientDTO>>> GetPatients([FromQuery] PatientParameters patientParameters)
    {
        var query = new GetAllPatientsQuery() { PatientParameters = patientParameters };
        
        return Ok(await _mediator.Send(query));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PatientDTO>> GetPatientById(Guid id)
    {
        var query = new GetPatientByIdQuery() { Id = id };
        
        return Ok(await _mediator.Send(query));
    }

    [HttpPost]
    public async Task<ActionResult<PatientDTO>> CreatePatient([FromBody] CreatePatientCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpPut]
    public async Task<ActionResult<PatientDTO>> UpdatePatient([FromBody] UpdatePatientCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<PatientDTO>> DeletePatient(Guid id)
    {
        var command = new DeletePatientCommand() { Id = id };

        await _mediator.Send(command);
        
        return Ok();
    }    

}