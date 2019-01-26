using GGJ2019.Core.Adapters;
using GGJ2019.Game.Entities;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace GGJ2019.UnityGames.Weapons.Entities
{
    public class EnergyWeaponEffect : MonoBehaviour, IWeaponEffect
    {
        public event WeaponEffectEventHandler OnEffectDone = delegate { };

        [SerializeField]
        private int generationRate = 2;
        [SerializeField]
        private float generationDelay = 2;
        [SerializeField]
        private int deathGeneration = 5;

        private bool initDone = false;

        private IPlayerMPGenerator mpGenerator;
        private ITimeAdapter timeAdapter;

        [Inject]
        private void Inject(Player player, ITimeAdapter timeAdapter)
        {
            this.mpGenerator = player.PlayerMPGenerator;
            this.timeAdapter = timeAdapter;
        }

        private void Start() => initDone = false;

        public async Task Effect(CancellationToken cancellationToken)
        {
            for (int i = 0; i < deathGeneration; i++)
            {
                mpGenerator.MP++;
                await timeAdapter.Delay(500, cancellationToken);
            }
        }

        public void Init()
        {
            initDone = true;
            StartCoroutine(DoEffect());
        }

        public void Stop()
        {
            initDone = false;
        }

        private IEnumerator DoEffect()
        {
            while (initDone)
            {
                if (mpGenerator.MP < mpGenerator.MaxMP)
                {
                    mpGenerator.MP += generationRate;
                    OnEffectDone?.Invoke();
                    yield return new WaitForSeconds(generationDelay);
                }
                yield return null;
            }
        }
    }
}
