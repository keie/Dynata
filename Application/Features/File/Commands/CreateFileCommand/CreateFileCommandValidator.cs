using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.File.Commands.CreateFileCommand
{
    public class CreateFileCommandValidator:AbstractValidator<CreateFileCommand>
    {
        public CreateFileCommandValidator()
        {
            
            RuleFor(x=>x.File).NotEmpty().WithMessage("{PropertyName} is test");
        }
    }
}
