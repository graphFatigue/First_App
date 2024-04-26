using FluentValidation;
using TaskBoard.Common.Models.Card;

namespace TaskBoard.API.Validators.Card
{
    public class CreateCardModelValidator : AbstractValidator<CreateCardModel>
    {
        public CreateCardModelValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name must not be empty");
        }
    }
}
