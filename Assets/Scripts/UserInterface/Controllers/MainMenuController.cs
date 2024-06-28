using ChessGame;
using Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface.Controllers
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private MainMenuView menuView;
        [SerializeField] private GotUsernameView getUsernameView;
        [SerializeField] private ShopView shopView;
        [SerializeField] private Button quitBtn;
        [SerializeField] private Button shopBtn;
        [SerializeField] private Button editBtn;
        [SerializeField] private Button plusIconBtn;

        private void Awake()
        {
            FetchMainMenuUI();

            quitBtn.AddCustomListener(Application.Quit);
            editBtn.AddCustomListener(() =>
            {
                getUsernameView.Open(s =>
                {
                    PlayerPrefs.SetString("Username", s);
                    FetchMainMenuUI();
                });
            });
            shopBtn.AddCustomListener(() => shopView.Open(PlayerPrefs.GetInt("Coin")));
            
            plusIconBtn.AddCustomListener(() => shopView.Open(PlayerPrefs.GetInt("Coin")));
        }

        private void FetchMainMenuUI()
        {
            var exist = PlayerPrefs.HasKey("Username");
            if (exist)
            {
                getUsernameView.Close();
                menuView.FetchUI(PlayerPrefs.GetString("Username"), PlayerPrefs.GetInt("Coin"));
            }
            else
            {
                getUsernameView.Open(s =>
                {
                    PlayerPrefs.SetString("Username", s);
                    PlayerPrefs.SetInt("Coin", 100);
                    FetchMainMenuUI();
                });
            }
        }
    }
}