using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterceptor
    {
        private readonly Type _validatorType;

        public ValidationAspect(Type validatorType)
        {
            if (!validatorType.IsAssignableTo(typeof(IValidator)))
            {
                throw new Exception("Not a validator class");
            }
            _validatorType = validatorType;
        }

        #nullable disable
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var arguments = invocation.Arguments.Where(a => a.GetType() == entityType);

            foreach (var arg in arguments)
            {
                ValidationTool.Validate(validator, arg);
            }
        }
        #nullable enable
    }
}
