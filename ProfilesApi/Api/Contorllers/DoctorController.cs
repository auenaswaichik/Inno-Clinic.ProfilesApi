using Application.Doctors.Commands.CreateDoctor;
using Application.Doctors.Queries.GetAllDoctors;
using Application.Doctors.Queries.GetDoctorById;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/doctors")]

public class DoctorController : ControllerBase
{
    private readonly IMediator _mediator;

    public DoctorController(IMediator mediator)
        => _mediator = mediator;

    [HttpGet]
    public async Task<List<Doctor>> GetDoctors()
    {
        var command = new GetAllDoctorsQuery();
        return await _mediator.Send(command) ?? throw new Exception("there is no docs");
    }

    [HttpGet("id:guid")]
    public async Task<Doctor> GetDoctorById([FromHeader] Guid id)
    {
        var command = new GetDoctorByIdQuery() { Id = id };
        return await _mediator.Send(command) ?? throw new Exception("there is no such doctor");
    }

    [HttpPost("create-doctor")]
    public async Task<Doctor> CreateDoctor([FromBody] CreateDoctorCommand command)
    {
        return await _mediator.Send(command) ?? throw new Exception("Something wrong");
    }

}