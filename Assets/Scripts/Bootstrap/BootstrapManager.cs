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
            bool result = await ServiceLocator.IsInitialized();
            await LoadingScreen();
            await UniTask.WaitUntil(() => result,cancellationToken: gameObject.GetCancellationTokenOnDestroy());
            SceneManager.LoadScene(Tags.SceneNames.GAMEPLAY);
        }

        private async UniTask LoadingScreen()
        {
            while (_loadingBar.fillAmount < 1f)
            {
                _loadingBar.fillAmount += 0.1f;
                await UniTask.Yield(cancellationToken: gameObject.GetCancellationTokenOnDestroy());
            }
        }
    }
}