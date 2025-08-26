using Domain.Entities;
using Domain.Interfaces.IRepositories;
using MassTransit;

namespace Infrastructure.Messages.PatientRegisteredMessages;

public class PatientRegisteredConsumer : IConsumer<PatientRegisteredMessage>
{
    private readonly IPatientRepository _patientRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PatientRegisteredConsumer(IPatientRepository patientRepository, IUnitOfWork unitOfWork)
    {
        _patientRepository = patientRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task Consume(ConsumeContext<PatientRegisteredMessage> context)
    {
        var message = context.Message;

        _patientRepository.Insert(new Patient()
        {
            Id = message.Id,
            FirstName = message.Login,
            Email = message.Email,
            PasswordHash = message.PasswordHash,
        });

        await _unitOfWork.SaveAsync(new CancellationToken());
    }
}