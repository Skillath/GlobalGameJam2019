using System.Threading;
using System.Threading.Tasks;

namespace GGJ2019.Game.Entities
{
    public delegate void PlayerEventHandler();
    public delegate void PlayerHPEventHandler(int hp);
    public class Player
    {
        public event PlayerEventHandler OnPlayerDie = delegate { };
        public event PlayerHPEventHandler OnHPChanged = delegate { };

        private int hp;

        public Player(int hp) => this.hp = hp;

        public bool Alive => hp > 0;

        public int HP
        {
            get => hp;
            set
            {
                hp = value;
                OnHPChanged?.Invoke(value);
                if (hp <= 0)
                {
                    OnPlayerDie?.Invoke();
                }
            }
        }
    }
}
