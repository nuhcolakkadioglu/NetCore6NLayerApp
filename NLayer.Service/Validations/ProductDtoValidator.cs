using FluentValidation;
using NLayer.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Validations
{
    public class ProductDtoValidator:AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(m => m.Id).NotNull();
            RuleFor(m => m.Price).InclusiveBetween(1,int.MaxValue);
            RuleFor(m => m.Stock).InclusiveBetween(1, int.MaxValue);
            RuleFor(m => m.CategoryId).InclusiveBetween(1, int.MaxValue);

        }
    }
}
