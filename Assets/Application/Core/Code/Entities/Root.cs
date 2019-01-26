using GGJ2019.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace GGJ2019.UnityCore.Entities
{
    public class Root : MonoBehaviour, IRoot
    {
        public event RootInitializationEventHandler OnInitialized = delegate { };

        [SerializeField]
        private RectTransform uiRoot;
        private IList<IWindow> windows;
        private IApplicationQuitter applicationQuitter;

        public RectTransform UiRoot => uiRoot;

        [Inject]
        private void Inject(IList<IWindow> windows, IApplicationQuitter applicationQuitter)
        {
            this.windows = windows;
            this.applicationQuitter = applicationQuitter;
        }

        private void Start()
        {
            foreach (var window in windows)
            {
                window.Initialize(this);
            }

            OnInitialized?.Invoke();
        }

        public void PopWindow(IWindow window)
        {
            if (!windows.Contains(window))
            {
                throw new KeyNotFoundException("Couldn't find that window or has been poped out already");
            }

            window.Initialize(null);

            windows.Remove(window);
        }

        public void PushWindow(IWindow window)
        {
            if (windows.Contains(window))
            {
                throw new ArgumentException("You added that window already");
            }

            window.Initialize(this);
            windows.Add(window);
        }

        public WindowType Resolve<WindowType>() where WindowType : IWindow
        {
            var window = windows.FirstOrDefault(w => w is WindowType);

            if (window == null)
            {
                Debug.LogWarning($"Couldn't find window of type {typeof(WindowType)}.");
            }

            return (WindowType)window;
        }

        private void OnDestroy() {
            applicationQuitter.Quit();
        }
    }
}