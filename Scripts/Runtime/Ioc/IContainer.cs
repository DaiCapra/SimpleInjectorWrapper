using SimpleInjector;

namespace SimpleInjectorWrapper.Runtime.Ioc
{
    public interface IContainer
    {
        Container Container { get; set; }
    }
}