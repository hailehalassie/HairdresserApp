using Application.Responses.Appointments;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Task<AppointmentDetailsResponse?> GetAppointmentById(Guid appointmentId);
        Task<List<AppointmentDetailsResponse>> GetAppointmentsByBarberId(Guid barberId);
        Task<List<AppointmentDetailsResponse>> GetAppointmentsByCustomerId(Guid customerId);
    }
}