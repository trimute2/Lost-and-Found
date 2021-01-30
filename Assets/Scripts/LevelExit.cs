using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class LevelExit : MonoBehaviour
{
	public string NextLevelName;
	public bool CanOpen = true;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(CanOpen && collision.GetComponent<Character>() != null)
		{
			SceneManager.LoadScene(NextLevelName);
		}
	}

	public void SetOpen(bool newOpen)
	{
		CanOpen = newOpen;
	}

}
