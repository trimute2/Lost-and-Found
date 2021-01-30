using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using System;

[Serializable]
public class PressurePlateEvent : UnityEvent<bool> { };

[RequireComponent(typeof(Collider2D))]
public class PressurePlateScript : MonoBehaviour
{

	public PressurePlateEvent OnPressureplateEvent;

	private Collider2D collider;
	private int touchCount;

	private void Start()
	{
		collider = GetComponent<Collider2D>();
		touchCount = 0;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		touchCount++;
		TestTrigger();
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		touchCount--;
		TestTrigger();
	}

	private void OnEnable()
	{
		TestTrigger();
	}

	private void OnDisable()
	{
		OnPressureplateEvent.Invoke(false);
	}

	private void TestTrigger()
	{
		if (enabled)
		{
			if (touchCount > 0)
			{
				OnPressureplateEvent.Invoke(true);
			}
			else
			{
				OnPressureplateEvent.Invoke(false);
			}
		}
	}


}
