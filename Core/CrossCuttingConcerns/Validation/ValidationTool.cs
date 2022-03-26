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
        public static void Validate(IValidator validator, object item)
        { 
            var result = validator.Validate(new ValidationContext<object>(item));

            if (!result.IsValid)
            { 
                throw new ValidationException(result.Errors);
            }
        }
    }
}
