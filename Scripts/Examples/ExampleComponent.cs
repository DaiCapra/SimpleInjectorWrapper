using SimpleInjectorWrapper.Scripts.Runtime.Ioc;
using SimpleInjectorWrapper.Scripts.Runtime.Reflection;
using UnityEngine;

namespace SimpleInjectorWrapper.Scripts.Examples
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