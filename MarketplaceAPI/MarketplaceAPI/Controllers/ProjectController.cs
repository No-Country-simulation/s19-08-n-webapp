using MarketplaceAPI.Data;
using MarketplaceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [RequireHttps]

    public class ProjectController : ControllerBase {

        private readonly DBContextMarketplace _context = null;

        public ProjectController(DBContextMarketplace pContext) {
            _context = pContext;
        }

        //--------------------------------------CRUD-Project--------------------------------------//

        //return the list of project
        [HttpGet("ListProject")]
        public async Task<IActionResult> ListProject() {
            try {

                var list = await _context.Projects.ToListAsync();

                if (list == null || !list.Any()) {
                    return NotFound(new { message = "Projects Not Found" });
                }

                return Ok(list);

            } catch (Exception ex) {
                return StatusCode(500, new { message = "ERROR" });
            }
        }//end of method block

        //--------------------------------------------------------------------------------//
        //search for a proyect 
        [HttpGet("SearchProject/{id}")]
        public async Task<IActionResult> SearchProject(int id) {
            try {
                var data = await _context.Projects.FirstOrDefaultAsync(x => x.idProject == id);

                if (data == null) {
                    return NotFound(new { message = $"Project with ID {id} not found" });
                }

                return Ok(data);

            } catch (Exception ex) {
                return GetExceptions(ex, "An error occurred while running the project.");
            }
        }//end of method block

        //--------------------------------------------------------------------------------//
        //delete for project
        [HttpDelete("DeleteProject/{id}")]
        public async Task<IActionResult> DeleteProject(int id) {
            try {
                var data = await _context.Projects.FirstOrDefaultAsync(x => x.idProject == id);

                if (data == null) {
                    return NotFound(new { message = $"The project ID {id} was not found." });
                }

                _context.Projects.Remove(data);
                await _context.SaveChangesAsync();
                return Ok(new { message = $"Project {data.nameProject} succes" });

            } catch (Exception ex) {
                return GetExceptions(ex, "An error occurred while running the project.");
            }
        }//end of method delete


        //--------------------------------------------------------------------------------//
        //Add project
        [HttpPost("AddProject")]
        public async Task<IActionResult> AddProject(Project project) {
            try {
                var data = await _context.Projects.FindAsync(project.idProject);

                if (data != null) {
                    return NotFound(new { message = $"The project is already registered" });
                }
                _context.Projects.Add(project);
                await _context.SaveChangesAsync();
                return Ok(new { idProject = project.idProject, message = $"Project ID {project.idProject} name {project.nameProject} added successfully!" });

            } catch (Exception ex) {
                return GetExceptions(ex, "An error occurred while running the project.");
            }
        }//end method

        //--------------------------------------------------------------------------------//
        //chage project
        [HttpPost("ChangeProject")]
        public async Task<IActionResult> ChangeProject(Project project)
        {
            try {
                //project exists?
                var data = await _context.Projects.FindAsync(project.idProject);

                if (data == null) {
                    return NotFound(new { message = $"The project ID was not found." });
                }

                // validate that the 'idUserRequester' cannot be manipulated
                if (project.idUserRequester != 0 && project.idUserRequester != data.idUserRequester) {
                    return BadRequest(new {
                        message = "The 'idUserRequester' field cannot be modified."
                    });
                }

                //validate that the 'idPublication' cannot be manipulated
                if (project.idPublication != 0 && project.idPublication != data.idPublication) {
                    return BadRequest(new {
                        message = "The 'idPublication' field cannot be modified."
                    });
                }

                //assign the values ​​of the BD
                project.idUserRequester = data.idUserRequester;
                project.idPublication = data.idPublication;

                //Update Data
                data.nameProject = project.nameProject;
                data.description = project.description;
                data.startDate = project.startDate;
                data.endDate = project.endDate;
                data.stateProject = project.stateProject;

                //Save changes
                await _context.SaveChangesAsync();

                return Ok(new {
                    idProject = project.idProject,
                    message = $"Project ID {project.idProject} name {project.nameProject} changed successfully..."
                });
            }
            catch (Exception ex)
            {
                return GetExceptions(ex, "An error occurred while running the project.");
            }
        }
        //--------------------------------------END-CRUD-PROJECT--------------------------------------//

        //EXTRA METHODS
        //--------------------------------------------------------------------------------//
        //search for a proyect 
        [HttpGet("ListColaborator")]
        public async Task<IActionResult> ListColaborator() {
            try {
                var list = await _context.ProjectContributors.ToListAsync();

                if (list == null || !list.Any()) {
                    return NotFound(new { message = "Projects Not Found" });
                }
                return Ok(list);
            } catch (Exception ex) {
                return StatusCode(500, new { message = "ERROR" });
            }
        }//end of method block

        //---------------------------------------------------------------------------------------------------
        //search for collaborator in the project collaborator table
        [HttpGet("SearchUserColaborator/{id}")]
        public async Task<IActionResult> SearchUserColaborator(int id) {
            try {
                var data = await _context.ProjectContributors.FirstOrDefaultAsync(x => x.idUserContributor == id);

                //collaborator exist?
                if (data == null) {
                    return NotFound(new { message = $"The user ID {id} not registered in the Project" });
                }
                return Ok(data);

            } catch (Exception ex) {
                return GetExceptions(ex, "An error occurred while running the project.");
            }//end
        }//end of method block

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
