using Movies_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_WebApp.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserAsync(AccountViewModel req);
        Task<IReadOnlyList<User>> GetAllAsync();

        Task<int> DeleteAsync(int id);

        Task<User> GetByIdAsync(int id);

        Task<int> AddAsync(User entity);

        Task<int> UpdateAsync(User entity);
    }
}
