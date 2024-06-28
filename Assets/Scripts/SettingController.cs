using System;
using ChessGame.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace ChessGame
{
    public class SettingController : MonoBehaviour
    {
        [SerializeField] private GameObject settingView;
        [SerializeField] private RateView rateView;
        [SerializeField] private Button settingBtn;

        [SerializeField] private Button closeBtn;
        [SerializeField] private Button rateBtn;
        [SerializeField] private Button supportBtn;
        [SerializeField] private Button changeLanguageBtn;

        private void Awake()
        {
            settingBtn.AddCustomListener(() => { settingView.SetActive(true); });

            closeBtn.AddCustomListener(() => settingView.SetActive(false));
            rateBtn.AddCustomListener(() => { rateView.Open(); });
            supportBtn.AddCustomListener(() => { });
            changeLanguageBtn.AddCustomListener(() => { });
        }
    }
}