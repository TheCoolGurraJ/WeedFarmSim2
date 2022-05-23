using UnityEngine;
using UnityEngine.SceneManagement;


[CreateAssetMenu(menuName = "SceneChanger")]
public class SceneChanger : ScriptableObject
{
	public void ChangeScene()
	{
		string[] scenes = { "Main", "House" };

		Scene curr_scene = SceneManager.GetActiveScene();

		foreach (string scene in scenes)
		{
			if (scene != curr_scene.name)
			{
				SceneManager.LoadScene(scene);
			}
		}
	}
	public void Exit()
	{
		Application.Quit();
	}
}