using GGJ2019.Game.Entities;
using WorstGameStudios.Core.Abstractions.Engine.UI;

namespace GGJ2019.Game.Adapters
{
    public delegate void CardUIEventHandler(Weapon weapon);

    public interface ICardUIAdapter : IWindow
    {
        event CardUIEventHandler OnWeaponSelected;

        void Load(Weapon weapon);
    }
}
