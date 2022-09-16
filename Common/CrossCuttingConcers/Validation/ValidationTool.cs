using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.CrossCuttingConcers.Validation
{
    public class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<Object>(entity);
            //UserValidator userValidator = new UserValidator();
            var validateRule = validator.Validate(context);

            if (!validateRule.IsValid)
            {
                throw new ValidationException(validateRule.Errors);
            }
        }
    }
}
