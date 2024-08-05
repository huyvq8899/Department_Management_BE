using Department_Management.Domain.Entities;

namespace Department_Management.Application.Departments.Queries.GetDepartmentWithPagination;
public class DepartmentDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    //public IEnumerable<EmployeeDto> Employees { get; init; } = new List<EmployeeDto>();

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Department, DepartmentDto>();
            //CreateMap<Employee, EmployeeDto>();
        }
    }
}
