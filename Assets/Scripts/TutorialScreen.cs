using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScreen : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 0f;
        
    }

    public void OpenTutorial()
    {
        Time.timeScale = 0f;
        tutorialPanel.SetActive(true);
        FindObjectOfType<AudioManager>().Stop("TextSFX");

    }

    [SerializeField] GameObject tutorialPanel;
    public void CloseTutorial()
    {
        Time.timeScale = 1f;
        //FindObjectOfType<AudioManager>().Play("TextSFX");
        if (!FindObjectOfType<PauseMenu>().textFinished)
        {
            FindObjectOfType<AudioManager>().Play("TextSFX");
        }
        tutorialPanel.SetActive(false);
        
    }
}
