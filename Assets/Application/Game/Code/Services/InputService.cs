using GGJ2019.Game.Services;
using System;
using UniRx;
using UnityEngine;
using WorstGameStudios.Core.Utils.ExtensionMethods;

namespace GGJ2019.UnityGames.Services
{
    public class InputService : MonoBehaviour, IInputService
    {
        public event InputServiceEventHandler OnTouch = delegate { };
        public event InputServicePauseEventHandler OnPauseRequested = delegate { };

        private bool canBeTouched = false;
        private IDisposable[] disposables;

        public void Setup()
        {
            canBeTouched = true;
            var pauseKey = Observable.EveryUpdate()
                .Where(_ => Input.GetKeyDown(KeyCode.Escape))
                .Subscribe(_ => OnPauseRequested?.Invoke());
            var click = Observable.EveryUpdate()
                .Where(_ => Input.GetButtonDown("Fire1"))
                .Subscribe(_ =>
                {
                    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hit))
                    {
                        OnTouch?.Invoke(hit.point.ToVector());
                    }
                });

            disposables = new IDisposable[] { pauseKey, click };
        }

        public void Dispose()
        {
            canBeTouched = false;
            if (disposables == null)
            {
                return;
            }

            foreach (var disposable in disposables)
            {
                disposable.Dispose();
            }

            disposables = null;
        }


    }
}
