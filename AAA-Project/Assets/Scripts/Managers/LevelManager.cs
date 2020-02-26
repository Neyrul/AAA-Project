using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
	internal System.Action Callback_OnLevelWasLoaded = null;

	void Start ()
	{
		SceneManager.sceneLoaded += LevelWasLoaded;
	}

	internal void LoadLevel (int levelToLoad)
	{
		System.GC.Collect();
		SceneManager.LoadScene(levelToLoad);
	}

	internal void LoadLevel (string levelToLoad)
	{
		System.GC.Collect();
		SceneManager.LoadScene(levelToLoad);
	}

	internal void LoadMenu ()
	{
		System.GC.Collect();
		LoadLevel(0);
	}

	internal void LoadNextLevel ()
	{
		int activeSceneCount = SceneManager.GetActiveScene().buildIndex;

		if (activeSceneCount != SceneManager.sceneCountInBuildSettings - 1)
			LoadLevel(activeSceneCount + 1);

		else
			LoadMenu(); // ou load l'écran de fin
	}

	void LevelWasLoaded (Scene scene, LoadSceneMode mode)
	{
		if (scene.buildIndex != 0)
			Callback_OnLevelWasLoaded?.Invoke();
	}
}
