namespace Application.Responses.Appointments
{ 
    public class UpdateStatusResponse
    {
        public Guid Id { get; set; }
        public string Message { get; set; } = string.Empty;

        public UpdateStatusResponse
        (
            Guid id,
            string message = "Appointment status updated successfully."
        )
        {
            Id = id;
            Message = message;
        }

        // Additional properties can be added as needed
    }
}