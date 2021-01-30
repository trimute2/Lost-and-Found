using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;


public class ColorChange : MonoBehaviour
{

	public static event Action<bool> OnColorChangeEvent;

    Camera cm;
    // Start is called before the first frame update
    void Start()
    {
        cm = GetComponent<Camera>();
        cm.backgroundColor = Color.white;
		OnColorChangeEvent?.Invoke(false);
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
			OnColorChangeEvent?.Invoke(cm.backgroundColor == Color.white);
            if(cm.backgroundColor == Color.white)
            {
                cm.backgroundColor = Color.black;
            }
            else
            {
                cm.backgroundColor = Color.white;
            }
        }
    }
}
