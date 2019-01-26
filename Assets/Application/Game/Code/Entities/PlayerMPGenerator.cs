using GGJ2019.Game.Entities;
using System.Collections;
using UnityEngine;
using Zenject;

namespace GGJ2019.UnityGames.Entities
{
    public class PlayerMPGenerator : MonoBehaviour, IPlayerMPGenerator
    {
        public event PlayerMPGeneratorEventHandler OnMPValueChanged = delegate { };

        private int mp;
        private int delay;
        private bool initDone = false;

        [Inject]
        private void Inject(int initialMP, int maxMP, int delay)
        {
            MP = initialMP;
            this.MaxMP = maxMP;
            this.delay = delay;
        }

        public int MP
        {
            get => mp;
            set
            {
                mp = value;
                if (mp > MaxMP)
                {
                    mp = MaxMP;
                }
                OnMPValueChanged?.Invoke(value);
            }
        }

        public int MaxMP { get; private set; }

        public void Init()
        {
            initDone = true;
            StartCoroutine(GenerateMP());
        }

        public void Stop()
        {
            initDone = false;

        }

        private IEnumerator GenerateMP()
        {
            while (initDone)
            {
                if (mp < MaxMP)
                {
                    yield return new WaitForSeconds(delay);
                    MP++;
                }
                yield return null;
            }
        }
    }
}
