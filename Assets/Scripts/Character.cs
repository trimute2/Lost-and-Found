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
    private float distToGround;

    // Start is called before the first frame update
    void Start()
    {
        Rig = GetComponent<Rigidbody2D>();
        distToGround = GetComponent<Collider2D>().bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        Rig.velocity = new Vector3(speed * horizontal, Rig.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Rig.AddForce(Vector3.up * upspeed, ForceMode2D.Impulse);
        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 1f);
    }
}
