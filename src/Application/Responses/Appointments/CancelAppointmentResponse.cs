namespace Application.Responses.Appointments
{ 
    public class CancelAppointmentResponse
    {
        public Guid Id { get; set; }
        public string Message { get; set; } = string.Empty;

        public CancelAppointmentResponse
        (
            Guid id,
            string message = "Appointment cancelled successfully."
        )
        {
            Id = id;
            Message = message;
        }

    }
}