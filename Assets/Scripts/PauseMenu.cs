using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;

    private Control control;

    private void Awake()
    {
        control = new Control();
        control.Keyboard.Pause.performed += ctx => PauseButtonPressed();
    }

    private void Start()
    {
        if(pauseMenu!= null){
        pauseMenu.SetActive(false);
        }
    }

    public void PauseButtonPressed()
    {
        Debug.Log("Pause Pressed");
        if (!isPaused)
        {
            PauseGame();
        }

        else
        {
            ResumeGame();
        }
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    private void OnEnable()
    {
        control.Enable();
    }

    private void OnDisable()
    {
        control.Disable();
    }


    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
