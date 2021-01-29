using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed;
    public float upspeed;

    public Transform MovePosition;

    private Rigidbody2D Rig;
    private float horizontal;

    // Start is called before the first frame update
    void Start()
    {
        Rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        Rig.velocity = new Vector3(speed * horizontal, Rig.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rig.AddForce(Vector3.up * upspeed, ForceMode2D.Impulse);
        }
    }
}
