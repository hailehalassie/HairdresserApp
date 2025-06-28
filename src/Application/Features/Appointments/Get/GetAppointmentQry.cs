using Application.Responses.Appointments;
using MediatR;

namespace Application.Features.Appointments.Get
{
    public class GetAppointmentQry : IRequest<AppointmentDetailsResponse>
    {
        public Guid Id { get; set; }

        public GetAppointmentQry(Guid id )     
        {
            Id = id;
        }
    }
}