using Bootcamp_Week2_Day1.DTOs;
using FluentValidation;

namespace Bootcamp_Week2_Day1.Validator
{
    public class UpdateProductRequestValidator:AbstractValidator<UpdateProductRequestDto>
    {
        public UpdateProductRequestValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("İsim Boş Olamaz");
            RuleFor(x => x.Price).LessThanOrEqualTo(1000).WithMessage("Fiyatı 1000'in üzerinde giremezsiniz");
            RuleFor(x => x.Stock).InclusiveBetween(10, 100).WithMessage("Stok 10-100 arasında olmalıdır");
        }
    }
}
