using FluentValidation;
using TaskBoard.Common.Models.Card;

namespace TaskBoard.API.Validators.Card
{
    public class UpdateCardModelValidator: AbstractValidator<UpdateCardModel>
    {
        public UpdateCardModelValidator() {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name must not be empty");

            RuleFor(c => c.Name)
                .Length(2, 50).WithMessage("Name must be between 2 and 50 characters");

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Description must not be empty");

            RuleFor(c => c.Description)
                .Length(2, 300).WithMessage("Description must be between 2 and 300 characters");

            RuleFor(c => c.Priority)
                .NotEmpty().WithMessage("Name must not be empty");

            RuleFor(c => c.ListCardsName)
                .NotEmpty().WithMessage("Card must be in a list");

            RuleFor(c => c.DueDate)
                .NotEmpty().WithMessage("Due Date must not be empty");
        }
    }
}
