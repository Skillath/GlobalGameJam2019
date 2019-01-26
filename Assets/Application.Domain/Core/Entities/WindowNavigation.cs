using System.Threading;
using System.Threading.Tasks;

namespace GGJ.Core.Entities
{

    public class WindowNavigation
    {
        private readonly IRoot root;

        public WindowNavigation(IRoot root)
        {
            this.root = root;
        }

        public IWindow CurrentWindow { get; private set; }

        public async Task<IWindow> Show<WindowType>(CancellationToken cancellationToken) where WindowType : IWindow
        {
            var window = root.Resolve<WindowType>();

            await Show(window, cancellationToken);

            return window;
        }

        public async Task Show(IWindow window, CancellationToken cancellationToken)
        {
            if (window != null)
            {
                if (CurrentWindow != null)
                {
                    _ = CurrentWindow.Hide(cancellationToken);
                }

                await window.Show(cancellationToken);

                CurrentWindow = window;
            }
        }

        public async Task<IWindow> Hide<WindowType>(CancellationToken cancellationToken) where WindowType : IWindow
        {
            var window = root.Resolve<WindowType>();

            await Hide(window, cancellationToken);

            return window;
        }

        public Task Hide(IWindow window, CancellationToken cancellationToken) => window.Hide(cancellationToken);

    }
}
