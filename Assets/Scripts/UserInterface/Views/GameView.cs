using System;
using ChessGame.Extensions;
using RTLTMPro;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChessGame
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private AvatarFrameComponent firstPlayer;
        [SerializeField] private AvatarFrameComponent secondPlayer;
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private GameObject usernameBox;
        [SerializeField] private GameObject gameManager;
        [SerializeField] private Button startGameBtn;


        public string secondUsername { get; set; }
        public static GameView Instance;

        private void Awake()
        {
            //1 == cpu
            //0 == 1v1
            
            Instance = this;
            var i = PlayerPrefs.GetInt("PlayMode");
            if (i == 1)
            {
                StartGame();
                secondPlayer.Fetch(PlayerPrefs.GetString("Username"));
                firstPlayer.Fetch("CPU");
            }
            else
                OpenUsernameBox();
        }

        private void OpenUsernameBox()
        {
            usernameBox.SetActive(true);
            startGameBtn.interactable = false;
            inputField.onValueChanged.RemoveAllListeners();
            inputField.onValueChanged.AddListener(arg0 => { startGameBtn.interactable = arg0.Length > 0; });
            startGameBtn.AddCustomListener(() =>
            {
                StartGame();
                secondPlayer.Fetch(PlayerPrefs.GetString("Username"));
                secondUsername = inputField.text.Trim();
                
                firstPlayer.Fetch(inputField.text.Trim());
            });
        }

        public void StartGame()
        {
            usernameBox.SetActive(false);
            gameManager.SetActive(true);
        }

        public void ChangeTurn(bool isWhiteTurn)
        {
            if (isWhiteTurn)
                firstPlayer.ItsTurn();
            else
                secondPlayer.ItsTurn();
        }
    }
}