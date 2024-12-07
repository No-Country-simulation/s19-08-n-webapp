using MarketplaceAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarketplaceAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> ListarUsuarios();
        Task<User> ObtenerUsuario(int idUsuario);
        Task<User> ObtenerUsuarioConEmail(string correoElectronico);
        Task<User> ActualizarUsuario(User usuario);
        Task EliminarUsuario(int idUsuario);

        
    }
}
