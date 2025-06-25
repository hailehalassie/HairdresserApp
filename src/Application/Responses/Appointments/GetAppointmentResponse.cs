namespace Application.Features.Appointments.Get
{
    public class GetAppointmentResponse
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
    }
}