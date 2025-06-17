namespace Application.Merchants.Commands.UpdateMerchant;

public class UpdateMerchantCommandValidator : AbstractValidator<UpdateMerchantCommand>
{
    public UpdateMerchantCommandValidator()
    {
        RuleFor(v => v.Name).NotNull().NotEmpty().WithMessage("Name cannot be empty");
        RuleFor(v => v.Email).EmailAddress().NotEmpty().WithMessage("Email cannot be empty");
        RuleFor(v => v.CategoryId).NotNull().NotEmpty().WithMessage("Category cannot be empty");
    }
}