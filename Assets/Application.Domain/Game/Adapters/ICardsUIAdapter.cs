using GGJ2019.Game.Entities;
using WorstGameStudios.Core.Abstractions.Engine.UI;

namespace GGJ2019.Game.Adapters
{
    public delegate void CardsUIAdapterEventHandler(Weapon weapon);
    public interface ICardsUIAdapter : IWindow
    {
        event CardsUIAdapterEventHandler OnCardSelected;

        void Load(WeaponType[] types, CardFactory cardFactory);

    }
}
