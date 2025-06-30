namespace Application.Features.Appointments.UpdateStatus
{
    using System.Diagnostics;
    using Application.Exceptions;
    using Application.Interfaces;
    using Application.Interfaces.Repositories;
    using Application.Responses.Appointments;
    using FluentValidation;
    using MediatR;


    public class UpdateStatusHandler : IRequestHandler<UpdateStatusCmd, UpdateStatusResponse>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateStatusHandler(IAppointmentRepository appointmentRepository, IUnitOfWork unitOfWork)
        {
            _appointmentRepository = appointmentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateStatusResponse> Handle(UpdateStatusCmd request, CancellationToken cancellationToken)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(request.AppointmentId);
            if (appointment == null)
            {
                throw new NotFoundException("Appointment not found"); // Appointment not found
            }

            appointment.Status = request.Status;

            _appointmentRepository.UpdateAsync(appointment);
            await _unitOfWork.SaveChangesAsync();

            return new UpdateStatusResponse(appointment.Id);
        }
    }
}