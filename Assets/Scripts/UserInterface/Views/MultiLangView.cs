using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChessGame;
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
                variable.AddCustomListener(async () =>
                {
                    MultiLanguageController.Instance.ChangeLanguage(variable.name);
                    MessageBoxController.Instance.Show("The Language has been Changed" , () =>
                    {
                    });
                    await Task.Delay(TimeSpan.FromSeconds(1));
                    
                    if(Application.platform == RuntimePlatform.Android)
                        Utils.RestartApp();
                });
            }

            backBtn.AddCustomListener(() => gameObject.SetActive(false));
        }
    }
}