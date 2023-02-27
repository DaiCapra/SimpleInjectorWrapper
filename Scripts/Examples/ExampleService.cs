using SimpleInjectorWrapper.Runtime.Ioc;
using UnityEngine;

namespace SimpleInjectorWrapper.Examples
{
    public class ExampleService : IUpdate, IDraw
    {
        public void Draw()
        {
            Debug.Log("OnGizmosDraw");
        }

        public void Update()
        {
            Debug.Log("OnUpdate");
        }
    }
}