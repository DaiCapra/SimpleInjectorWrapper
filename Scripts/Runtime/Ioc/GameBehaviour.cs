using SimpleInjectorWrapper.Runtime.Reflection;
using UnityEngine;

namespace SimpleInjectorWrapper.Runtime.Ioc
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