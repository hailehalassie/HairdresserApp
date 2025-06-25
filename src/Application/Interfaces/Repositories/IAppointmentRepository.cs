using Application.Responses.Appointments;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{ 
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Task<AppointmentDetailsResponse?> GetAppointmentById(Guid appointmentId);
    }
}