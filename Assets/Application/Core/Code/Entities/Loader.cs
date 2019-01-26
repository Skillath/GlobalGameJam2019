using GGJ2019.Core.Entities;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using UnityEngine.Networking;
using Application = UnityEngine.Application;


namespace GGJ2019.UnityCore.Entities
{
    public class Loader : ILoader
    {
        public async Task<T> LoadFromStreamingAssets<T>(string fileName)
        {
            string filePath = Path.Combine(Application.streamingAssetsPath, fileName);

            var www = UnityWebRequest.Get(filePath);
            await www.SendWebRequest();
            var json = www.downloadHandler.text;

            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
