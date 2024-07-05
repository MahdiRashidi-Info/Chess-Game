using System;
using System.Collections.Generic;
using ChessGame.Extensions;
using ChessGame.UserInterface.Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface.Views
{
    public class MultiLangView : MonoBehaviour
    {
        [SerializeField] private List<Button> langButtons;
        [SerializeField] private Button backBtn;

        public void Fetch()
        {
            gameObject.SetActive(true);

            foreach (var variable in langButtons)
            {
                variable.transform.GetChild(0).gameObject
                    .SetActive(variable.name == MultiLanguageController.Instance.CurrentLanguage);
                variable.AddCustomListener(() => MultiLanguageController.Instance.ChangeLanguage(variable.name));
            }

            backBtn.AddCustomListener(() => gameObject.SetActive(false));
        }
    }
}