using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyScript : MonoBehaviour
{

	public UnityEvent OnKeyPickUp;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.GetComponent<Character>() != null)
		{
			OnKeyPickUp.Invoke();
			DestroyKey();
		}
	}

	public void DestroyKey()
	{
		Destroy(gameObject);
	}
}
