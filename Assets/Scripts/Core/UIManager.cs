using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Core
{
    public class UIManager : MonoSingleton<UIManager>
    {
        [SerializeField] private RectTransform canvasTransform;

        public List<GameObject> sceneUIRoot;
        
        private Dictionary<UIPanelType, BaseUIPanel> _panels;
        public Stack<BaseUIPanel> panelStack;
        
        protected override void SafeAwake()
        {
            sceneUIRoot = new List<GameObject>();
            
            _panels = new Dictionary<UIPanelType, BaseUIPanel>();
            panelStack = new Stack<BaseUIPanel>();
        }

        private void Start()
        {
            
        }

        private void Update()
        {
            
        }

        public void PushPanel(UIPanelType panelType)
        {
            var panel = GetPanel(panelType);
            panelStack.Push(panel);
            panel.OnPush();
        }

        public void PopPanel()
        {
            if (panelStack.Count <= 0)
                return;
            var panel = panelStack.Peek();
            panel.OnPop();
            panelStack.Pop();
        }

        public BaseUIPanel GetPanel(UIPanelType panelType)
        {
            if (_panels.Count > 0 && _panels.TryGetValue(panelType, out var panel))
                return panel;
            var panelObject = Resources.Load<GameObject>($"Prefabs/UI/{panelType.ToString()}");
            if (panelObject == null)
            {
                Debug.LogError($"Panel Prefabs/UI/{panelType.ToString()} not found");
                return null;
            }
            panel = Instantiate(panelObject, canvasTransform).GetComponent<BaseUIPanel>();
            _panels.Add(panelType, panel);
            return panel;
        }
        
        public T GetPanel<T>(T p) where T : BaseUIPanel
        {
            return GetPanel(p.Type) as T;
        }

        public void OnSceneChanged(Scene current, Scene next)
        {
            if (next.name == nameof(SceneType.InitializeScene))
                return;
            
            foreach (var go in sceneUIRoot)
            {
                Destroy(go);
            }
            sceneUIRoot.Clear();
            var rootObject = Resources.Load<GameObject>($"Prefabs/UI/{next.name}Root");
            if (rootObject == null)
            {
                Debug.LogError($"Prefabs/UI/{next.name}Root not found");
                return;
            }
            var root = Instantiate(rootObject, canvasTransform);
            sceneUIRoot.Add(root);
        }
    }

    public enum UIPanelType
    {
        SettingsPanel,
        Profile
    }
}