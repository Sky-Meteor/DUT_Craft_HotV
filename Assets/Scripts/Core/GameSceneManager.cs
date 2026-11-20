using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Core
{
    public class GameSceneManager : MonoSingleton<GameSceneManager>
    {
        public SceneType currentScene = SceneType.InitializeScene;

        protected override void SafeAwake()
        {
            SceneManager.activeSceneChanged += OnActiveSceneChanged;
        }
        
        private void Start()
        {
            if (currentScene == SceneType.InitializeScene)
            {
                SceneManager.LoadScene(nameof(SceneType.Menu));
            }
        }

        private void Update()
        {
            
        }

        private void OnActiveSceneChanged(Scene current, Scene next)
        {
            UIManager.Instance.OnSceneChanged(current, next);
        }
    }

    public enum SceneType
    {
        InitializeScene,
        Menu
    }
}