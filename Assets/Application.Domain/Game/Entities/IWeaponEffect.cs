using System.Threading;
using System.Threading.Tasks;

namespace GGJ2019.Game.Entities
{
    public delegate void WeaponEffectEventHandler();
    public interface IWeaponEffect
    {
        event WeaponEffectEventHandler OnEffectDone;

        void Init();
        Task Effect(CancellationToken cancellationToken);
        void Stop();
    }

    public class NullWeaponEffect : IWeaponEffect
    {
        public event WeaponEffectEventHandler OnEffectDone = delegate { };

        public Task Effect(CancellationToken cancellationToken) => Task.CompletedTask;
        public void Init() { }
        public void Stop() { }
    }
}
