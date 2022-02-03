using Movies_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_API.Infraestructure.Repositories.Interfaces
{
    public interface IMoviesRepository
    {
        Task<int> AddAsync(Movie entity);
        Task<int> DeleteAsync(int id);
        Task<IReadOnlyList<Movie>> GetAllAsync();
        Task<Movie> GetByIdAsync(int id);
        Task<int> UpdateAsync(Movie entity, int codMovie);
    }
}
