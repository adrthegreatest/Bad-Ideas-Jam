using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; 
    public float smoothSpeed = 5f; 
    private Vector3 offset;

    void Start()
    {
        offset = new Vector3(transform.position.x, 0, transform.position.z);
    }

    void LateUpdate()
    {
        float targetY = Mathf.Lerp(transform.position.y, player.position.y, smoothSpeed * Time.deltaTime);
        Vector3 newPosition = new Vector3(offset.x, targetY, offset.z);
        transform.position = newPosition;
    }
}