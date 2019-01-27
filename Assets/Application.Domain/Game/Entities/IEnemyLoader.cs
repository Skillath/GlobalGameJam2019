namespace GGJ2019.Game.Entities
{
    public interface IEnemyLoader
    {
        IEnemy LoadEnemy(EnemyType type);

        void RemoveEnemy(EnemyType type, IEnemy enemy);
    }
}
