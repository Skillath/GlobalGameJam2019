using System.Threading;

namespace UnityEngine
{
    public class WaitForTaskSeconds : CustomYieldInstruction
    {
        private CancellationToken ct;
        private float seconds;
        private float startTime;

        public WaitForTaskSeconds(float seconds) : this(seconds, CancellationToken.None) { }

        public WaitForTaskSeconds(float seconds, CancellationToken ct)
        {
            startTime = Time.time;
            this.seconds = seconds;
            this.ct = ct;
        }

        public override bool keepWaiting
        {
            get
            {
                var currentTime = Time.time;
                var deltaTime = currentTime - startTime;
                return deltaTime < seconds && !ct.IsCancellationRequested;
            }
        }
    }
}
