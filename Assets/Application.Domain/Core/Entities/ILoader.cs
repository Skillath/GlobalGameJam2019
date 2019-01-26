using System.Threading.Tasks;

namespace GGJ2019.Core.Entities
{
    public interface ILoader
    {
        Task<T> LoadFromStreamingAssets<T>(string fileName);
    }
}
