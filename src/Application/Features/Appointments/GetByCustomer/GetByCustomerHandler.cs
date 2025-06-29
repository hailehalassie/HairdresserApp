using Application.Interfaces.Repositories;
using Application.Responses.Appointments;
using MediatR;

namespace Application.Features.Appointments.GetByCustomer
{ 
    public class GetByCustomerHandler : IRequestHandler<GetByCustomerQry, List<AppointmentDetailsResponse>>
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public GetByCustomerHandler(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<List<AppointmentDetailsResponse>> Handle(GetByCustomerQry request, CancellationToken cancellationToken)
        {
            return await _appointmentRepository.GetAppointmentsByCustomerId(request.CustomerId);
        }
    }
}