using SimpleInjectorWrapper.Runtime.Ioc;
using SimpleInjectorWrapper.Runtime.Reflection;
using UnityEngine;

namespace SimpleInjectorWrapper.Examples
{
    
    public class ExampleComponent : GameBehaviour
    {
        [Inject] private ExampleService _service;

        public void Start()
        {
            Debug.Log($"Service: {_service?.GetType()?.Name}");
        }
    }
}