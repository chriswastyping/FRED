using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Player Movement Component
    public CharacterController controller;

    // for Cinemachine

    public Transform cam;
    
    public float speed = 5.0f;

    public float turnSmoothTime = 0.1f;
    
    float turnSmoothVelocity;

    // Not in use atm
    private Rigidbody playerRb;

    // Mouse reference

    public bool hasMouse;

    //Game Over

    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if (direction.magnitude >= 0.1f)

        { 
  
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            //Smoothes rotation of character

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            
            // Move Directions and camera movement

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDirection.normalized * Time.deltaTime * speed);
        }

     
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Mouse")) 
        { 
            hasMouse = true;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Owner"))
        {
            
            Destroy(gameObject);
            Debug.Log("Game Over");
            gameOver = true;
        }
    }
}
