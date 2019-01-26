using GGJ2019.Core.Entities;
using System.Threading.Tasks;

namespace GGJ2019.Core.DataProvider
{
    public class StreamingAssetsDataProvider<Data> : IDataProvider<Data>
    {
        private readonly ILoader loader;
        private readonly string relativePath;

        private Data data;

        public StreamingAssetsDataProvider(ILoader loader, string relativePath)
        {
            this.loader = loader;
            this.relativePath = relativePath;
        }

        public async Task<Data> GetData()
        {
            if (data == null)
            {
                data = await loader.LoadFromStreamingAssets<Data>(relativePath);
            }

            return data;
        }
    }
}
