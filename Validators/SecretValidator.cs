using FluentValidation;
using MyBlazorVault.Data;

public class SecretValidator : AbstractValidator<Secret>
{
    public SecretValidator()
    {
        RuleFor(s => s.Id).NotNull();
        RuleFor(s => s.Title).MaximumLength(50)
        .WithMessage("Title Max Length : 50");
        RuleFor(s => s.UserName).MaximumLength(50);
        RuleFor(s => s.EncryptedPassword)
        .MaximumLength(20)
        .MinimumLength(12)
        .NotEmpty();
        RuleFor(s => s.Notes).MaximumLength(100);
    }
}