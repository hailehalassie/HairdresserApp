using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Responses.Appointments;
using Domain.Enums;
using FluentValidation;
using MediatR;

namespace Application.Features.Appointments.Cancel
{ 
    public class CancelAppointmentHandler : IRequestHandler<CancelAppointmentCmd, CancelAppointmentResponse>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CancelAppointmentHandler(IAppointmentRepository appointmentRepository, IUnitOfWork unitOfWork)
        {
            _appointmentRepository = appointmentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CancelAppointmentResponse> Handle(CancelAppointmentCmd request, CancellationToken cancellationToken)
        {   
            var appointment = await _appointmentRepository.GetByIdAsync(request.Id);
            if (appointment == null)
            {
                throw new NotFoundException("Appointment not found.");
            }

            appointment.Status = Status.Cancelled;
            _appointmentRepository.UpdateAsync(appointment);
            await _unitOfWork.SaveChangesAsync();

            return new CancelAppointmentResponse(appointment.Id);
        }
    }
}