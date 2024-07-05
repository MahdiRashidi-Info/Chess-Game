using System;
using ChessGame.Extensions;
using RTLTMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChessGame.UserInterface.Controllers
{
    public class MessageBoxController : MonoBehaviour
    {
        [SerializeField] private RTLTextMeshPro textText;
        [SerializeField] private Button confirmBtn;
        [SerializeField] private Button cancelBtn;
        [SerializeField] private GameObject messageObject;


        public static MessageBoxController Instance;

        private void Awake()
        {
            Instance = this;
            
        }
        

        public void Show(string msg , Action confirmAction)
        {
            messageObject.SetActive(true);
            textText.text = msg;
            
            confirmBtn.AddCustomListener(() =>
            {
                confirmAction?.Invoke();
                messageObject.SetActive(false);
            });
            cancelBtn.AddCustomListener(() =>
            {
                messageObject.SetActive(false);
            });
            
        }
    }
}