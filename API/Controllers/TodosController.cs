using API.Requests;
using Application.Todos.Commands.CreateTodo;
using Application.Todos.Commands.DeleteTodo;
using Application.Todos.Commands.UpdateTodo;
using Application.Todos.Queries.GetTodoById;
using Application.Todos.Queries.GetTodos;
using Domain.Todos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodosController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await mediator.Send(new GetTodosQuery());
        return Ok(result);
    }

    [HttpGet("{id}", Name = "GetTodoById")]
    public async Task<IActionResult> Get(Guid id)
    {
        var todo = await mediator.Send(new GetTodoByIdQuery(id));

        return todo is null ? NotFound() : Ok(todo);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateTodoRequest request)
    {
        var command = new CreateTodoCommand(request.Title);

        var id = await mediator.Send(command);

        return CreatedAtRoute("GetTodoById", new { id }, null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, UpdateTodoRequest request)
    {        
        var command = new UpdateTodoCommand(id, request.Title, request.Completed); 

        if (id != command.Id)
            return BadRequest("Id in URL and request body must match");

        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await mediator.Send(new DeleteTodoCommand(id));
        return NoContent();
    }

}