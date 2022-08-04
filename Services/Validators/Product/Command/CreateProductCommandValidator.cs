using Domain.Product.Command;
using FluentValidation;
using Microsoft.VisualBasic.CompilerServices;

namespace Services.Validators.Command
{
    public class CreateProductCommandValidator: AbstractValidator<CreateProductCommand.Contract>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Informe uma descrição");


            RuleFor(x => x.ManufacturingAt)
                .Must(Utils.Utils.DateValidator)
                .WithMessage("A data de fabricação não pode ser maior ou igual a hoje")
                .LessThan(x => x.ValidUntil)
                .WithMessage("A data de fabricação não pode ser maior ou igual a de validade");

            RuleFor(x => x.ValidUntil).Must(Utils.Utils.DateValidator)
                .WithMessage("A data de validade não pode ser maior ou igual a hoje");
        }
    }
}
