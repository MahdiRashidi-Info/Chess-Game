using System.Collections;
using System.Collections.Generic;
using ChessGame;
using RTLTMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UserInterface.Components;

public class GameOverView : MonoBehaviour
{
    public static GameOverView Instance { set; get; }

    public GameObject gameOverUI;
    [SerializeField] private AvatarFrameComponent firstPlayer;
    [SerializeField] private AvatarFrameComponent secondPlayer;

    [SerializeField] private RTLTextMeshPro title;

    private void Start()
    {
        Instance = this;
    }

    public void GameOverMenu(bool isWhiteTurn)
    {
        gameOverUI.SetActive(true);

        Time.timeScale = 0f;
        title.text = isWhiteTurn ? $"{PlayerPrefs.GetString("Username")} is a winner!" : $"{GameView.Instance.secondUsername} is a winner!";

        var i = PlayerPrefs.GetInt("PlayMode");
        if (i == 1)
        {
            secondPlayer.Fetch(PlayerPrefs.GetString("Username"));
            firstPlayer.Fetch("CPU");
        }
        else
        {
            secondPlayer.Fetch(PlayerPrefs.GetString("Username"));
            firstPlayer.Fetch(GameView.Instance.secondUsername);
        }
    }

    public void Quit()
    {
        Debug.Log("Quit Game!!");
        Application.Quit();
    }

    public void MainMenu()
    {
        gameOverUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}