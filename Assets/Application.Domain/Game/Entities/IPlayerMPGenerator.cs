using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGJ2019.Game.Entities
{
    public delegate void PlayerMPGeneratorEventHandler(int mp);
    public interface IPlayerMPGenerator
    {
        event PlayerMPGeneratorEventHandler OnMPValueChanged;

        int MP { get; set; }

        int MaxMP { get; }

        void Init();

        void Stop();
    }
}
