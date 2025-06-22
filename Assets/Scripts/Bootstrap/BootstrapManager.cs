using Cysharp.Threading.Tasks;
using Data;
using ServiceLocatorRelated;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Bootstrap
{
    public class BootstrapManager : MonoBehaviour
    {
        private async void Awake()
        {
            bool result = await ServiceLocator.IsInitialized();
            await UniTask.WaitUntil(() => result);
            SceneManager.LoadScene(Tags.SceneNames.GAMEPLAY);
        }
    }
}