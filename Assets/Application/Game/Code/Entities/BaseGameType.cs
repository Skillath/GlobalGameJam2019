using GGJ2019.Game.Entities;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace GGJ2019.UnityGames.Entities
{
    public abstract class BaseGameType : MonoBehaviour, IGameType
    {
        public abstract Task EndAnimation(CancellationToken cancellationToken);
        public abstract Task StartAnimation(CancellationToken cancellationToken);
    }
}
