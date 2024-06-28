using System;
using UnityEngine.UI;

namespace Extensions
{
    public static class ButtonExtension
    {
        public static void AddCustomListener(this Button btn, Action onCLickAction)
        {
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(() => { onCLickAction?.Invoke(); });
        }

    }
}