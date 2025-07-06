namespace Application.Interfaces
{ 
    public interface IUserService
{
    Task<List<(Guid Id, string FullName)>> GetBarbersAsync();
}

}