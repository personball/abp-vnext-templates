using System;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.ExceptionHandling;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Http;

namespace CName.PName.SName.ExceptionHandling
{
    [Dependency(ReplaceServices = true)]
    public class DangQuPTExceptionToErrorInfoConverter : IExceptionToErrorInfoConverter, ITransientDependency
    {
        private readonly DefaultExceptionToErrorInfoConverter _defaultErrConverter;

        public DangQuPTExceptionToErrorInfoConverter(IServiceProvider serviceProvider)
        {
            _defaultErrConverter = serviceProvider.GetRequiredService<DefaultExceptionToErrorInfoConverter>();
        }

        public RemoteServiceErrorInfo Convert(Exception exception)
        {
            var error = _defaultErrConverter.Convert(exception);
            if (error != null && !error.Code.IsNullOrWhiteSpace() && error.Code.IndexOf(":") >= 0)
            {
                var code = error.Code;
                error.Code = code.Substring(code.IndexOf(":") + 1);
            }

            return error;
        }
    }
}
