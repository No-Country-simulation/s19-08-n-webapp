using MarketplaceAPI.Data;
using MarketplaceAPI.Models;
using MarketplaceAPI.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace MarketplaceAPI.Repositorys
{
    public class UserRepository : IUserRepository
    {
        private readonly DBContextMarketplace _DBContextMarketplace;

        public UserRepository(DBContextMarketplace DBContextMarketplace)
        {
            _DBContextMarketplace = DBContextMarketplace;
        }

        public async Task<List<User>> ListarUsuarios()
        {
            return await _DBContextMarketplace.Users.ToListAsync();
        }

        public async Task<User> ObtenerUsuario(int idUsuario)
        {
            return await _DBContextMarketplace.Users.Where(x => x.idUser == idUsuario).FirstOrDefaultAsync();
        }

        public async Task<User> ObtenerUsuarioConEmail(string correoElectronico)
        {
            return await _DBContextMarketplace.Users.Where(x => x.email == correoElectronico).FirstOrDefaultAsync();
        }

        public async Task<User> ActualizarUsuario(User usuario)
        {
            _DBContextMarketplace.Users.Update(usuario);
            await _DBContextMarketplace.SaveChangesAsync();
            return usuario;
        }

        public async Task EliminarUsuario(int idUsuario)
        {
            var usuario = await ObtenerUsuario(idUsuario);
            _DBContextMarketplace.Entry(usuario).State = EntityState.Deleted;
            await _DBContextMarketplace.SaveChangesAsync();
        }


    }
}
