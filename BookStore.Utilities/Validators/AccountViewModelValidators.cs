using FluentValidation;
using BookStore.Utilities.Models;
using BookStore.Utilities.Models;

namespace BookStore.Utilities.Validators
{
    public class RegistrationViewModelValidator : AbstractValidator<RegistrationViewModel>
    {
        public RegistrationViewModelValidator()
        {
            RuleFor(r => r.Email).NotEmpty().EmailAddress()
                .WithMessage("Invalid email address");

            RuleFor(r => r.Username).NotEmpty()
                .WithMessage("Invalid username");

            RuleFor(r => r.Password).NotEmpty()
                .WithMessage("Invalid password");
        }
    }

    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(r => r.Username).NotEmpty()
                .WithMessage("Invalid username");

            RuleFor(r => r.Password).NotEmpty()
                .WithMessage("Invalid password");
        }
    }
    public class BookViewModelValidator : AbstractValidator<BookViewModel>
    {
        public BookViewModelValidator()
        {
            RuleFor(book => book.Title).NotEmpty().Length(1,200)
                .WithMessage("Select a Genre");
        }
    }
}