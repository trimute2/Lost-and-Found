using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
	public bool White;


    // Start is called before the first frame update
    void Awake()
    {
		ColorChange.OnColorChangeEvent += OnColorChange;
    }

	private void OnDestroy()
	{
		ColorChange.OnColorChangeEvent -= OnColorChange;
	}

	public void OnColorChange(bool Color)
	{
		gameObject.SetActive(Color == White);
	}
}
