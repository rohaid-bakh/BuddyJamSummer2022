using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//should probably make this a static class
public class LevelHandler : MonoBehaviour
{
    //TODO:: Add in level progression / Loading in an end screen 
        //TODO:: Put the icons on the map back to the legend area 
        //TODO:: Clear the memory in the Units
        //TODO:: Clear the textbox and set it to automatically load in the first message in a new level.

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
        if (currLevel >= 0 && currLevel < Levels.Length){
            if(currLevel > 0){
                //clears the dictionary used.
                mapHandler.resetMap();
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

        if(currLevel == Levels.Length){
            loadEndScene();
        }

    }

    private void loadEndScene(){
        SceneManager.LoadScene("EndScene");
    }
}
