
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	private void Start()
	{
		FinishFlag.EndLevel += LevelPassed;
		PlayerLife.PlayerDied += RestartLevel;
		
		SoundManager.Play("Background");
	}
	
	private void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	private void LevelPassed()
	{ 
		SoundManager.Play("Finish");
		// Invoke(nameof(NextLevel), 2f);
		NextLevel();
	}

	private void NextLevel()
	{
		if (SceneManager.GetActiveScene().buildIndex + 1 >= SceneManager.sceneCountInBuildSettings)
			SceneManager.LoadScene(0);
		else
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
