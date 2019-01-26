using GGJ2019.Core.Entities;
using System.Threading.Tasks;

namespace GGJ2019.UnityCore.Entities
{
    public class ApplicationQuitter : IApplicationQuitter
    {
        public event ApplicationQuitterEventHandler OnQuit;

        public bool IsQuitting { get; private set; } = false;

        public async Task Quit()
        {
            IsQuitting = true;
            await OnQuit?.Invoke();
            IsQuitting = false;
        }
    }
}