using MarketplaceAPI.Data;
using MarketplaceAPI.Models;
using MarketplaceAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;

namespace MarketplaceAPI.Services
{
    public class ProjectService : IProjectService
    {
        private readonly DBContextMarketplace _DBContextMarketplace;
        private readonly IUserService _userService;


        public ProjectService(DBContextMarketplace dbContext, IUserService userService) {
            _DBContextMarketplace = dbContext;
            _userService = userService;
        }


       
        public async Task<List<Project>> ListaProyectos() {
            return await _DBContextMarketplace.Projects.ToListAsync();
        }//end


        public async Task<Project> GetProject(int idProj)
        {
            var dataProject = await _DBContextMarketplace.Projects.FirstOrDefaultAsync(x => x.idProject == idProj);
            if (dataProject == null) 
                throw new KeyNotFoundException($"Project with ID {idProj} not found.");
            
            return dataProject;
        }//end


        public async Task EliminarProject(int idProject) {
            var dataProject = await GetProject(idProject);
            _DBContextMarketplace.Projects.Remove(dataProject);
            await _DBContextMarketplace.SaveChangesAsync();
        }//end


        public async Task<Project> AgregarProject(Project project)
        {
            var dataUser = await _userService.ObtenerUsuario(project.idUserRequester);
            if (dataUser == null)
                throw new ArgumentException($"The user ID {project.idUserRequester} no exist.");

            _DBContextMarketplace.Projects.Add(project);
            await _DBContextMarketplace.SaveChangesAsync();
            return project;
        }//end


        public async Task<Project> ActualizarProject(int idProject, Project updateProject)
        {
            var existProject = await GetProject(idProject);

            // Validar que los campos no modificables no hayan cambiado
            if (updateProject.idProject != 0 && updateProject.idProject != existProject.idProject ||
                updateProject.idPublication != 0 && updateProject.idPublication != existProject.idPublication ||
                updateProject.idUserRequester != 0 && updateProject.idUserRequester != existProject.idUserRequester)
            {
                throw new ArgumentException("Cannot modify fields 'idProject', 'idPublication', or 'idUserRequester'.");
            }

            existProject.nameProject = updateProject.nameProject;
            existProject.description = updateProject.description;
            existProject.startDate = updateProject.startDate;
            existProject.endDate = updateProject.endDate;
            existProject.stateProject = updateProject.stateProject;


            _DBContextMarketplace.Projects.Update(existProject);
            await _DBContextMarketplace.SaveChangesAsync();
           return existProject;
        }//end



        public async Task<List<ProjectContributor>> ListarColaboradores() {
            return await _DBContextMarketplace.ProjectContributors.ToListAsync();
        }//end


        public async Task<List<ProjectContributor>> obtenerListProjecColaborador(int idUserContributor)
        {
            var dataColaborador = await _DBContextMarketplace.ProjectContributors.
                Where(x => x.idUserContributor == idUserContributor).ToListAsync();
            if (!dataColaborador.Any()) 
                throw new KeyNotFoundException($"The contributor is not registered in any project");
            return dataColaborador;
        }//end



        public async Task<string> AgregarColaborador(int idProject, int idCollaborator)
        {
            var dataProject = await GetProject(idProject);

            var dataUser = await _userService.ObtenerUsuario(idCollaborator);
            if (dataUser == null)
                throw new InvalidOperationException($"The user ID {idCollaborator} no exist.");

            //si ya esta registrado
            var existContributor = await _DBContextMarketplace.ProjectContributors
                .AnyAsync(pc => pc.idProject == idProject && pc.idUserContributor == idCollaborator);
            if (existContributor)
                throw new InvalidOperationException($"Collaborator with ID {idCollaborator} is already part of project {idProject}.");

            var collaboratorName = await _DBContextMarketplace.Users
                    .Where(u => u.IdUser == idCollaborator)
                    .Select(u => u.FirstName)
                    .FirstOrDefaultAsync();

            var newContributor = new ProjectContributor
            {
                idProject = idProject,
                idUserContributor = idCollaborator,
                FirstName = collaboratorName,
                applicationDate = DateTime.Now,
                status = "Pending"
            };

            _DBContextMarketplace.ProjectContributors.Add(newContributor);
            await _DBContextMarketplace.SaveChangesAsync();

            return $"Collaborator {newContributor.FirstName} added to project {idProject} successfully.";

        }

        //----------------------------------------------------------
        public async Task<List<Evaluation>> ListaEvaluacion()
        {
            return await _DBContextMarketplace.Evaluations.ToListAsync();
        }

       



    }//end class
}//end 
