using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Player Movement Component
    public CharacterController controller;

    public float directionLength = 0.1f;

    // for Movement with Camera and Cinemachine

    public Transform cam;
    
    public float speed = 10.0f;

    public float turnSmoothTime = 0.1f;
    
    float turnSmoothVelocity;

    // Mouse reference

    public bool hasMouse;

    //Game Over

    public bool gameOver = false;

    // Jump

    Vector3 velocity;

    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundLayerMask;
    bool isGrounded;
    public float jumpHeight = 3f;

    // Calling Pause() method from PauseMenu Script
    PauseMenu pauseMenuScript;

    // Audio
    public AudioSource source;
    public AudioClip clip;

    // Score

    private int scoreCount;

    public TextMeshProUGUI scoreText;

    // Power Up
    public GameObject energy;
    public GameObject trail;
    public bool power = false;


    private void Start()
    {
        // So we can access the methods in PauseMenu
        pauseMenuScript = GameObject.FindGameObjectWithTag("Pause Menu").GetComponent<PauseMenu>();

        // Score
        scoreCount = 0;
    }

    // Update is called once per framef
    void Update()
    {
        if (scoreCount == 20)
        {
              gameOver = true;
        }

        UpdateScore();
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayerMask);

        if (isGrounded && velocity.y < 0) 

        { 
            velocity.y = -0.2f;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if (direction.magnitude >= directionLength)

        {
            // Cinemachine Camera Rotation
            // Smoothes rotation of character
            // Camera movement affects the character direction
            // Works with the character controller

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move((moveDirection.normalized * Time.deltaTime) * speed);
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded) 
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Mouse")) 
        { 
            hasMouse = true;
            Destroy(other.gameObject);
            source.PlayOneShot(clip);
            StartCoroutine(SpeedBoost());
            scoreCount++;
             
        }
        else if (other.CompareTag("Owner"))
        {
            
            if(gameObject != null) 
            {
                Destroy(gameObject);
                // Calling Pause() method to run when player dies!!!
                pauseMenuScript.Pause();

            }
            gameOver = true;
            Debug.Log("Game Over");

            
           
        }
    }

    IEnumerator SpeedBoost()
    {
        speed = 25f;
        energy.SetActive(true);
        trail.SetActive(true);

        yield return new WaitForSeconds(60);

       speed = 10f;
       energy.SetActive(false);
      trail.SetActive(false);

        yield return null;

    }

    private void UpdateScore()
    {

        scoreText.text = "Score: " + scoreCount + "/20";
    }
}

