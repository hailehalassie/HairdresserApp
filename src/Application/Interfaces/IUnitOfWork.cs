using Application.Interfaces.Repositories;

namespace Application.Interfaces
{ 
    public interface IUnitOfWork : IDisposable
    {
        IAppointmentRepository Appointments { get; }
        IServiceRepository Services { get; }
        Task<int> SaveChangesAsync();
    }
}