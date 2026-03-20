using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerflip : MonoBehaviour
{
    private SpriteRenderer spriterenderer;
    private void Awake()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    public void Flip()
    {

        if (Input.GetKey(KeyCode.A))
        {
            if (spriterenderer != null)
            {
                spriterenderer.flipX = true;
            }
        }

    }
}
