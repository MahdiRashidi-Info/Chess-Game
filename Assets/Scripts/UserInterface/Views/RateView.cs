using System;
using ChessGame.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace ChessGame.UserInterface.Views
{
    public class RateView : MonoBehaviour
    {
        [SerializeField] private Button maybeBtn;
        [SerializeField] private Button rateBtn;

        public void Open(Action action)
        {
            gameObject.SetActive(true);
            maybeBtn.AddCustomListener(() => gameObject.SetActive(false));
            rateBtn.AddCustomListener(action);
        }
    }
}