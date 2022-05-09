using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Performance
{
    public class PerformanceAspect : MethodInterceptor
    {
        private readonly int _interval;
        private readonly bool _justIssues;
        private readonly Stopwatch _stopWatch = new();

        public PerformanceAspect(int interval, bool justIssues = false)
        {
            _interval = interval;
            _justIssues = justIssues;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            _stopWatch.Start();
        }

        protected override void OnAfter(IInvocation invocation)
        {
            if (_interval < _stopWatch.Elapsed.TotalSeconds)
            {
                string message = GenerateMessage(invocation);
                Debug.WriteLine(message, category: "Performance Issue");
            }
            else if (!_justIssues)
            {
                string message = GenerateMessage(invocation);
                Debug.WriteLine(message, category: "Performance");
            }

            _stopWatch.Reset();
        }

        private string GenerateMessage(IInvocation invocation)
        {
            return $"{invocation.Method.DeclaringType?.FullName}.{invocation.Method.Name} --> {_stopWatch.Elapsed.TotalSeconds}";
        }
    }
}
