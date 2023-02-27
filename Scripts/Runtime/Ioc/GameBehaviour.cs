using SimpleInjectorWrapper.Scripts.Runtime.Reflection;
using UnityEngine;

namespace SimpleInjectorWrapper.Scripts.Runtime.Ioc
{
    public abstract class GameBehaviour : MonoBehaviour
    {
        private bool _hasBeenInjected;

        public void Awake()
        {
            Inject();
        }

        public void Inject()
        {
            if (_hasBeenInjected)
            {
                return;
            }

            _hasBeenInjected = InjectionManager.Inject(this);
        }
    }
}