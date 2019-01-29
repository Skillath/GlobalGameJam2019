namespace GGJ2019.Game.Entities
{
    public delegate void EnemyHitDetectorCollisionHandler<T>(T collision);

    public interface IEnemyHitDetector
    {
        event EnemyHitDetectorCollisionHandler<IWeapon> OnWeaponHit;
        event EnemyHitDetectorCollisionHandler<IWeapon> OnWeaponRelease;
        event EnemyHitDetectorCollisionHandler<Player> OnPlayerReached;

        bool IsEnabled { get; set; }

        float DamageDelay { get; }

        int Damage { get; }
    }
}
