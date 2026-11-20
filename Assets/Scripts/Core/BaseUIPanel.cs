using UnityEngine;

namespace Core
{
    public abstract class BaseUIPanel : MonoBehaviour
    {
        public abstract UIPanelType Type { get; }
        public abstract void OnPush();
        public abstract void OnPop();
    }
}