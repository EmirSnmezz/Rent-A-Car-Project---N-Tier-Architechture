using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;

namespace Core.Aspects.AutoFac
{
    public class ValidationAspect : MethodInterception
    {
        Type _validatorType;

        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
                throw new Exception("Gönderilen validator bir validator değil");

            _validatorType = validatorType;
        }


        public override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator) Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entites = invocation.Arguments.Where(t => t.GetType() == entityType);

            foreach(var entity in entites)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
