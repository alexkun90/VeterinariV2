using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;
using NuGet.Common;

namespace FrontEnd.Helpers.Implementations
{
    public class SecurityHelper : ISecurityHelper
    {
        IServiceRepository ServiceRepository;

        public SecurityHelper(IServiceRepository serviceRepository)
        {
            ServiceRepository = serviceRepository;
        }

        public LoginAPI GetUser(UserViewModel user)
        {
            return new LoginAPI();
        }

        public LoginAPI Login(UserViewModel user)
        {
            try
            {
                TokenAPI token = new TokenAPI();

                HttpResponseMessage responseMessage = ServiceRepository.PostResponse("/api/Auth/login", new { user.UserName, user.Password });
                
                var content = responseMessage.Content.ReadAsStringAsync().Result;   
                LoginAPI LoginAPI = JsonConvert.DeserializeObject<LoginAPI>(content);

                token = LoginAPI.Token;

                return LoginAPI;


            }
            catch (Exception)
            {

                throw;
            }
        }

        public ResponseApi Register(RegisterViewModel user)
        {
            try
            {
                HttpResponseMessage responseMessage = ServiceRepository.PostResponse("/api/Auth/register", new { user.UserName, user.Email,user.Password });

                if (responseMessage.IsSuccessStatusCode)
                {
                    var content = responseMessage.Content.ReadAsStringAsync().Result;
                    var response = JsonConvert.DeserializeObject<ResponseApi>(content);
                    return response;
                }
                else
                {
                    var errorContent = responseMessage.Content.ReadAsStringAsync().Result;
                    var errorResponse = JsonConvert.DeserializeObject<ResponseApi>(errorContent);
                    return errorResponse;
                }
            }
            catch (Exception )
            {
                throw;
            }
        }
    }
}
