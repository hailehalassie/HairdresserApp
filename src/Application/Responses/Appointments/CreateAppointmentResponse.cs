namespace Application.Responses.Appointments
{
    public class CreateAppointmentResponse
    {
        public Guid Id { get; set; }
        public string Message { get; set; } = string.Empty;

        public CreateAppointmentResponse
        (
            Guid id,
            string message = "Appointment created successfully."
        )
        {
            Id = id;
            Message = message;
        }

        // Additional properties can be added as needed
    }
}