using Department_Management.Application.Common.Interfaces;
using Department_Management.Application.Common.Mappings;
using Department_Management.Application.Common.Models;

namespace Department_Management.Application.Departments.Queries.GetDepartmentWithPagination;

public record GetDepartmentWithPaginationQuery : IRequest<PaginatedList<DepartmentDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
public class GetDepartmetWithPaginationQueryHandler : IRequestHandler<GetDepartmentWithPaginationQuery, PaginatedList<DepartmentDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetDepartmetWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<DepartmentDto>> Handle(GetDepartmentWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Departments
            .OrderBy(x => x.Name)
            .ProjectTo<DepartmentDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
