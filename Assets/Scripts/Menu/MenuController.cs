using System;
using Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Menu
{
    public class MenuController : MonoBehaviour
    {
        public void Awake()
        {
            
        }

        public void Start()
        {

        }

        public void Update()
        {
            
        }

        public void OpenSettings()
        {
            Debug.Log("Opening settings");
            UIManager.Instance.PushPanel(UIPanelType.SettingsPanel);
        }

        public void ExitGame()
        {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
        }
    }
}