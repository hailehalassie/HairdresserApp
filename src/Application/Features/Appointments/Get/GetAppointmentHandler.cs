namespace Application.Features.Appointments.Get
{
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
            return await _appointmentRepository.GetAppointmentById(request.Id);
        }
    }
}