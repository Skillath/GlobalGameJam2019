using GGJ.Core.Entities;
using UnityEngine;
using Zenject;

namespace GGJ.UnityCore.Entities
{
    public class Startup : MonoBehaviour
    {
        [Inject]
        private void Inject(App application) => _ = application;
    }
}