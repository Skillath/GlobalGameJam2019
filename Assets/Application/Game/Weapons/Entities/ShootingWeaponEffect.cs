using GGJ2019.Game.Entities;
using GGJ2019.UnityGames.Enemies.Entities;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace GGJ2019.UnityGames.Weapons.Entities
{
    public delegate void ShootingWeaponEffectEventHandler(IEnemy enemy);
    public class ShootingWeaponEffect : MonoBehaviour, IWeaponEffect
    {
        public event WeaponEffectEventHandler OnEffectDone = delegate { };
        public event ShootingWeaponEffectEventHandler OnEnemyHit = delegate { };

        [SerializeField]
        private int shootingDelay = 1;
        [SerializeField]
        private int distance = 5;
        [SerializeField]
        private int damage = 2;

        private bool initDone = false;

        public void Init()
        {
            initDone = true;
            StartCoroutine(Shoot());
        }

        public Task Effect(CancellationToken cancellationToken) => Task.CompletedTask;

        public void Stop()
        {
            initDone = false;
        }

        private IEnumerator Shoot()
        {
            while (initDone)
            {
                yield return new WaitForSeconds(shootingDelay);
#if UNITY_EDITOR
                Debug.DrawRay(this.transform.position, this.transform.TransformDirection(Vector3.forward) * distance, Color.white, shootingDelay);
#endif
                if (Physics.Raycast(this.transform.position, this.transform.TransformDirection(Vector3.forward), out var hit, distance))
                {
                    OnEffectDone?.Invoke();
                    var enemyBase = hit.collider?.GetComponentInParent<BaseEnemy>();
                    if (enemyBase != null)
                    {
                        var enemy = (IEnemy)enemyBase;
                        if (enemy.IsAlive)
                        {
                            enemy.HP -= damage;

                        }
                    }
                }
            }
        }
    }
}
