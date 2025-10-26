using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Caching
{
    public class CachingRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheService _caching;

        public CachingRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _caching = ServiceTool.ServiceProvider.GetService<ICacheService>();
        }

        public override void OnSuccess(IInvocation invocation)
        {
            _caching.Remove(_pattern);
        }
    }
}
