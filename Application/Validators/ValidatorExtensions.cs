using FluentValidation;

namespace Application.Validators
{
    public static class ValidatorExtensions
    {
        public static IRuleBuilder<T, string> Name<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                .NotEmpty()
                .MinimumLength(6).WithMessage("Name should be at leat 6 characters long.")
                .MaximumLength(48).WithMessage("Name cannot exceed 48 characters.");

            return options;
        }

        public static IRuleBuilder<T, string> Email<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                .NotEmpty()
                .EmailAddress().WithMessage("Email is not valid.");

            return options;
        }

        public static IRuleBuilder<T, int> Rating<T>(this IRuleBuilder<T, int> ruleBuilder)
        {
            var options = ruleBuilder
                .InclusiveBetween(1, 5);

            return options;
        }
    }
}