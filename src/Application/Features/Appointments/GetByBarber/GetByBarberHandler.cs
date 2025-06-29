namespace Application.Features.Appointments.GetByBarber
{ 
    using Application.Interfaces.Repositories;
    using Application.Responses.Appointments;
    using MediatR;

    public class GetByBarberHandler : IRequestHandler<GetByBarberQry, List<AppointmentDetailsResponse>>
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public GetByBarberHandler(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<List<AppointmentDetailsResponse>> Handle(GetByBarberQry request, CancellationToken cancellationToken)
        {
            return await _appointmentRepository.GetAppointmentsByBarberId(request.BarberId);
        }
    }
}