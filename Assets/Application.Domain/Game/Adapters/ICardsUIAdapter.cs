using GGJ2019.Core.Entities;
using GGJ2019.Game.Entities;

namespace GGJ2019.Game.Adapters
{
    public delegate void CardsUIAdapterEventHandler(Weapon weapon);
    public interface ICardsUIAdapter : IWindow
    {
        event CardsUIAdapterEventHandler OnCardSelected;

        void Load(WeaponType[] types, CardFactory cardFactory);

    }
}
