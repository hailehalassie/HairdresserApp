namespace Application.Features.Appointments.UpdateStatus
{
    using Application.Requests.Appointments;
    using Application.Responses.Appointments;
    using Domain.Enums;
    using MediatR;

    public class UpdateStatusCmd : IRequest<UpdateStatusResponse>
    {
        public Guid AppointmentId { get; set; }
        public Status Status { get; set; } // Assuming Status is a string representation of the enum

        public UpdateStatusCmd(UpdateStatusRequest request)
        {
            AppointmentId = request.AppointmentId;
            Status = request.Status;
        }
    }
}