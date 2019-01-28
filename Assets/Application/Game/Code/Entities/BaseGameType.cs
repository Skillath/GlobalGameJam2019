using GGJ2019.Game.Adapters;
using GGJ2019.Game.Entities;
using GGJ2019.UnityGames.Adapters;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace GGJ2019.UnityGames.Entities
{
    public abstract class BaseGameType : MonoBehaviour, IGameType
    {
        [SerializeField]
        private Transform cameraPosition;
        [SerializeField]
        private GridAdapter gridAdapter;
        private Transform cameraParent;

        public IGridAdapter GridAdapter => gridAdapter;

        public void SetupCamera()
        {
            var camera = Camera.main.transform;
            cameraParent = camera.parent;
            camera.SetParent(cameraPosition, false);
        }
        public abstract Task EndAnimation(CancellationToken cancellationToken);

        public abstract Task StartAnimation(CancellationToken cancellationToken);

        public void UnlockCamera()
        {
            var camera = Camera.main.transform;
            camera.SetParent(cameraParent, false);
        }
    }
}
