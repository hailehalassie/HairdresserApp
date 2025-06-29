namespace Application.Responses.Appointments
{
    public class AppointmentDetailsResponse
    {
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid ServiceId { get; set; }
        public string ServiceName { get; set; }
        public Guid BarberId { get; set; }
        public string BarberName { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Status { get; set; } // Assuming Status is a string representation of the enum
    }
}