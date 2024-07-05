using System;
using System.Collections.Generic;
using ChessGame.UserInterface.Controllers;
using RTLTMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChessGame.UserInterface.Components
{
    public class CurrentLanguageComponent : MonoBehaviour
    {
        [SerializeField] private RTLTextMeshPro currentText;
        [SerializeField] private Image currentIcon;
        
        [SerializeField] private List<Sprite> icons;

        private void OnEnable()
        {
            var instanceCurrentLanguage = MultiLanguageController.Instance.CurrentLanguage;
            switch (instanceCurrentLanguage)
            {
                case "persian":
                    currentText.text = "Persian";
                    currentIcon.sprite = icons[1];
                    break;
                case "english":
                    currentText.text = "English";
                    currentIcon.sprite = icons[1];
                    break;
                case "germany":
                    currentText.text = "Germany";
                    currentIcon.sprite = icons[2];
                    break;
                case "turkey":
                    currentText.text = "Turkish";
                    currentIcon.sprite = icons[3];
                    break;
            }
        }
    }
}