using System;
using UnityEditor;
using UnityEngine;

namespace SimpleInjectorWrapper.Scripts.Runtime.Ioc
{
    [DefaultExecutionOrder(-2000)]
    public class InstallerComponent<T> : MonoBehaviour where T : Installer, new()
    {
        private bool _initialized;
        private T _installer;

        public void Awake()
        {
            Initialize();
        }

        public void Update()
        {
            _installer?.Update();
        }

        private void OnDrawGizmos()
        {
            _installer?.Draw();
        }

        private void Dispose()
        {
            _installer?.Dispose();
            _initialized = false;
            _installer = null;
        }

        private void Initialize()
        {
            if (_initialized)
            {
                return;
            }

            RegisterPlayModeChanged();

            _installer = new T();
            _installer.Install();
            _initialized = true;

            DontDestroyOnLoad(gameObject);
        }

#if UNITY_EDITOR
        private void ModeChanged(PlayModeStateChange state)
        {
            if (state is PlayModeStateChange.ExitingPlayMode)
            {
                Dispose();
            }
        }
#endif

        private void RegisterPlayModeChanged()
        {
#if UNITY_EDITOR
            EditorApplication.playModeStateChanged += ModeChanged;
#endif
        }
    }
}