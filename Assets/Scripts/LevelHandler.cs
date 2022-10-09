using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//should probably make this a static class
public class LevelHandler : MonoBehaviour
{
   

    [SerializeField]
    private Level[] Levels;
    private int currLevel = 0;
    [SerializeField]
    private MapHandler mapHandler;
    [SerializeField]
    private UIAssistant uiAssistant;

    [SerializeField]
    private Image map;

    void Start()
    {
        loadLevel();

    }

    public void loadLevel()
    {
        if(currLevel == Levels.Length){
            loadEndScene();
        }
        if (currLevel >= 0 && currLevel < Levels.Length){
            if(currLevel > 0){
                //clears the dictionary used.
                mapHandler.resetMap();
                //added this to add TextSFX at the start of a new map
                FindObjectOfType<AudioManager>().Play("TextSFX");
                //fixes bug that would skip messages after loading in a new map
                FindObjectOfType<UIAssistant>().messageArrayNumber = 0;
            }
            if (Levels.Length != 0 && uiAssistant != null){
                uiAssistant.messageArray = Levels[currLevel].text;
            }
            else{
                Debug.LogWarning("Either the Levels array is empty or the UI assistant variable in LevelHandler is Empty. Fix this.");
            }

            if (mapHandler != null){
                mapHandler.setUpAnswer(Levels[currLevel].places, Levels[currLevel].coordinates);
            }
            else{
                Debug.LogWarning("MapHandler variable in LevelHandler is Empty. Fix this.");
            }

            if (Levels[currLevel].characters != null){
                uiAssistant.npcSprites = Levels[currLevel].characters;
                 uiAssistant.LoadNewDialogue();
            }
            else{
                Debug.LogWarning("Levels has an item without sprites. Fix this");
            }

            if(map != null){
                map.sprite = Levels[currLevel].map;
            }
        currLevel++;
        }

        

    }

    private void loadEndScene(){
        SceneManager.LoadScene("EndScene");
    }
}
