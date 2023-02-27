using SimpleInjectorWrapper.Runtime.Ioc;

namespace SimpleInjectorWrapper.Examples
{
    public class ExampleInstaller : Installer
    {
        protected override void InstallBindings()
        {
            RegisterSingleton<ExampleService>();
        }
    }
}