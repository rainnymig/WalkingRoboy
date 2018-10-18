using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ROSBridge;

namespace RoboyWalk
{
    public class UIManager : Singleton<UIManager>
    {
        public TextMeshProUGUI InfoDisplay;

        public void ShowInfo(string info)
        {
            InfoDisplay.text = info;
        }

        protected UIManager() { }
    }
}

