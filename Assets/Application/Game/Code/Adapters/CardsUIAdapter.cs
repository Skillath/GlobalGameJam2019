using GGJ2019.Game.Adapters;
using GGJ2019.Game.Entities;
using GGJ2019.UnityCore.Entities;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace GGJ2019.UnityGames.Adapters
{
    public class CardsUIAdapter : View, ICardsUIAdapter
    {
        public event CardsUIAdapterEventHandler OnCardSelected = delegate { };
        private ICardUIAdapter[] cards;

        [SerializeField]
        private Transform container;

        public void Load(WeaponType[] types, CardFactory cardFactory)
        {
            cards = new ICardUIAdapter[types.Length];
            for (int i = 0; i < types.Length; i++)
            {
                cards[i] = cardFactory.Create();
                cards[i].Load(new Weapon()
                {
                    Cost = i,
                    WeaponType = types[i],
                });

                var cardAdapter = (CardUIAdapter)cards[i];
                cardAdapter.transform.SetParent(container, false);

            }

        }

        public override async Task Show(CancellationToken cancellationToken)
        {
            await base.Show(cancellationToken);
            foreach (var card in cards)
            {
                await card.Show(cancellationToken);
                card.OnWeaponSelected += Card_OnWeaponSelected;
            }
        }

        private void Card_OnWeaponSelected(Weapon weapon) => OnCardSelected?.Invoke(weapon);

        public override async Task Hide(CancellationToken cancellationToken)
        {
            foreach (var card in cards)
            {
                card.OnWeaponSelected -= Card_OnWeaponSelected;
                await card.Hide(cancellationToken);
            }
            await base.Hide(cancellationToken);
        }
    }
}
