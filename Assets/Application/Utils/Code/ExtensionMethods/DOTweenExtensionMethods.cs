using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace DG.Tweening
{
    public static class DOTweenExtensionMethods
    {
        public static async Task DOAsync(this Tweener tween) {
            var tcs = new TaskCompletionSource<bool>();
            void onComplete() => tcs.SetResult(true);

            tween.onComplete += onComplete;
            await tcs.Task;
            tween.onComplete -= onComplete;
        }

        public static async Task DOAsync(this Tweener tween, CancellationToken cancellationToken)
        {
            var tcs = new TaskCompletionSource<bool>();
            void onComplete() => tcs.SetResult(true);
            tween.onComplete += onComplete;

            var ctr = cancellationToken.Register(() =>
            {
                if (!tcs.Task.IsCompleted)
                {
                    tween.Kill(false);
                    tcs.SetCanceled();
                }
            });

            await tcs.Task;
            tween.onComplete -= onComplete;

            ctr.Dispose();

        }
    }
}
