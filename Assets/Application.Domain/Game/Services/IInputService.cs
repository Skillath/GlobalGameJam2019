using GGJ2019.Core.Models;
using System;

namespace GGJ2019.Game.Services
{
    public delegate void InputServiceEventHandler(Vector worldPos);
    public delegate void InputServicePauseEventHandler();
    public interface IInputService : IDisposable
    {
        event InputServiceEventHandler OnTouch;
        event InputServicePauseEventHandler OnPauseRequested;

        void Setup();
    }
}
