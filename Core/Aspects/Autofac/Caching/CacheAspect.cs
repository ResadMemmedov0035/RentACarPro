using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterceptor
    {
        private readonly int _duration;
        private readonly ICacheManager _cacheService;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheService = ServiceTool.ServiceProvider.GetService<ICacheManager>() ?? throw new Exception("ICacheService can't be null.");
        }

        public override void Intercept(IInvocation invocation)
        {
            string methodName = $"{invocation.Method.ReflectedType?.FullName}.{invocation.Method.Name}";
            string argumentCombination = string.Join(',', invocation.Arguments.Select(a => a?.ToString()));
            string key = $"{methodName}({argumentCombination})";

            if (_cacheService.Contains(key))
            {
                invocation.ReturnValue = _cacheService.Get(key);
                return;
            }
            invocation.Proceed();
            _cacheService.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
