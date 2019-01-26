using System.Threading.Tasks;

namespace GGJ2019.Core.Entities
{
    public delegate Task ApplicationQuitterEventHandler();
    public interface IApplicationQuitter
    {
        event ApplicationQuitterEventHandler OnQuit;

        bool IsQuitting { get; }

        Task Quit();
    }
}
