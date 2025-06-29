using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Responses.Appointments;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Features.Appointments.Create
{ 
    public class CreateAppointmentHandler : IRequestHandler<CreateAppointmentCmd, CreateAppointmentResponse>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly CreateAppointmentValidator _validator;

        public CreateAppointmentHandler(IAppointmentRepository appointmentRepository, IUnitOfWork unitOfWork, CreateAppointmentValidator validator)
        {
            _appointmentRepository = appointmentRepository;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<CreateAppointmentResponse> Handle(CreateAppointmentCmd request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);

            var appointment = new Appointment
            {
                StartTime = request.StartTime,
                EndTime = request.EndTime,
                ServiceId = request.ServiceId,
                BarberId = request.BarberId,
                CustomerId = request.CustomerId
            };

            await _appointmentRepository.AddAsync(appointment);
            await _unitOfWork.SaveChangesAsync();

            return new CreateAppointmentResponse(appointment.Id);
        }
    }
}