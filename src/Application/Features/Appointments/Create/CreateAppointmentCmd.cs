using Application.Requests.Appointments;
using Application.Responses.Appointments;
using MediatR;
using System;

namespace Application.Features.Appointments.Create
{
    public class CreateAppointmentCmd : IRequest<CreateAppointmentResponse>
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid ServiceId { get; set; }
        public Guid BarberId { get; set; }
        public Guid CustomerId { get; set; }
        public CreateAppointmentCmd(CreateAppointmentRequest request)
        {
            ServiceId = request.ServiceId;
            BarberId = request.BarberId;
            CustomerId = request.CustomerId;
            StartTime = request.StartTime;
            EndTime = request.EndTime;
        }
    }
}