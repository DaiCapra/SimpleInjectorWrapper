using SimpleInjectorWrapper.Scripts.Runtime.Ioc;
using UnityEngine;

namespace SimpleInjectorWrapper.Scripts.Examples
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