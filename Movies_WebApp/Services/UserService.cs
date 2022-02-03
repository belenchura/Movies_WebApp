using Microsoft.Extensions.Configuration;
using Movies_WebApp.Models;
using Movies_WebApp.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Movies_WebApp.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;

        public UserService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<User> GetUserAsync(AccountViewModel req)
        {
            User responseService;

            using (var httpClient = new HttpClient())
            {
                //ringContent content = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");

                string URL = $"{_configuration["Api_Movies"]}/GetUsers?username={req.UserName}&password={req.Password}";
                using (var response = await httpClient.GetAsync(URL))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    responseService = JsonConvert.DeserializeObject<User>(apiResponse);
                }
            }

            return responseService;
        }

        public async Task<IReadOnlyList<User>> GetAllAsync()
        {
            IReadOnlyList<User> responseService;

            using (var httpClient = new HttpClient())
            {
                //ringContent content = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");

                string URL = $"{_configuration["Api_Movies"]}";
                using (var response = await httpClient.GetAsync(URL))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    responseService = JsonConvert.DeserializeObject<IReadOnlyList<User>>(apiResponse);
                }
            }

            return responseService;
        }


        public async Task<int> DeleteAsync(int id)
        {
            int responseService;

            using (var httpClient = new HttpClient())
            {

                string URL = $"{_configuration["Api_Movies"]}/DeleteById?cod_user={id}";

                using (var response = await httpClient.DeleteAsync(URL))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    responseService = JsonConvert.DeserializeObject<int>(apiResponse);
                }
            }

            return responseService;
        }


        public async Task<int> AddAsync(User entity)
        {
            int responseService;

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

                string URL = $"{_configuration["Api_Movies"]}/AddUser";
                using (var response = await httpClient.PostAsync(URL,content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    responseService = JsonConvert.DeserializeObject<int>(apiResponse);
                }
            }

            return responseService;
        }

        public async Task<int> UpdateAsync(User entity)
        {
            int responseService;

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

                string URL = $"{_configuration["Api_Movies"]}/UpdateUser";
                using (var response = await httpClient.PutAsync(URL, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    responseService = JsonConvert.DeserializeObject<int>(apiResponse);
                }
            }

            return responseService;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            User responseService;

            using (var httpClient = new HttpClient())
            {
                //ringContent content = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");

                string URL = $"{_configuration["Api_Movies"]}/GetById?cod_user={id}";
                using (var response = await httpClient.GetAsync(URL))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    responseService = JsonConvert.DeserializeObject<User>(apiResponse);
                }
            }

            return responseService;
        }


    }
}
