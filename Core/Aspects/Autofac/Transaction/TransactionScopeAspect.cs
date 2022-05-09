using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterceptor
    {
        public override void Intercept(IInvocation invocation)
        {
            using var scope = new TransactionScope();

            try
            {
                invocation.Proceed();
                scope.Complete();
            }
            catch (Exception)
            {
                scope.Dispose();
                throw;
            }
        }
    }
}
