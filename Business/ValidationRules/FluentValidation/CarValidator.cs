using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<CarAddDto>
    {
        public CarValidator()
        {
            RuleFor(p => p.IsRented).Equals("true");
            RuleFor(p => p.Price).NotEmpty().WithMessage("Fiyat bilgisi eksik olamaz");
            RuleFor(p => p.CarMileage).NotEmpty().WithMessage("Km bilgisi eksik olamaz");
            RuleFor(p => p.CarMileage).NotNull().WithMessage("Km bilgisi eksik olamaz");
            RuleFor(p => p.CompanyId).NotEmpty().WithMessage("İlgili aracın firma bilgisine ulaşılamadı. Lütfen sistem yöneticiniz ile iletişime geçiniz.");
        }
    }
}
