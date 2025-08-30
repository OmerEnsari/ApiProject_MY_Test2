using ApiProject.WebAPI.Entities;
using FluentValidation;

namespace ApiProject.WebAPI.ValidationRules
{
    public class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Product name cannot be empty.");
            RuleFor(p => p.Name).MinimumLength(2).WithMessage("Product name must be at least 2 characters long.");
            RuleFor(p => p.Name).MaximumLength(50).WithMessage("Product name cannot exceed 50 characters.");
            RuleFor(p => p.Description).NotEmpty().WithMessage("Product description cannot be empty.");
            RuleFor(p => p.Description).MinimumLength(5).WithMessage("Product description must be at least 5 characters long.");
            RuleFor(p => p.Description).MaximumLength(500).WithMessage("Product description cannot exceed 500 characters.");

            RuleFor(p => p.Price).GreaterThan(0).WithMessage("Price must be greater than zero.").LessThan(9000).WithMessage("Price is so expensive");
        }
    }
}
