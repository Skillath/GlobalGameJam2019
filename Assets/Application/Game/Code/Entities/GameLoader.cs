using GGJ2019.Game.Entities;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using Zenject;

namespace GGJ2019.UnityGames.Entities
{
    public class GameLoader : IGameLoader
    {
        private readonly ZenjectSceneLoader sceneLoader;
        private readonly DiContainer container;

        private Scene? currentScene = null;

        public GameLoader(ZenjectSceneLoader sceneLoader, DiContainer container)
        {
            this.sceneLoader = sceneLoader;
            this.container = container;
        }

        public async Task<IGameType> LoadGame(int buildIndex)
        {
            var tcs = new TaskCompletionSource<IGameType>();
            void onSceneLoaded(Scene scene, LoadSceneMode mode)
            {
                if (tcs.Task.IsCompleted || tcs.Task.IsCanceled || tcs.Task.IsFaulted)
                {
                    return;
                }

                if (scene.buildIndex == buildIndex)
                {
                    currentScene = scene;
                    SceneManager.SetActiveScene(scene);
                    var gameType = scene.GetRootGameObjects().FirstOrDefault().GetComponent<BaseGameType>();
                    tcs.SetResult(gameType);
                }
            }

            SceneManager.sceneLoaded += onSceneLoaded;
            _ = sceneLoader.LoadSceneAsync(buildIndex, LoadSceneMode.Additive);
            await tcs.Task;
            SceneManager.sceneLoaded -= onSceneLoaded;

            if (tcs.Task.IsCompleted && !tcs.Task.IsCanceled && !tcs.Task.IsFaulted)
            {
                return tcs.Task.Result;
            }

            tcs = null;
            return null;
        }

        public async Task Unload()
        {
            if (!currentScene.HasValue)
            {
                return;
            }

            await SceneManager.UnloadSceneAsync(currentScene.Value);
            currentScene = null;
        }
    }
}
