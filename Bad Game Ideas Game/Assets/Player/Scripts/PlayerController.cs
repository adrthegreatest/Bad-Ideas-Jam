using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    [SerializeField] public bool player1;

    public Groundcheck groundcheck;

    public float speed;
    public float jumpHeight;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player1)
        {
            Control1();
        } else
        {
            Control2();
        }
    }

    public void Control1()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Move(-speed);
        } else if (Input.GetKey(KeyCode.D))
        {
            Move(speed);
        } else
        {
            Move(0);
        }
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            Jump(jumpHeight);
        }
    }

    public void Control2()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Move(-speed);
        } else if (Input.GetKey(KeyCode.RightArrow))
        {
            Move(speed);
        } else
        {
            Move(0);
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump(jumpHeight);
        }
    }

    public void Move(float speed)
    {
        rb.velocityX = Mathf.Lerp(rb.velocityX, speed, Time.deltaTime*15);

        if (speed > 0)
        {
            sprite.flipX = false;
        } else
        {
            sprite.flipX = true;
        }
    }

    public void Jump(float jumpHeight)
    {
        if (groundcheck.grounded)
        {
            rb.velocityY = jumpHeight;
        }
    }

}
