﻿using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using RentACarPro.Business.Constants;

namespace RentACarPro.Business.Aspects.Autofac.Authorization
{
    public class SecuredOperation : MethodInterceptor
    {
        private readonly string[] _roles;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');

            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>() ??
                                   throw new Exception("IHttpContextAccessor can't be null.");
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();

            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role)) return;
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
