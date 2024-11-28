using MarketplaceAPI.Models;

namespace MarketplaceAPI.Repositorys.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> ListarUsuarios();
        Task<User> ObtenerUsuario(int idUsuario);
        Task<User> ObtenerUsuarioConEmail(string correoElectronico);
        Task<User> ActualizarUsuario(User usuario);
        Task EliminarUsuario(int idUsuario);
    }
}
