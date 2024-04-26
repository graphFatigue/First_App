using FluentValidation;
using TaskBoard.Common.Models.ListCards;

namespace TaskBoard.API.Validators.ListCards
{
    public class UpdateListCardsModelValidator: AbstractValidator<UpdateListCardsModel>
    {
        public UpdateListCardsModelValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name must not be empty");
        }
    }
}
