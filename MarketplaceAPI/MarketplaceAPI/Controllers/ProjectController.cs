using MarketplaceAPI.Data;
using MarketplaceAPI.Models;
using MarketplaceAPI.Services;
using MarketplaceAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace MarketplaceAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    
    //falta FK
    public class ProjectController : ControllerBase {

        private readonly IProjectService _projectService;
       
        public ProjectController(IProjectService projectService) {
            _projectService = projectService;
        }

        //--------------------------------------CRUD-Project--------------------------------------//

        //return the list of project
        [HttpGet("ListProject")]
        public async Task<ActionResult<List<Project>>> ListProject() {
            var projects = await _projectService.ListaProyectos();
            return Ok(projects);

        }//end 
        
       
        [HttpGet("GetProject/{id}")]
        public async Task<ActionResult<Project>> GetProject(int id) {
            try {
                var dataProject = await _projectService.GetProject(id);
                return Ok(dataProject);
            } catch (KeyNotFoundException ex) {
                return NotFound(new { message = ex.Message });
            }

        }//end of method block

       
        [HttpDelete("DeleteProject/{id}")]
        public async Task<ActionResult> DeleteProject(int id) {
            try {
                var dataProject = await _projectService.GetProject(id);
                await _projectService.EliminarProject(id);
                return Ok("Project Delete");

            } catch (KeyNotFoundException ex) {
                return NotFound(new { message = ex.Message });
            }

        }//end of method delete


        [HttpPost("AddProject")]
        public async Task<ActionResult<Project>> AddProject(Project addProject)
        {
            try {
                await _projectService.AgregarProject(addProject);
                return Ok($"Project ID {addProject.idProject} name {addProject.nameProject} added successfully!");
            } catch (ArgumentException ex) {
                return NotFound(new { message = ex.Message });
            }//end
        }


        [HttpPost("UpdateProject/{id}")]
        public async Task<ActionResult> UpdateProject(int id, [FromBody] Project updatedProject)
        {
            try {
                var result = await _projectService.ActualizarProject(id, updatedProject);
                return Ok($"El proyecto con ID {id} fue actualizado exitosamente.");
            } catch (ArgumentException ex) {
                return NotFound(new { message = ex.Message });
            }

        }//end methot


        //--------------------------------------END-CRUD-PROJECT--------------------------------------//

        [HttpGet("ListColaborator")]
        public async Task<IActionResult> ListColaborator() {
            var list = await _projectService.ListarColaboradores();
            return Ok(list);
        }//end of method


        
        //search for collaborator in the project collaborator table
        [HttpGet("getProjectColaborator/{idContributor}")]
        public async Task<IActionResult> getProjectColaborator(int idContributor) {
            try { 
                var dataColaborator = await _projectService.obtenerListProjecColaborador(idContributor);
                return Ok(dataColaborator);

            } catch (KeyNotFoundException ex) {
                return NotFound(new { message = ex.Message });
            }
        }//end of method

        //---------------------------------------------------------------------------------------------------

        //add Collaborator 
        [HttpPost("AddCollaborator")]
        public async Task<IActionResult> AddCollaborator(int idProject, int idCollaborator) {
            try {
                var message = await _projectService.AgregarColaborador(idProject, idCollaborator);
                return Ok(new { message });
            } catch (InvalidOperationException ex) {
                return NotFound(new { message = ex.Message });
            }
        }

        //-----------------------------------------------------------------------------------------------------
        [HttpGet("ListEvaluation")]
        public async Task<IActionResult> ListEvaluation() {
            var list = await _projectService.ListaEvaluacion();
            return Ok(list);
        }//end

       
        

    }//end class block

}//end namespaces
