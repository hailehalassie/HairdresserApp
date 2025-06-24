using Application.Interfaces;
using Application.Interfaces.Repositories;

namespace Infrastructure.Data
{ 
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IAppointmentRepository Appointments { get; }
        public IServiceRepository Services { get; }

        public UnitOfWork(
            AppDbContext context,
            IAppointmentRepository appointmentRepository,
            IServiceRepository serviceRepository)
        {
            _context = context;
            Appointments = appointmentRepository;
            Services = serviceRepository;
        }


        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    
    }
}