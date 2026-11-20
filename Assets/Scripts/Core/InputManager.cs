using System;
using UnityEngine.InputSystem;

namespace Core
{
    public class InputManager : MonoSingleton<InputManager>
    {
        InputAction cancelAction;

        public void Start()
        {
            cancelAction = InputSystem.actions.FindAction("UI/Cancel");
        }

        public void Update()
        {
            if (cancelAction.triggered)
            {
                UIManager.Instance.PopPanel();
            }
        }
    }
}