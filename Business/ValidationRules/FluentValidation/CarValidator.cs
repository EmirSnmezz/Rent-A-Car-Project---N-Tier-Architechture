using Castle.Components.DictionaryAdapter;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<CarAddDto>
    {
        public CarValidator()
        {
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.Price).NotEmpty();
            RuleFor(c => c.Price).GreaterThan(0);
            RuleFor(c => c.ColorId).NotNull();
            //RuleFor(c => c.Brand.Name).Must(StartsWithA).WithMessage("Ürün Adı 'A' ile başlamalı...");
            RuleFor(c => c.BrandId).NotEqual(1);
        }

        private bool StartsWithA(string s)
        {
            return true;
        }

    }
}
