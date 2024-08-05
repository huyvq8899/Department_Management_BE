using Department_Management.Application.Common.Models;
using Department_Management.Application.Departments.Queries.GetDepartmentWithPagination;
namespace Department_Management.Web.Endpoints;


public class Departments : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this).RequireAuthorization().MapGet(GetDepartmentWithPagination);
    }

    public Task<PaginatedList<DepartmentDto>> GetDepartmentWithPagination(ISender sender, [AsParameters] GetDepartmentWithPaginationQuery query)
    {
        return sender.Send(query);
    }

}
