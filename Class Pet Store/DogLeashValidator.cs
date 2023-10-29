using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Class_Pet_Store
{
    internal class DogLeashValidator : AbstractValidator<DogLeash>
    {
        public DogLeashValidator() 
        {
            new ProductValidator();
        }
    }
}
