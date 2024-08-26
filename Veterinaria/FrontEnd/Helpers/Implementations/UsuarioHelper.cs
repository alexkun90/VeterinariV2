using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace FrontEnd.Helpers.Implementations
{
    public class UsuarioHelper : IUsuarioHelper
    {
        IServiceRepository _serviceRepository;
        public UsuarioHelper(IServiceRepository serviceRepository)
        {
            this._serviceRepository = serviceRepository;
        }

        public UsuarioViewModel AddUsuario(UsuarioViewModel usuarioViewModel)
        {
            
            var userAPI = new UserAPI
            {
                Id = usuarioViewModel.Id,
                Username = usuarioViewModel.Username,
                Email = usuarioViewModel.Email,
                Password = usuarioViewModel.Password,
                Roles = usuarioViewModel.Roles
            };

            var responseMessage = _serviceRepository.PostResponse("api/Usuario/CreateUser", userAPI);

            if (responseMessage != null && responseMessage.IsSuccessStatusCode)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                var createdUser = JsonConvert.DeserializeObject<UserAPI>(content);

                return new UsuarioViewModel
                {
                    Id = createdUser.Id,
                    Username = createdUser.Username,
                    Email = createdUser.Email,
                    Roles = createdUser.Roles
                };
            }
            else
            {
                Console.WriteLine("HTTP Error: " + responseMessage?.StatusCode);
                throw new Exception("Error al crear el usuario.");
            }
        }

        public void DeleteUsuario(string id)
        {
            HttpResponseMessage responseMessage = _serviceRepository.DeleteResponse("api/Usuario/DeleteUser/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }
        }

        public UsuarioViewModel EditUsuario(string id, UsuarioViewModel usuarioViewModel)
        {
            var userAPI = new UserAPI
            {
                Id = usuarioViewModel.Id,
                Username = usuarioViewModel.Username,
                Email = usuarioViewModel.Email,
                Password = usuarioViewModel.Password,
                Roles = usuarioViewModel.Roles
            };

            var responseMessage = _serviceRepository.PutResponse($"api/Usuario/UpdateUser/{id}", userAPI);

            if (responseMessage != null && responseMessage.IsSuccessStatusCode)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;

                var updatedUser = JsonConvert.DeserializeObject<UserAPI>(content);

                return new UsuarioViewModel
                {
                    Id = updatedUser.Id,
                    Username = updatedUser.Username,
                    Email = updatedUser.Email,
                    Roles = updatedUser.Roles
                };
            }
            else
            {
                Console.WriteLine("HTTP Error: " + responseMessage?.StatusCode);
                throw new Exception("Error al actualizar el usuario.");
            }
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

