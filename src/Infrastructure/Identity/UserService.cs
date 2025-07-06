using Application.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{ 
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<(Guid Id, string FullName)>> GetBarbersAsync()
        {
            var barbers = await _userManager.GetUsersInRoleAsync("Barber");
            return barbers.Select(b => (b.Id, b.FirstName+" "+b.LastName)).ToList();
        }
    }
}