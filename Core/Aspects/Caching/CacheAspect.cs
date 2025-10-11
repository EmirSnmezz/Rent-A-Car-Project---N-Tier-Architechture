using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheService _caching;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _caching = ServiceTool.ServiceProvider.GetService<ICacheService>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x.ToString() ?? "<Null>"))})";

            if(_caching.IsAdd(key))
            {
                invocation.ReturnValue = _caching.Get(key);
                return;
            }

            invocation.Proceed();
            _caching.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
