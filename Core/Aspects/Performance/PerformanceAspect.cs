using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace Core.Aspects.Performance
{
    public class PerformanceAspect : MethodInterception
    {
        private int _interval;
        private Stopwatch _stopWatch;

        public PerformanceAspect(int interval)
        {
            _interval = interval;
            _stopWatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }

        public override void OnBefore(IInvocation invocation)
        {
            _stopWatch.Start();
        }

        public override void OnAfter(IInvocation invocation)
        {
            if(_stopWatch.Elapsed.TotalSeconds > _interval)
            {
                Debug.WriteLine($"Performance Problem:{invocation.Method.DeclaringType.FullName}.{invocation.Method.Name} ---> {_stopWatch.Elapsed.TotalSeconds}");
            }
            _stopWatch.Restart();
        }
    }
}
