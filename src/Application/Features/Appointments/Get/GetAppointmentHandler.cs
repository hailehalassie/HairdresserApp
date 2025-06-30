namespace Application.Features.Appointments.Get
{
    using Application.Exceptions;
    using Application.Interfaces.Repositories;
    using Application.Responses.Appointments;
    using MediatR;

    public class GetAppointmentHandler : IRequestHandler<GetAppointmentQry, AppointmentDetailsResponse?>
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public GetAppointmentHandler(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<AppointmentDetailsResponse?> Handle(GetAppointmentQry request, CancellationToken cancellationToken)
        {
            var appointment = await _appointmentRepository.GetAppointmentById(request.Id);
            if (appointment == null)
            {
                throw new NotFoundException("Appointment not found.");
            }

            return appointment;
        }
    }
}