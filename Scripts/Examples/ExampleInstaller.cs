using SimpleInjectorWrapper.Scripts.Runtime.Ioc;

namespace SimpleInjectorWrapper.Scripts.Examples
{
    public class ExampleInstaller : Installer
    {
        protected override void InstallBindings()
        {
            RegisterSingleton<ExampleService>();
        }
    }
}