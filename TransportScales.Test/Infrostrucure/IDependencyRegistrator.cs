using System;

namespace TransportScales.Test.Infrostrucure
{
    public interface IDependencyRegistrator
    {
        IServiceProvider GetServiceProvider();
    }
}
