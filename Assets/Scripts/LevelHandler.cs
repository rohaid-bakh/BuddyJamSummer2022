using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    //TODO:: Add in level progression / Loading in an end screen 
    
    [SerializeField]
    private Level[] Levels;
    private int currLevel = 0;
    [SerializeField]
    private MapHandler mapHandler;
    [SerializeField]
    private UIAssistant uiAssistant;

        void Awake()
    {
        if(Levels.Length != 0 && uiAssistant != null){
        uiAssistant.messageArray = Levels[0].text;
        } else {
            Debug.LogWarning("Either the Levels array is empty or the UI assistant variable in LevelHandler is Empty. Fix this.");
        }
        if(mapHandler != null){
            mapHandler.setUpAnswer(Levels[0].places, Levels[0].coordinates );
        } else {
            Debug.LogWarning("MapHandler variable in LevelHandler is Empty. Fix this.");
        }
        if(Levels[0].characters != null){
            uiAssistant.npcSprites = Levels[0].characters;
        } else {
            Debug.LogWarning("Levels has an item without sprites. Fix this");
        }
    } 
}
