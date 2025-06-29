using Domain.Enums;

namespace Application.Requests.Appointments
{ 
    public class UpdateStatusRequest
    {
        public Guid AppointmentId { get; set; }
        public Status Status { get; set; } // Assuming Status is a string representation of the enum
    }
}