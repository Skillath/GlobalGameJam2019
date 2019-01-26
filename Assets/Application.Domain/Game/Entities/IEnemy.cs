namespace GGJ2019.Game.Entities
{
    public interface IEnemy
    {
        int HP { get; }

        int Damage { get; }

        float Speed { get; }

        IEnemyAnimator Animator { get; }

        IEnemySoundProvider SoundProvider { get; }
    }
}