using System.Threading.Tasks;

namespace GGJ2019.Core.DataProvider
{
    public interface IDataProvider<Data>
    {
        Task<Data> GetData();
    }
}