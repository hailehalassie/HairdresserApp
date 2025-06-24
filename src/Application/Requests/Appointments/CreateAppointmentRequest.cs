namespace Application.Requests.Appointments
{ 
    public class CreateAppointmentRequest
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid ServiceId { get; set; }
        public Guid BarberId { get; set; }
        public Guid CustomerId { get; set; }
    }
}