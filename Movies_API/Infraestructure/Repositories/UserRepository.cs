using Dapper;
using Microsoft.Extensions.Configuration;
using Movies_API.Entities;
using Movies_API.Infraestructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_API.Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration configuration;
        public UserRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM tUsers WHERE cod_usuario = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<User>> GetAllAsync()
        {
            var sql = $"SELECT * FROM tUsers" +
                $" LEFT JOIN tRol ON tRol.cod_rol = tUsers.cod_rol";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<User>(sql);
                return result.ToList();
            }
        }

        public async Task<User> GetByIdAsync(int cod_usuario)
        {
            var sql = $"SELECT * FROM tUsers " +
                $" LEFT JOIN tRol ON tRol.cod_rol = tUsers.cod_rol" +
                $" WHERE tUsers.cod_usuario = {cod_usuario}";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<User>(sql);
                return result;
            }
        }

        public async Task<User> GetUserAsync(string usr, string password)
        {
            var sql = $"SELECT * FROM tUsers" +
                $" LEFT JOIN tRol ON tRol.cod_rol = tUsers.cod_rol" +
                $" WHERE tUsers.txt_user = '{usr}' AND tUsers.txt_password = '{password}'";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<User>(sql);
                return result;
            }
        }

        public async Task<int> AddAsync(User entity)
        {
            var sql = "INSERT INTO [dbo].[tUsers] VALUES " +
                $" ('{entity.txt_user}', '{entity.txt_password}', '{entity.txt_nombre}', '{entity.txt_apellido}', {entity.nro_doc},{entity.cod_rol},{entity.sn_activo})";

            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql);
                return result;
            }
        }

        public async Task<int> UpdateAsync(User entity)
        {
            var sql = $"UPDATE tUsers SET txt_user = '{entity.txt_user}', txt_password = '{entity.txt_password}', " +
                $"txt_nombre = '{entity.txt_nombre}', txt_apellido ='{entity.txt_apellido}', nro_doc = {entity.nro_doc},cod_rol = {entity.cod_rol}, sn_activo = {entity.sn_activo} " +
                $" WHERE cod_usuario = {entity.cod_usuario}";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql);
                return result;
            }
        }
    }
}
