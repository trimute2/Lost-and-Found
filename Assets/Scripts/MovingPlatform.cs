using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public Transform MovePosition;

    private Vector3 StartPosition;
    private Vector3 EndPosition;
    private bool OnTheMove;

    // Use this for initialization
    void Start()
    {
       
        StartPosition = this.transform.position;
        EndPosition = MovePosition.position;
    }

    void FixedUpdate()
    {

        float step = speed * Time.deltaTime;

        if (OnTheMove == false)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, EndPosition, step);
        }
        else
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, StartPosition, step);
        }

        if (this.transform.position.x == EndPosition.x && this.transform.position.y == EndPosition.y && OnTheMove == false)
        {
            OnTheMove = true;
        }
        else if (this.transform.position.x == StartPosition.x && this.transform.position.y == StartPosition.y && OnTheMove == true)
        {
            OnTheMove = false;
        }
    }
}
