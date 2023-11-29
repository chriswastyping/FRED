using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owner : MonoBehaviour
{
    public float speed = 3.0f;
    private Rigidbody ownerRb;
    private GameObject player;

    void Start()
    {
        ownerRb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
    }

    void FixedUpdate()
    {
        if (player != null) // Check if the player object is valid
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            ownerRb.velocity = lookDirection * speed;
        }
    }
}