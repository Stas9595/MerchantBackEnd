namespace Application.Merchants.Commands.CreateMerchant;

public sealed class CreateMerchantCommandValidator : AbstractValidator<CreateMerchantCommand>
{
    public CreateMerchantCommandValidator()
    {
        RuleFor(v => v.Name).NotNull().NotEmpty().WithMessage("Name cannot be empty");
        RuleFor(v => v.Email).EmailAddress().NotEmpty().WithMessage("Email cannot be empty");
        RuleFor(v => v.CategoryId).NotNull().NotEmpty().WithMessage("Category cannot be empty");
    }
}