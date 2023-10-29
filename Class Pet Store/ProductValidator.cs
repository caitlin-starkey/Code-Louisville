using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Class_Pet_Store
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Name).NotNull();
            RuleFor(product => product.Price).GreaterThanOrEqualTo(0);
            RuleFor(product => product.Quantity).GreaterThanOrEqualTo(0);
            RuleFor(product => product.Description).MinimumLength(10).When(product => product.Description != null);
        }
    }
}
