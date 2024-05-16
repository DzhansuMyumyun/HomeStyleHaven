using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception //Aspect
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            //defensive coding
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("This is not a sustainable class");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); // create the instance of validator
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; // check the Type of entity (AbstractValidator<Product>) => here is the type Product
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); // find the entities of the method (public IResult Add(Product product)) => here is the entity product
            foreach (var entity in entities) //validate all of them step by step
            {
                ValidationTool.Validate(validator, entity);
            }
        }


    }
}
