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
        Task<Project> ActualizarProject(int idProject, Project project);
        Task<List<ProjectContributor>> ListarColaboradores();
        Task<List<ProjectContributor>> obtenerListProjecColaborador(int idUserContributor);

        Task<string> AgregarColaborador(int idProject, int idCollaborator);
        Task<List<Evaluation>> ListaEvaluacion();


    }//end 
}//end
