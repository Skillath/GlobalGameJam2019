using GGJ2019.Core.Entities;

namespace Zenject
{
    public static class ZenjectExtensionMethods
    {
        public static ConcreteIdBinderNonGeneric BindIWindow<T>(this DiContainer container) where T : IWindow
        {
            return container.Bind(typeof(IWindow), typeof(T));
        }
    }
}
