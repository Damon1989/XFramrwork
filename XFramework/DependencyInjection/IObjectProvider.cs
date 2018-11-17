using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace XFramework.DependencyInjection
{
    public interface IObjectProvider : IServiceProvider, ISupportRequiredService, IDisposable
    {
        IObjectProvider Parent { get; }

        IObjectProvider CreateScope();

        IObjectProvider CreateScope(IServiceCollection serviceCollection);
    }
}