using FluentValidation;
using TaskBoard.Common.Models.Board;

namespace TaskBoard.API.Validators.Board
{
    public class CreateBoardModelValidator : AbstractValidator<CreateBoardModel>
    {
        public CreateBoardModelValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name must not be empty");

            RuleFor(c => c.Name)
                .Length(2, 50).WithMessage("Name must be between 2 and 50 characters");
        }
    }
}
