using Application.Responses.Appointments;
using MediatR;

namespace Application.Features.Appointments.GetByCustomer
{ 
    public class GetByCustomerQry : IRequest<List<AppointmentDetailsResponse>>
    {
        public Guid CustomerId { get; set; }

        public GetByCustomerQry(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}