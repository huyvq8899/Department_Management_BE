using Department_Management.Application.Common.Models;
using Department_Management.Application.TodoItems.Commands.CreateTodoItem;
using Department_Management.Application.TodoItems.Commands.DeleteTodoItem;
using Department_Management.Application.TodoItems.Commands.UpdateTodoItem;
using Department_Management.Application.TodoItems.Commands.UpdateTodoItemDetail;
using Department_Management.Application.TodoItems.Queries.GetTodoItemsWithPagination;

namespace Department_Management.Web.Endpoints;
public class TodoItems : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetTodoItemsWithPagination1)
            .MapPost(CreateTodoItem)
            .MapPut(UpdateTodoItem, "{id}")
            .MapPut(UpdateTodoItemDetail, "UpdateDetail/{id}")
            .MapDelete(DeleteTodoItem, "{id}");
    }

    public Task<PaginatedList<TodoItemBriefDto>> GetTodoItemsWithPagination1(ISender sender, [AsParameters] GetTodoItemsWithPaginationQuery query)
    {
        return sender.Send(query);
    }

    public Task<Guid> CreateTodoItem(ISender sender, CreateTodoItemCommand command)
    {
        return sender.Send(command);
    }

    public async Task<IResult> UpdateTodoItem(ISender sender, int id, UpdateTodoItemCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> UpdateTodoItemDetail(ISender sender, int id, UpdateTodoItemDetailCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeleteTodoItem(ISender sender, int id)
    {
        await sender.Send(new DeleteTodoItemCommand(id));
        return Results.NoContent();
    }
}
