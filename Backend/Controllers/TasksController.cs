using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Project_Backend_2024.Controllers.CommandControllers;

[Route("api/Tasks")]
[ApiController]
public class TasksController() : ControllerBase
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "AdminOrUser")]
    [HttpPost("create")]
    public async Task CreateTaskCommand([FromBody] TaskModel taskModel)
    {
        try
        {

            var result = new TaskModel
            {
                Id = taskModel.Id,
                Title = taskModel.Title,
                Description = taskModel.Description,
                DueDate = taskModel.DueDate,
                Status = taskModel.Status,
                Priority = taskModel.Priority,
                Objectives = taskModel.Objectives
            };

            return Ok("created!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest("uh, oh, could not create task!!");
        }
    }
}