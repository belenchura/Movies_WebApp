using Movies_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_API.Infraestructure.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<int> DeleteAsync(int id);
        Task<IReadOnlyList<User>> GetAllAsync();

        Task<User> GetByIdAsync(int id);
        Task<User> GetUserAsync(string usr, string password);

        Task<int> AddAsync(User entity);

        Task<int> UpdateAsync(User entity);
    }
}
