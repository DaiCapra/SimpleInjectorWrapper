using SimpleInjector;
using SimpleInjectorWrapper.Runtime.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleInjectorWrapper.Runtime.Ioc
{
    public class Installer : Container
    {
        private readonly List<IDraw> _singletonDrawers;
        private readonly List<IUpdate> _singletonUpdaters;

        public static Installer Instance { get; set; }

        public Installer()
        {
            _singletonUpdaters = new List<IUpdate>();
            _singletonDrawers = new List<IDraw>();
            Instance = this;
        }

        public void Draw()
        {
            foreach (var drawer in _singletonDrawers)
            {
                drawer?.Draw();
            }
        }

        public object Get(Type type)
        {
            return GetInstance(type);
        }

        public T Get<T>() where T : class
        {
            return GetInstance<T>();
        }

        public void Install()
        {
            InstallBindings();
            SetupSingletons();
        }

        public void Update()
        {
            foreach (var singletonUpdater in _singletonUpdaters)
            {
                singletonUpdater?.Update();
            }
        }

        protected virtual void InstallBindings()
        {
        }

        private void AddInterfacesFromSingletons<T>(List<T> list)
        {
            list.Clear();

            foreach (var singleton in GetSingletons())
            {
                var instance = GetInstance(singleton.ServiceType);
                if (instance is T t)
                {
                    list.Add(t);
                }
            }
        }

        private List<InstanceProducer> GetSingletons()
        {
            var singletons = GetCurrentRegistrations()
                .Where(t => t.Lifestyle == Lifestyle.Singleton)
                .ToList();
            return singletons;
        }

        private void SetupSingletons()
        {
            AddInterfacesFromSingletons(_singletonUpdaters);
            AddInterfacesFromSingletons(_singletonDrawers);

            foreach (var registration in GetCurrentRegistrations())
            {
                var instance = GetInstance(registration.ServiceType);
                InjectionManager.Inject(instance);
            }
        }
    }
}