using GGJ2019.Core.Entities;
using GGJ2019.Game.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGJ2019.Game.Adapters
{
    public delegate void CardUIEventHandler(Weapon weapon);

    public interface ICardUIAdapter : IWindow
    {
        event CardUIEventHandler OnWeaponSelected;

        void Load(Weapon weapon);
    }
}
