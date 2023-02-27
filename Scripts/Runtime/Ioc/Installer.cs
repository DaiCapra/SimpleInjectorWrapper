using System.Collections.Generic;
using System.Linq;
using SimpleInjector;

namespace SimpleInjectorWrapper.Runtime.Ioc
{
    public class Installer : Container
    {
        private readonly List<IDraw> _singletonDrawers;
        private readonly List<IUpdate> _singletonUpdaters;

        public Installer()
        {
            _singletonUpdaters = new List<IUpdate>();
            _singletonDrawers = new List<IDraw>();
            Instance = this;
        }

        public static Installer Instance { get; set; }

        public void Draw()
        {
            foreach (var drawer in _singletonDrawers)
            {
                drawer?.Draw();
            }
        }

        public void Install()
        {
            InstallBindings();
            SetupSingletons();
        }

        protected virtual void InstallBindings()
        {
        }

        public void Update()
        {
            foreach (var singletonUpdater in _singletonUpdaters)
            {
                singletonUpdater?.Update();
            }
        }

        private void SetupSingletons()
        {
            AddInterfacesFromSingletons(_singletonUpdaters);
            AddInterfacesFromSingletons(_singletonDrawers);
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
    }
}