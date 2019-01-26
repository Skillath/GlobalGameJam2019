using GGJ.Core.Entities;
using System.Threading.Tasks;

namespace GGJ.UnityCore.Entities
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