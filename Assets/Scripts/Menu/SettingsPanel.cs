using Core;
using UnityEngine;

namespace Menu
{
    public class SettingsPanel : BaseUIPanel
    {
        public override UIPanelType Type => UIPanelType.SettingsPanel;

        public override void OnPush()
        {
            gameObject.SetActive(true);
        }

        public override void OnPop()
        {
            gameObject.SetActive(false);
        }
    }
}