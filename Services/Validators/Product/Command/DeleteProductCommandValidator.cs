using Domain.Product.Command;
using FluentValidation;

namespace Services.Validators.Command
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand.Contract>
    {
        public DeleteProductCommandValidator()
        {

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Informe um id");
        }
    }
}
