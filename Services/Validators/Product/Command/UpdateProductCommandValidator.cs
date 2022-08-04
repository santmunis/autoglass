using Domain.Product.Command;
using FluentValidation;

namespace Services.Validators.Command
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand.Contract>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Informe uma descrição");

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Informe um id");

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
