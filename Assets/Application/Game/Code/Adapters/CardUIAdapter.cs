using GGJ2019.Game.Adapters;
using GGJ2019.Game.Entities;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WorstGameStudios.Core.Engine.UI;

namespace GGJ2019.UnityGames.Adapters
{
    public class CardUIAdapter : View, ICardUIAdapter
    {
        public event CardUIEventHandler OnWeaponSelected = delegate { };
        [SerializeField]
        private TMP_Text lblName;
        [SerializeField]
        private TMP_Text lblCost;

        [SerializeField]
        private Button btnUse;

        private Weapon weapon;

        public void Load(Weapon weapon)
        {
            this.weapon = weapon;

            lblName.text = weapon.WeaponType.ToString();
            lblCost.text = weapon.Cost.ToString();
        }

        public override async Task Show(CancellationToken cancellationToken)
        {
            await base.Show(cancellationToken);
            btnUse.onClick.AddListener(() =>
            {
                OnWeaponSelected?.Invoke(weapon);
                btnUse.onClick.RemoveAllListeners();
            });
        }

        public override Task Hide(CancellationToken cancellationToken)
        {
            btnUse.onClick.RemoveAllListeners();
            return base.Hide(cancellationToken);
        }
    }
}
