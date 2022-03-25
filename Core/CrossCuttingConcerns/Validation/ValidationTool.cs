using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate<T>(IValidator<T> validator, T item)
        { 
            var result = validator.Validate(item);

            if (!result.IsValid)
            { 
                throw new ValidationException(result.Errors);
            }
        }
    }
}
