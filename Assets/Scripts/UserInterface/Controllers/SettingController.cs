using ChessGame.Extensions;
using ChessGame.UserInterface.Views;
using UnityEngine;
using UnityEngine.UI;
using UserInterface.Views;

namespace ChessGame.UserInterface.Controllers
{
    public class SettingController : MonoBehaviour
    {
        [SerializeField] private GameObject settingView;
        [SerializeField] private MultiLangView settingLangView;
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
            rateBtn.AddCustomListener(() =>
            {
                rateView.Open(() =>
                {
                    
                    var configValue = Utils.GetConfigValue();
                    if (configValue.iap == "bazaar")
                        Utils.OpenCafeBazaarRateUs();
                    else
                        Utils.OpenMyketRateUs();
                });
            });
            supportBtn.AddCustomListener(Utils.ContactSupport);
            changeLanguageBtn.AddCustomListener(() =>
            {
                settingLangView.Fetch();
            });
        }
    }
}