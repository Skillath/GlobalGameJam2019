using System.Threading;
using System.Threading.Tasks;

namespace GGJ2019.Game.Entities
{
    public delegate void WeaponEffectEventHandler();
    public interface IWeaponEffect
    {
        event WeaponEffectEventHandler OnEffectDone;
        Task Effect(CancellationToken cancellationToken);
    }
}
