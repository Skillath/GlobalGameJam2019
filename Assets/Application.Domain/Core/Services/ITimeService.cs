namespace GGJ.Core.Services
{
    public interface ITimeService
    {
        float CurrentTimeScale { get; }
        void SetTimeScale(float timeScale);
        void RestoreTimeScale();
    }
}
