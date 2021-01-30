using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public GameObject Black;
    public GameObject White;

    private Transform Blackpos;
    private Transform Whitepos;
    private Camera cm;
    // Start is called before the first frame update
    void Start()
    {
        cm = GetComponent<Camera>();
        Blackpos = Black.transform;
        Whitepos = White.transform;
    }

    // Update is called once per frame
    void Update()
    {
        var b = Blackpos.position;
        var w = Whitepos.position;
        if(cm.backgroundColor == Color.black)
        {
            b.y = 50;
            w.y = 0;
            Black.transform.position = b;
            White.transform.position = w;
        }
        else
        {
            w.y = 50;
            b.y = 0;
            White.transform.position = w;
            Black.transform.position = b;
        }
    }
}
