using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(x => x.MarkaName).NotEmpty().WithMessage("Ad soyad alanı boş geçilemez");
            RuleFor(x => x.MarkaMail).NotEmpty().WithMessage("Mail adresi boş geçilemez");
            RuleFor(x => x.MarkaPassword).NotEmpty().WithMessage("Şifre boş geçilemez");
            RuleFor(x => x.MarkaName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapın.");
            RuleFor(x => x.MarkaName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakterlik veri girişi yapın.");
        }
    }
}
