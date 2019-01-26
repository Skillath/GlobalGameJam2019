using System;
using System.Threading;
using System.Threading.Tasks;

namespace GGJ2019.Core.Adapters
{
    public interface ITimeAdapter
    {
        Task Delay(int milliseconds);

        Task Delay(TimeSpan time);

        Task Delay(int milliseconds, CancellationToken ct);

        Task Delay(TimeSpan time, CancellationToken ct);
    }
}
