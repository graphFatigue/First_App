using FluentValidation;
using TaskBoard.Common.Models.Card;

namespace TaskBoard.API.Validators.Card
{
    public class UpdateCardModelValidator: AbstractValidator<UpdateCardModel>
    {
        public UpdateCardModelValidator() {
            RuleFor(c => c.Name)
                    .NotEmpty().WithMessage("Name must not be empty");
        }
    }
}
