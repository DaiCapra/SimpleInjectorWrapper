using SimpleInjectorWrapper.Runtime.Ioc;
using UnityEngine;

namespace SimpleInjectorWrapper.Examples
{
    [DefaultExecutionOrder(-2000)]
    public class ExampleInstallerComponent : InstallerComponent<ExampleInstaller>
    {
        public new void Awake()
        {
            base.Awake();
        }
    }
}