﻿using Department_Management.Application.Common.Interfaces;
using Department_Management.Domain.Entities;

namespace Department_Management.Application.Departments.Commands.CreateDepartment;

public record CreateDepartmentCommamd : IRequest<Guid>
{
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
}
public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommamd, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateDepartmentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateDepartmentCommamd request, CancellationToken cancellationToken)
    {
        Department department = new Department()
        {
            Name = request.Name,
            Description = request.Description,
        };

        await _context.Departments.AddAsync(department);

        await _context.SaveChangesAsync(cancellationToken);

        return department.Id;


    }
}
