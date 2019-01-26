using GGJ.Core.Adapters;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace GGJ.UnityCore.Adapters
{
    public class TimeAdapter : MonoBehaviour, ITimeAdapter
    {
        public async Task Delay(int milliseconds)
        {
            await new WaitForTaskSeconds((float)TimeSpan.FromMilliseconds(milliseconds).TotalSeconds);
        }

        public async Task Delay(TimeSpan time)
        {
            await new WaitForTaskSeconds((float)time.TotalSeconds);
        }

        public async Task Delay(int milliseconds, CancellationToken ct)
        {
            await new WaitForTaskSeconds((float)TimeSpan.FromMilliseconds(milliseconds).TotalSeconds, ct);

            if (ct.IsCancellationRequested)
            {
                await Task.FromCanceled(ct);
            }
        }

        public async Task Delay(TimeSpan time, CancellationToken ct)
        {
            await new WaitForTaskSeconds((float)time.TotalSeconds, ct);

            if (ct.IsCancellationRequested)
            {
                await Task.FromCanceled(ct);
            }
        }
    }
}
