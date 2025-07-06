public class CreateAppointmentFormDataResponse
{
    public List<ServiceDto> Services { get; set; }
    public List<BarberDto> Barbers { get; set; }
}

public class ServiceDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}

public class BarberDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
}
