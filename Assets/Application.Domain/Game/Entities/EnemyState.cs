namespace GGJ2019.Game.Entities
{
    public delegate void EnemyStateEventHandler();
    public delegate void EnemyStateHPEventHandler(int hp);
    
    public class EnemyState
    {
        public event EnemyStateEventHandler OnEnemyDie = delegate { };
        public event EnemyStateHPEventHandler OnEnemyHPChange = delegate { };

        private int hp;

        public int HP
        {
            get => hp;
            set
            {
                hp = value;
                OnEnemyHPChange?.Invoke(hp <= 0 ? 0 : hp);
                if (hp <= 0)
                {
                    hp = 0;
                    OnEnemyDie?.Invoke();
                }
            }
        }
        public bool IsAlive => HP > 0;
    }
}
