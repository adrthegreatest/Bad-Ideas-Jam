using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Groundcheck : MonoBehaviour
{
    public bool grounded;
    int groundedTimer;

    void Update()
    {
        if (groundedTimer >= 2)
        {
            grounded = false;
        } else
        {
            grounded = true;
        }
        
        groundedTimer += 1;
    }

    private void OnTriggerStay2D(Collider2D col)
    {

        if (col.tag == "Ground" || col.tag == "Player"){
        groundedTimer = 0;
        }
    }
}
