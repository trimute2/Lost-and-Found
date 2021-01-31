using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed;
    public float upspeed;

    public Transform MovePosition;

    public Animator playerAnimator;

    private Rigidbody2D Rig;
    private float horizontal;
    private float distToGround;
    private bool faceRight = true;

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
        //updates player Animation based on speed
        playerAnimator.SetFloat("Speed", Mathf.Abs(speed * horizontal));
        Move(horizontal);//move method to change animation
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Rig.AddForce(Vector3.up * upspeed, ForceMode2D.Impulse);
            playerAnimator.SetBool("isJumping", true);
        }
        else if (IsGrounded())
        {
            playerAnimator.SetBool("isJumping", false);//when grounded stop jumping
            playerAnimator.SetBool("isGrounded", true);//when grounded stop jumping

        }
    }

    bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, -Vector2.up, 1.5f, LayerMask.GetMask("Ground"));
    }

    //checking horizontal 
    private void Move(float horizontal)
    {
        if (horizontal > 0 && !faceRight)
        {
            // ... flip the player.
            Flip();
        }
        else if (horizontal < 0 && faceRight)
        {
            // ... flip the player.
            Flip();
        }

    }
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        faceRight = !faceRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.Equals("Platform1") || collision.gameObject.name.Equals("Platform2"))
        {
            this.transform.parent = collision.transform;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Platform1") || collision.gameObject.name.Equals("Platform2"))
        {
            this.transform.parent = null;
        }
    }
}

   
