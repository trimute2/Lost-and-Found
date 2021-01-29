using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{

    Camera cm;
    // Start is called before the first frame update
    void Start()
    {
        cm = GetComponent<Camera>();
        cm.backgroundColor = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
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
