using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
	public void PlayGame(int mode)
	{
		//1 == cpu
		//0 == 1v1
		
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		PlayerPrefs.SetInt("PlayMode" ,mode);
		
	}

	public void QuitGame()
	{
		Debug.Log("Quit Game!");
		Application.Quit();
	}

}
