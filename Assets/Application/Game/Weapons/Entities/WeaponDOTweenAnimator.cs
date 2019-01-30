using DG.Tweening;
using GGJ2019.Game.Entities;
using UnityEngine;


namespace GGJ2019.UnityGames.Weapons.Entities
{
    public class WeaponDOTweenAnimator : MonoBehaviour, IWeaponAnimator
    {
        [SerializeField]
        private Transform target;

        private Tween tween;

        public void PlayDeathAnimation()
        {
            tween?.Kill(false);
            target.transform.localScale = Vector3.one;
            target.transform.DOScale(Vector3.zero, 0.5f);
        }

        public void PlayEffectAnimation()
        {
            tween?.Kill(false);
            target.transform.localScale = Vector3.one;
            target.transform.DOPunchScale(Vector3.one * 1.1f, 0.25f);
        }

        public void PlaySpawnAnimation()
        {
            tween?.Kill(false);
            target.transform.localScale = Vector3.zero;
            target.transform.DOScale(Vector3.one, 0.5f);
        }
    }
}
