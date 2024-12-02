using MarketplaceAPI.Data;
using MarketplaceAPI.Models;
using MarketplaceAPI.Services;
using MarketplaceAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [RequireHttps]

    //falta FK
    public class ProjectController : ControllerBase {

        private readonly IProjectService _projectService;

        //delete
        private readonly DBContextMarketplace _context = null;

        public ProjectController(IProjectService projectService) {
            _projectService = projectService;
        }

        //--------------------------------------CRUD-Project--------------------------------------//

        //return the list of project
        [HttpGet("ListProject")]
        public async Task<ActionResult<List<Project>>> ListProject() {
            var projects = await _projectService.ListaProyectos();
            if (projects == null) 
                throw new ArgumentException("La lista de proyectos está vacía");
          
            return Ok(projects);

        }//end 

       
        [HttpGet("GetProject/{id}")]
        public async Task<ActionResult<Project>> GetProject(int id) {
            var dataProject = await _projectService.GetProject(id);
                
            if (dataProject == null) 
                return NotFound(new { message = $"Project with ID {id} not found" });
            
            return Ok(dataProject);
        }//end of method block

       
        [HttpDelete("DeleteProject/{id}")]
        public async Task<ActionResult> DeleteProject(int id) {
            var dataProject = await _projectService.GetProject(id);

            if (dataProject == null) 
                return NotFound(new { message = $"The project ID {id} was not found." });

            await _projectService.EliminarProject(id);
            return Ok("Project Delete");    
           
        }//end of method delete
        

        [HttpPost("AddProject")]
        public async Task<ActionResult<Project>> AddProject(Project addProject, int idProject) {
            var dataProject = await _projectService.GetProject(addProject.idProject);

            if (dataProject != null)
                return BadRequest($"The project is already registered");

            await _projectService.AgregarProject(addProject);
            return Ok(new {idProject = addProject.idProject, message = $"Project ID {idProject} name {addProject.nameProject} added successfully!" });

        }//end method add


        [HttpPost("UpdateProject")]
        public async Task<ActionResult> UpdateProject(Project project, int idProject) {
            var dataProject = await _projectService.GetProject(idProject);

            if (dataProject == null)
                return NotFound(new { message = $"The project ID was not found." });

            if (project.idUserRequester != 0 && project.idUserRequester != dataProject.idUserRequester)
                return BadRequest(new { message = "The 'idUserRequester' field cannot be modified." });

            if (project.idPublication != 0 && project.idPublication != dataProject.idPublication)
                return BadRequest(new { message = "The 'idPublication' field cannot be modified." });

            //Update Data
            dataProject.nameProject = project.nameProject;
            dataProject.description = project.description;
            dataProject.startDate = project.startDate;
            dataProject.endDate = project.endDate;
            dataProject.stateProject = project.stateProject;

            await _projectService.ActualizarProject(dataProject);

            return Ok($"Project ID {idProject} name {project.nameProject} update successfully...");

        }//end methot



        //--------------------------------------END-CRUD-PROJECT--------------------------------------//

        [HttpGet("ListColaborator")]
        public async Task<IActionResult> ListColaborator() {
            var list = await _projectService.ListarColaboradores();
            if (list == null || !list.Any())
                return NotFound(new { message = "Projects Not Found" });

            return Ok(list);
        }//end of method


        
        //search for collaborator in the project collaborator table
        [HttpGet("getProjectColaborator/{id}")]
        public async Task<IActionResult> getProjectColaborator(int id) {
            var dataColaborator = await _projectService.obtenerColaborador(id);

            if (dataColaborator == null)
                return NotFound(new { message = $"The user ID {id} not registered in the Project" });

            return Ok(dataColaborator);
        }//end of method

        //---------------------------------------------------------------------------------------------------

        //add Collaborator 
        [HttpPost("AddCollaborator")]
        public async Task<IActionResult> AddCollaborator(int idProject, int idCollaborator) {
            try {
                //Project exists?
                var data = await _context.Projects.FindAsync(idProject);
                if (data == null) {
                    return NotFound(new { message = $"¡Project with ID {idProject} not found!" });
                }

                //get collaborator name from user table
                var collaboratorName = await _context.Users
                    .Where(u => u.IdUser == idCollaborator)
                    .Select(u => u.FirstName)
                    .FirstOrDefaultAsync();

                //collaborator exist?
                if (collaboratorName == null) {
                    return NotFound(new { message = $"Collaborator with ID {idCollaborator} not found." });
                }

                var tempContributor = await _context.ProjectContributors
                    .FirstOrDefaultAsync(pc => pc.idProject == idProject && pc.idUserContributor == idCollaborator);

                //The collaborator is part of the project
                if (tempContributor != null) {
                    return Conflict(new { message = $"Collaborator with ID {idCollaborator} is already part of project {idProject}." });
                }

                // add new collaborator
                var newContributor = new ProjectContributor {
                    idProject = idProject,
                    idUserContributor = idCollaborator,
                    nameContributor = collaboratorName,
                    applicationDate = DateTime.Now,
                    status = "Pending" //initial state
                };

                _context.ProjectContributors.Add(newContributor);
                await _context.SaveChangesAsync();

                //show information
                return Ok(new {
                    idProject = idProject,
                    idCollaborator,
                    collaboratorName,
                    message = $"Collaborator {collaboratorName} added to project {idProject} successfully."
                });

            } catch (Exception ex) {
                return GetExceptions(ex, "An error occurred while running the project.");
            }//end
        } // end method

        //-------------------------------------------------------------------------------------------------

        /*
         method that changes the accepted or rejected status of a collaborating user
         */

        [HttpPost("CollaboratorStatus")]
        public async Task<IActionResult> CollaboratorStatus(int idProject, int idCollaborator, string status)
        {
            try {

                var collaborator = await _context.ProjectContributors.FirstOrDefaultAsync(x => x.idUserContributor == idCollaborator
                && x.idProject == idProject);

                //collaborator exist in the project?
                if (collaborator == null) {
                    return NotFound(new { message = $"The Collaborator with ID {idCollaborator} not found int project id {idProject}" });
                }

                if (status.Equals("Rejected", StringComparison.OrdinalIgnoreCase))
                {
                    _context.ProjectContributors.Remove(collaborator);
                    await _context.SaveChangesAsync();
                    return Ok(new { message = $"Collaborator whit id {idCollaborator} removed from project {idProject}" });
                }
                else
                {
                    if (status.Equals("Accepted", StringComparison.OrdinalIgnoreCase))
                    {
                        collaborator.status = "Accepted";
                        _context.ProjectContributors.Update(collaborator);
                        await _context.SaveChangesAsync();

                        return Ok(new { message = $"Collaborator with ID {idCollaborator} was accepted in project {idProject}." });
                    }
                }

                // Si el estado no es válido
                return BadRequest(new {
                    message = $"Invalid status '{status}'. Only 'Accepted' or 'Rejected' are allowed."
                });

            } catch (Exception ex) {
                return GetExceptions(ex, "An error occurred while running the project.");
            }//end
        }//end method
            
        //-----------------------------------------------------------------------------------------------------
        [HttpGet("ListEvaluation")]
        public async Task<IActionResult> ListEvaluation()
        {
            try{
                var list = await _context.Evaluations.ToListAsync();

                if (list == null || !list.Any()) {
                    return NotFound(new { message = "Projects Not Found" });
                }
                return Ok(list);

            } catch (Exception ex) {
                return StatusCode(500, new { message = "ERROR" });
            }
        }//end of method block

        //-----------------------------------------------------------------------------------------------------
        /*evaluation method
            one, the project has to be finished
            two, there has to be a validation between the collaborating project table that this user is accepted
            three extract the name from the user table*/

        
        [HttpPost("Evaluate")]
        public async Task<IActionResult> Evaluate(Evaluation evaluation, int idUserEvaluator, int idUserEvaluted)
        {
            try {
                //validate scale
                if (evaluation.rating < 1 || evaluation.rating > 5) {
                    return BadRequest(new { message = "The rating must be between 1 and 5." });
                }

                // project exists?
                var project = await _context.Projects.FirstOrDefaultAsync(p => p.idProject == evaluation.idProject);
                if (project == null) {
                    return NotFound(new { message = $"Project with ID {evaluation.idProject} not found." });
                }

                //The project status is valid?
                var validStates = new[] { "close", "end" };
                if (!validStates.Contains(project.stateProject.ToLower())) {
                    return BadRequest(new { message = "The project must be 'Close' or 'End' to allow evaluations." });
                }

                //evaluation exists in table evaluation?
                var exists = await _context.Evaluations.FirstOrDefaultAsync(e =>
                    e.idProject == evaluation.idProject &&
                    e.idEvaluatorUser == idUserEvaluator &&
                    e.idEvaluatedUser == idUserEvaluted);

                //yes exists error
                if (exists != null) {
                    return BadRequest(new { message = "An evaluation already exists for this evaluator and evaluated user in the project." });
                }

                //select to extract the user name 
                var users = await _context.Users
                    .Where(u => u.IdUser == idUserEvaluator || u.IdUser == idUserEvaluted)
                    .Select(u => new { u.IdUser, u.FirstName })
                    .ToListAsync();


                var evaluatorName = users.FirstOrDefault(u => u.IdUser == idUserEvaluator)?.FirstName;
                var evaluatedName = users.FirstOrDefault(u => u.IdUser == idUserEvaluted)?.FirstName;

                //users not exists
                if (string.IsNullOrEmpty(evaluatorName)){
                    return BadRequest(new { message = $"User with ID {idUserEvaluator} does not exist." });
                }

                if (string.IsNullOrEmpty(evaluatedName)) {
                    return BadRequest(new { message = $"User with ID {idUserEvaluted} does not exist." });
                }

                /*----------------------------------------------------------------------------------------------------
                                                        Evaluate owner and collaborator
                -----------------------------------------------------------------------------------------------------*/

                //OWNER
                if (idUserEvaluted == project.idUserRequester) { 
                    // Evaluando al dueño del proyecto
                    var evaluationOwner = CreateEvaluation(evaluation, idUserEvaluator, idUserEvaluted, evaluatedName);//method call
                    _context.Evaluations.Add(evaluationOwner);

                } else {
                    //COLLABORATOR
                    var collaborator = await _context.ProjectContributors
                        .FirstOrDefaultAsync(pc => pc.idProject == evaluation.idProject &&
                                                   pc.idUserContributor == idUserEvaluted &&
                                                   pc.status.Equals("Accepted", StringComparison.OrdinalIgnoreCase));//validation

                    if (collaborator == null) {
                        return BadRequest(new {message = $"The user with ID {idUserEvaluted} is not an accepted collaborator in the project."});
                    }

                    var evaluationCollaborator = CreateEvaluation(evaluation, idUserEvaluator, idUserEvaluted, evaluatedName);//method call
                    _context.Evaluations.Add(evaluationCollaborator);
                }//end if
               
                //save the evaluation in the BD
                await _context.SaveChangesAsync();
                return Ok(new { message = "Evaluation submitted successfully." });

            } catch (Exception ex) {
                return GetExceptions(ex, "An error occurred while submitting the evaluation.");
            }//end
        }//end method

        //---------------------------------------------------------------------------------------------------
        private IActionResult GetExceptions(Exception ex, string customMessage)
        {
            var errorMessage = ex.InnerException?.Message ?? ex.Message;
            return StatusCode(500, new
            {
                message = customMessage,
                error = errorMessage
            });
        }//end method

        //---------------------------------------------------------------------------------------------------
        // method create evaluation
        private Evaluation CreateEvaluation(Evaluation evaluation, int idEvaluator, int idEvaluated, string evaluatedName) {
            return new Evaluation {
                idProject = evaluation.idProject,
                idEvaluatorUser = idEvaluator,
                idEvaluatedUser = idEvaluated,
                nameEvaluated = evaluatedName,
                rating = evaluation.rating,
                comment = evaluation.comment,
                dateTime = DateTime.Now
            };
        }//end method

    }//end class block

}//end namespaces
