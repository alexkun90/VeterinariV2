using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class UsuarioHelper : IUsuarioHelper
    {
        IServiceRepository _serviceRepository;
        public UsuarioHelper(IServiceRepository serviceRepository)
        {
            this._serviceRepository = serviceRepository;
        }

        public UsuarioViewModel AddUsuario(UsuarioViewModel UsuarioViewModel)
        {
            /*var responseMessage = _serviceRepository.PostResponse("api/CreateUser", Convertir(UsuarioViewModel));
            if (responseMessage != null)
            {
                var content =  responseMessage.Content.ReadAsStringAsync();
            }*/

            return new UsuarioViewModel { };
        }

        public void DeleteCita(string id)
        {
            throw new NotImplementedException();
        }

        public UsuarioViewModel EditUsuario(string id, UsuarioViewModel UsuarioViewModel)
        {
            /*var responseMessage = _serviceRepository.PutResponse($"api/UpdateUser/{id}", Convertir(UsuarioViewModel));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                
            }*/

            return new UsuarioViewModel { };
        }

        public List<UsuarioViewModel> GetAllUsuarios()
        {
            List<UsuarioViewModel> lista = new List<UsuarioViewModel>();
            try
            {
                HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/Usuario/GetUsers");

                if (responseMessage != null && responseMessage.IsSuccessStatusCode)
                {
                    var content = responseMessage.Content.ReadAsStringAsync().Result;
                    Console.WriteLine("Raw JSON Response: " + content);

                    try
                    {
                        var result = JsonConvert.DeserializeObject<List<UserAPI>>(content);


                        Console.WriteLine("Deserialized Result Count: " + result?.Count);

                        if (result != null)
                        {
                            foreach (var item in result)
                            {
                                lista.Add(new UsuarioViewModel
                                {
                                    Id = item.Id,
                                    Username = item.Username,
                                    Email = item.Email,
                                    Password = item.Password,
                                    Roles = item.Roles
                                });
                            }
                        }
                    }
                    catch (JsonException jsonEx)
                    {
                        Console.WriteLine("JSON Deserialization Error: " + jsonEx.Message);
                    }
                }
                else
                {
                    Console.WriteLine("HTTP Error: " + responseMessage?.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            return lista;
        }

        public UsuarioViewModel GetUsuarioId(string id)
        {
            UsuarioViewModel usuarioViewModel = null;

            try
            {
                HttpResponseMessage responseMessage = _serviceRepository.GetResponse($"api/Usuario/GetUser/{id}");

                if (responseMessage != null && responseMessage.IsSuccessStatusCode)
                {
                    var content = responseMessage.Content.ReadAsStringAsync().Result;

                    Console.WriteLine("Raw JSON Response: " + content);

                    try
                    {
                        var responseObject = JsonConvert.DeserializeAnonymousType(content, new
                        {
                            User = new UserAPI(),
                            Roles = new List<string>()
                        });

                        if (responseObject != null)
                        {
                            usuarioViewModel = new UsuarioViewModel
                            {
                                Id = responseObject.User.Id,
                                Username = responseObject.User.Username,
                                Email = responseObject.User.Email,
                                Password = responseObject.User.Password, 
                                Roles = responseObject.Roles
                            };
                        }
                    }
                    catch (JsonException jsonEx)
                    {
                        Console.WriteLine("JSON Deserialization Error: " + jsonEx.Message);
                    }
                }
                else
                {
                    Console.WriteLine("HTTP Error: " + responseMessage?.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            return usuarioViewModel;
        }
    }


}

