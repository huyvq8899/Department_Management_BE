using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department_Management.Application.Departments.Commands.UpdateDepartment;
public class UpdateDepartmentCommandValidator : AbstractValidator<UpdateDepartmentCommand>
{
    public UpdateDepartmentCommandValidator()
    {
        RuleFor(d => d.Name).MaximumLength(200);

        RuleFor(d => d.Description).MaximumLength(250);
    }
}
