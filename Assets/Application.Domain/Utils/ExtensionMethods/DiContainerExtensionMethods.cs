using GGJ2019.Core.Entities;
using GGJ2019.Game.Entities;

namespace Zenject
{
    public static class DiContainerExtensionMethods
    {
        public static ConcreteIdBinderNonGeneric BindIWindow<T>(this DiContainer container) where T : IWindow => container.Bind(typeof(IWindow), typeof(T));


        public static MemoryPoolIdInitialSizeMaxSizeBinder<T> UseEnemy<T>(this DiContainer container, EnemyType enemyType) where T : IEnemy
        {
            return null;
        }
    }
}
