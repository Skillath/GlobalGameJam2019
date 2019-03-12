using GGJ2019.Core.Adapters;
using WorstGameStudios.Core.Abstractions.Engine.Time;
using WorstGameStudios.Core.Engine.UI;
using Zenject;

namespace GGJ2019.UnityCore.Adapters
{
    public class PauseAdapter : View, IPauseAdapter
    {
        public event PauseAdapterEventHandler OnPause = delegate { };

        private ITimeService timeService;

        public bool IsPaused => timeService.TimeScale <= 0f;

        [Inject]
        private void Inject(ITimeService timeService)
        {
            this.timeService = timeService;
        }

        public void Pause()
        {
            if (!IsPaused)
            {
                timeService.TimeScale = 0;
                OnPause?.Invoke();
            }
        }

        public void Resume()
        {
            if (IsPaused)
            {
                timeService.TimeScale = 1;
            }
        }
    }
}
