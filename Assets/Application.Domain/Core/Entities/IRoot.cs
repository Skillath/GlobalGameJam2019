using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ2019.Core.Entities
{
    public delegate void RootInitializationEventHandler();
    public interface IRoot
    {
        event RootInitializationEventHandler OnInitialized;

        WindowType Resolve<WindowType>() where WindowType : IWindow;

        void PushWindow(IWindow window);

        void PopWindow(IWindow window);
    }
}