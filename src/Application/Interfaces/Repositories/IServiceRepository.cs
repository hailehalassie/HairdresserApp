using Domain.Entities;

namespace Application.Interfaces.Repositories
{ 
    public interface IServiceRepository : IRepository<Service>
    {
        // Additional methods specific to Service can be added here
        // For example, methods to get services by category, etc.
    }
}