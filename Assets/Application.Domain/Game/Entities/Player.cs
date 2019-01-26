namespace GGJ2019.Game.Entities
{
    public delegate void PlayerEventHandler();
    public delegate void PlayerValuesEventHandler(int value);
    public class Player
    {
        public event PlayerEventHandler OnPlayerDie = delegate { };
        public event PlayerValuesEventHandler OnHPChanged = delegate { };

        private int hp;

        public Player(IPlayerMPGenerator playerMPGenerator, int hp)
        {
            this.hp = hp;
            this.PlayerMPGenerator = playerMPGenerator;
        }

        public IPlayerMPGenerator PlayerMPGenerator { get; }

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
                    hp = 0;
                    OnPlayerDie?.Invoke();
                }
            }
        }



    }
}
