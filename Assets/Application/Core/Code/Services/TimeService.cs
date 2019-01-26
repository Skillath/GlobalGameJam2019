using GGJ2019.Core.Services;
using UnityEngine;

namespace GGJ2019.UnityCore.Services
{
    public class TimeService : ITimeService
    {
        public float CurrentTimeScale => Time.timeScale;

        public void RestoreTimeScale() => Time.timeScale = 1f;

        public void SetTimeScale(float timeScale)
        {
            if (timeScale < 0)
            {
                timeScale = 0f;
            }

            Time.timeScale = timeScale;
        }
    }
}
