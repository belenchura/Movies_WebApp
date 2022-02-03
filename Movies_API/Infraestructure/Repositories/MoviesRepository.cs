using Microsoft.Extensions.Configuration;
using Movies_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Movies_API.Infraestructure.Repositories.Interfaces;

namespace Movies_API.Infraestructure.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly IConfiguration configuration;
        public MoviesRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM tPelicula WHERE cod_pelicula = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<Movie>> GetAllAsync()
        {
            var sql = "SELECT * FROM tPelicula";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Movie>(sql);
                return result.ToList();
            }
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM tPelicula WHERE cod_pelicula = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Movie>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> AddAsync(Movie entity)
        {

            var sql = "INSERT INTO [dbo].[tPelicula] ([txt_desc], [cant_disponibles_alquiler], [cant_disponibles_venta], [precio_alquiler], [precio_venta]) " +
                "VALUES (@txt_desc, @cant_disponibles_alquiler, @cant_disponibles_alquiler, CAST(@precio_alquiler AS Decimal(18, 2)), CAST(@precio_venta AS Decimal(18, 2)))";

            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> UpdateAsync(Movie entity, int codMovie)
        {
            var sql = "UPDATE tPelicula SET txt_desc = @txt_desc, cant_disponibles_alquiler = @cant_disponibles_alquiler, " +
                "cant_disponibles_venta = @cant_disponibles_venta, precio_alquiler = @precio_alquiler, precio_venta = @precio_venta " +
                $"WHERE cod_pelicula = {codMovie}";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
