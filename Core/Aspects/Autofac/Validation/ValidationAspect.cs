using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;

        //attribute olduğu için type ile bağlanmak zorunda
        public ValidationAspect(Type validatorType)
        {
            //defensive coding : savunma kodlama
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); //reflection : çalışma aninda instance oluşturma
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //_validatorType=ProductValidator , ProductValidator'ün base type'ı = AbstracValidator, AbstracValidator'ün generic argumanlarinin 0'ıncısının tipini yakala.
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);  //invocation = method , method = IResult, IResult methodunun argumanlarını gez(birden fazla olabilir), ordaki tiplerden birisi entityType'ın türünde ise  
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity); //onları validate et.
            }
        }
    }
}
    