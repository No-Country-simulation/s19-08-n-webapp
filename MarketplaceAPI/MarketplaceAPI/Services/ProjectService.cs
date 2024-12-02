using MarketplaceAPI.Data;
using MarketplaceAPI.Models;
using MarketplaceAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceAPI.Services
{
    public class ProjectService : IProjectService
    {
        private readonly DBContextMarketplace _DBContextMarketplace;

        public ProjectService(DBContextMarketplace dbContext) {
            _DBContextMarketplace = dbContext;
        }

        //listar
        public async Task<List<Project>> ListaProyectos() {
            return await _DBContextMarketplace.Projects.ToListAsync();
        }//end

        public async Task<Project> GetProject(int idProj)
        {
            return await _DBContextMarketplace.Projects.FirstOrDefaultAsync(x => x.idProject == idProj);
        }//end

        public async Task EliminarProject(int idProject) {
            var dataProject = await GetProject(idProject);
            _DBContextMarketplace.Projects.Remove(dataProject);
            await _DBContextMarketplace.SaveChangesAsync();
        }//end

        public async Task<Project> AgregarProject(Project project)
        {
            _DBContextMarketplace.Projects.Add(project);
            await _DBContextMarketplace.SaveChangesAsync();
            return project;
        }//end

        public async Task<Project> ActualizarProject(Project project)
        {
            _DBContextMarketplace.Projects.Update(project);
            await _DBContextMarketplace.SaveChangesAsync();
            return project;
        }//end

        public async Task<List<ProjectContributor>> ListarColaboradores()
        {
            return await _DBContextMarketplace.ProjectContributors.ToListAsync();
        }//end

        public async Task<List<ProjectContributor>> obtenerColaborador(int idProjectColaborador)
        {
            return await _DBContextMarketplace.ProjectContributors.Where(x => x.idUserContributor == idProjectColaborador).ToListAsync();
        }//end

    }//end class
}//end 
