using Bootcamp_Week2_Day1.DTOs;
using FluentValidation;

namespace Bootcamp_Week2_Day1.Validator
{
    public class SaveProductRequestValidator:AbstractValidator<SaveProductRequestDto>
    {
        public SaveProductRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id Boş Geldi");
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Alanı Boş");
            RuleFor(x=>x.Price).NotEmpty().WithMessage("Fiyat Alanı Boş"); 
            RuleFor(x=>x.Stock).NotEmpty().WithMessage("Stok Alanı Boş"); 
        }
    }
}
