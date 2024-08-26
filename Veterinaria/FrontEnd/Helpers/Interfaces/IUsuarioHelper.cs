using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IUsuarioHelper
    {
        List<UsuarioViewModel> GetAllUsuarios();
        UsuarioViewModel GetUsuarioId(string id);
        UsuarioViewModel AddUsuario(UsuarioViewModel UsuarioViewModel);
        UsuarioViewModel EditUsuario(string id, UsuarioViewModel UsuarioViewModel);
        void DeleteUsuario(string id);
    }
}
