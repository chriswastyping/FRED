using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Owner : MonoBehaviour
{
    //public float speed = 3.0f;
    //private Rigidbody ownerRb;
    //private GameObject player;

    // Nav Mesh

    public Transform player;
    private NavMeshAgent agent;

    void Start()
    {
        //ownerRb = GetComponent<Rigidbody>();
        //player = GameObject.Find("Fred");

        agent = GetComponent<NavMeshAgent>();
    }

    void FixedUpdate()
    {
       
           // Vector3 lookDirection = (player.transform.position - transform.position).normalized;
           // ownerRb.velocity = lookDirection * speed;

            agent.destination = player.position;

    }
}