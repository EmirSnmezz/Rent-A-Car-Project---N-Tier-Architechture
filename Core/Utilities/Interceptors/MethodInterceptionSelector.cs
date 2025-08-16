using System.Reflection;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    public class MethodInterceptionSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterception>(true).ToList();
            var methodAttributes = type.GetCustomAttributes<MethodInterception>();
            return interceptors.ToArray();
        }
    }
}
