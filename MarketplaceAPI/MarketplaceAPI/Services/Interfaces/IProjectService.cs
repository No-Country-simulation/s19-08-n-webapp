using MarketplaceAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarketplaceAPI.Services.Interfaces
{
    public interface IProjectService
    {
        Task<List<Project>> ListaProyectos();
        Task<Project> GetProject(int idProject);
        Task<Project> AgregarProject(Project project);
        Task EliminarProject(int idProject);
        Task<Project> ActualizarProject(Project project);
        Task<List<ProjectContributor>> ListarColaboradores();
        Task<List<ProjectContributor>> obtenerColaborador(int idProjectColaborador);

    }//end 
}//end
