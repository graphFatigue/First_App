using FluentValidation;
using TaskBoard.Common.Models.ListCards;

namespace TaskBoard.API.Validators.ListCards
{
    public class CreateListCardsModelValidator: AbstractValidator<CreateListCardsModel>
    {
        public CreateListCardsModelValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name must not be empty");
        }
    }
}
