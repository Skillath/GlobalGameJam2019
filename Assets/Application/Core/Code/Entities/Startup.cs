using GGJ2019.Core.Entities;
using UnityEngine;
using Zenject;

namespace GGJ2019.UnityCore.Entities
{
    public class Startup : MonoBehaviour
    {
        [Inject]
        private void Inject(App application) => _ = application;
    }
}