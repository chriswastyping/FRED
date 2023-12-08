using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    // Can use this later in other scripts
    // I.e lower the volume of the music in the audio manager etc.
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key pressed");
            if (gameIsPaused)
            {
                Debug.Log("Resuming");
                Resume();

            }
            else
            {
                Debug.Log("Pausing");
                Pause();
            }
        }


        MousePointer();
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        // Slow motion effects as well!
        // Used to freeze the game
        Time.timeScale = 1f;
        gameIsPaused = false;
        Debug.Log("Resume Button");
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void LoadMenu()
    {

        Debug.Log("Loading Game...");
    }

    public void QuitGame()
    {
       
        Debug.Log("Quitting Game...");
    }


    public void MousePointer()
    {

        //     When game is paused the pointer is visible

        if (gameIsPaused == true)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }

        else 
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }


    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        Debug.Log("Restart Button");
    }

}
