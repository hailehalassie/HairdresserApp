using Infrastructure.Identity;

namespace API.Services
{
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(AppUser user);
    }
}