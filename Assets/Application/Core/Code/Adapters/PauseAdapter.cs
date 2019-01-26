using GGJ2019.Core.Adapters;
using GGJ2019.Core.Services;
using GGJ2019.UnityCore.Entities;
using Zenject;

namespace GGJ2019.UnityCore.Adapters
{
    public class PauseAdapter : View, IPauseAdapter
    {
        public event PauseAdapterEventHandler OnPause = delegate { };

        private ITimeService timeService;

        public bool IsPaused => timeService.CurrentTimeScale <= 0f;

        [Inject]
        private void Inject(ITimeService timeService)
        {
            this.timeService = timeService;
        }

        public void Pause()
        {
            if (!IsPaused)
            {
                timeService.SetTimeScale(0);
                OnPause?.Invoke();
            }
        }

        public void Resume()
        {
            if (IsPaused)
            {
                timeService.RestoreTimeScale();
            }
        }
    }
}
