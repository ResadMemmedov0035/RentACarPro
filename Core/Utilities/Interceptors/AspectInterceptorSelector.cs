using Castle.DynamicProxy;
using System.Reflection;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptor>(true).ToList();
            var methodAttributes = type.GetMethod(method.Name)?.GetCustomAttributes<MethodInterceptor>(true);

            if (methodAttributes != null)
                classAttributes.AddRange(methodAttributes);

            return classAttributes.ToArray();
        }
    }
}
