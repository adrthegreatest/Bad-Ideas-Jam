using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /*

    hello would it be OK if you used the other playercontroller script? it already works and is simpler, you can edit it if you want
    it can also flip the player
    happy gamedeving :)

    */

    private float horizontal;
    private float speed = 3.5f;
    public float jumpingPower = 10f;
    private bool isFacingRight = true;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator anim;


    private void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey("w") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        anim.SetBool("isWalking", horizontal != 0);

        anim.SetBool("isinAir", !IsGrounded());

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }


        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}