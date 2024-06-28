using System;
using Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChessGame
{
    public class GotUsernameView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private Button saveBtn;

        private void Awake()
        {
            inputField.onValueChanged.RemoveAllListeners();
            inputField.onValueChanged.AddListener(arg0 =>
            {
                saveBtn.interactable = arg0.Length > 0;
            });
            
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
        public void Open(Action<string> clickSaveBtn)
        {
            gameObject.SetActive(true);
            saveBtn.AddCustomListener(() =>
            {
                if (inputField.text.Length > 0)
                {
                    clickSaveBtn?.Invoke(inputField.text.Trim());
                    Close();
                }
            });

            saveBtn.interactable = false;
            inputField.text = string.Empty;
            
        }
    }
}