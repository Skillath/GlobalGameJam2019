using GGJ.Core.Adapters;
using GGJ.Core.Services;
using GGJ.UnityCore.Entities;
using Zenject;

namespace GGJ.UnityCore.Adapters
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
