using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

	public void LoadLevel (string name)
	{
		SceneManager.LoadScene (name);
	}

	public void QuitGame (string name)
	{
		Application.Quit ();
	}

	public void LoadNextLevel ()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void BrickDestoryed ()
	{
//		print(brick.brickCount);
		if (brick.brickCount <= 0) {
			LoadNextLevel ();
		}
			
	}

	void Update ()
	{
		if (Input.GetKey ("escape")) {
			Application.Quit ();
        
		}
	}

}
