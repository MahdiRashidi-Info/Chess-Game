using ChessGame.UserInterface.Controllers;
using ChessGame.UserInterface.Views;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UserInterface.Views
{
	public class MainMenu : MonoBehaviour
	{
    
		public void PlayGame(int mode)
		{
			//1 == cpu
			//0 == 1v1

			if (mode == 1)
			{
				var i = PlayerPrefs.GetInt("Coin");
				if (i < 1000)
				{
					MessageBoxController.Instance.Show("You do not have enough coin!" , () =>
					{
						ShopView.Instance.Open(i);
					});
					return;
				}
			}
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
			PlayerPrefs.SetInt("PlayMode" ,mode);
		
		}

		public void QuitGame()
		{
			Debug.Log("Quit Game!");
			Application.Quit();
		}

	}
}
