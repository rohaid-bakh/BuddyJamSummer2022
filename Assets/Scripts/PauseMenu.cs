using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;

    public bool textFinished;

    private Control control;

    public SoundManager soundManager;

    private void Awake()
    {
        control = new Control();
        control.Keyboard.Pause.performed += ctx => PauseButtonPressed();
    }

    private void Start()
    {
        pauseMenu.SetActive(false);
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

        //**OLD SFX
        /*soundManager.stopTextSound = true;
        soundManager.EndTextSound();*/

        //NEW SFX
        FindObjectOfType<AudioManager>().Stop("TextSFX");

        isPaused = true;
    }

    void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

        //**OLD SFX
        /*if (!soundManager.textFinished)
        {
            soundManager.ButtonPressedSFX();
        }*/

        //NEW SFX
        if (!textFinished)
        {
            FindObjectOfType<AudioManager>().Play("TextSFX");
        }


        isPaused = false;
    }

    public void ResetText()
    {
        textFinished = false;
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
