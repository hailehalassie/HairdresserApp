using Application.Responses.Appointments;
using MediatR;

namespace Application.Features.Appointments.Cancel
{ 
    public class CancelAppointmentCmd : IRequest<CancelAppointmentResponse>
    {
        public Guid Id { get; set; }

        public CancelAppointmentCmd(Guid id)
        {
            Id = id;
        }
    }
}