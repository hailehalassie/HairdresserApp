using Application.Responses.Appointments;
using MediatR;

namespace Application.Features.Appointments.GetByBarber
{
    public class GetByBarberQry : IRequest<List<AppointmentDetailsResponse>>
    {
        public Guid BarberId { get; set; }

        public GetByBarberQry(Guid barberId)
        {
            BarberId = barberId;
        }
    }

}