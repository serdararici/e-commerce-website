using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün ismi boş geçilemez.");
            RuleFor(x => x.ProductContent).NotEmpty().WithMessage("Ürün içeriği boş geçilemez");
            RuleFor(x => x.ProductImage).NotEmpty().WithMessage("Ürün görseli boş geçilemez.");
            RuleFor(x => x.ProductName).MaximumLength(150).WithMessage("Lütfen 150 karakterden daha az veri girişi yapın.");
            RuleFor(x => x.ProductName).MinimumLength(5).WithMessage("Lütfen 5 karakterden daha fazla veri girişi yapın.");

        }
    }
}
