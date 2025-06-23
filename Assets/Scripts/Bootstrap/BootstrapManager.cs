using Cysharp.Threading.Tasks;
using Data;
using ServiceLocatorRelated;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Bootstrap
{
    public class BootstrapManager : MonoBehaviour
    {
        [SerializeField] private CinemachineBrain _mainCamera;
        [SerializeField] private Image _loadingBar;
        
        private async void Awake()
        {
            DontDestroyOnLoad(_mainCamera);
            await ServiceLocator.IsInitialized();
            var operation = SceneManager.LoadSceneAsync(Tags.SceneNames.GAMEPLAY);
            await LoadingScreen(operation);
        }

        private async UniTask LoadingScreen(AsyncOperation operation)
        {
            while (!operation.isDone)
            {
                _loadingBar.fillAmount += operation.progress;
                await UniTask.Yield();
            }
        }
    }
}