using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MapHandler : MonoBehaviour
{

    //TODO: Use bools to weight the scores. Give a percentage on accuracy as well
    //TODO: Change the score display. Need to round to nearest whole number. // done
    //TODO: Account for extraneous locations on map that are incorrect even if other map stuff is correct. // done

    //TODO:: Automatically give a "Hmm You're missing something" if theres too many things on the map 
    private Dictionary<Locations, Vector2> currMap = new Dictionary<Locations, Vector2>();
    private Dictionary<Locations, Vector2> answerMap = new Dictionary<Locations, Vector2>();

    [SerializeField]
    private TextMeshProUGUI currentText;
    [SerializeField]
    private TextMeshProUGUI score;
    private LevelHandler levelHandler;


    void Awake(){
        levelHandler = FindObjectOfType<LevelHandler>();

    }

//used by LevelHandler to set up the answerkey for checking
    public void setUpAnswer(Locations[] locations, Vector2[] coordinates){
        if(locations.Length != coordinates.Length){
            Debug.LogWarning("There's an uneven amount of locations to coordinates. Please fix this");
            return;
        }
        if(locations.Length == 0 || coordinates.Length == 0){
            Debug.LogWarning("Either the locations array or coordinates array in the answer key is empty. Please fix this");
            return;
        }
        for(int i = 0 ; i < locations.Length; i++){
            answerMap.Add(locations[i], coordinates[i]);
        }
    }

    public void resetMap(){
        answerMap.Clear();
        currMap.Clear(); 
        DragNDrop[] items = FindObjectsOfType<DragNDrop>();
        for(int i = 0 ; i < items.Length ; i++){
            items[i].resetIcons();
        }
    }
    public void addLocation(Locations place, Vector2 spot){
        //done so that there's not multiple entries of the same place with different coordinates
        if(currMap.ContainsKey(place)){
            deleteLocation(place);
        }
        currMap.Add(place, spot);
    }

    public void deleteLocation(Locations place){
        currMap.Remove(place);
    }

    public void checkFinal(){
        float totalPlaces = answerMap.Count;
        bool correctNumPlaces = false;
        bool correctPlacesUsed = true; // should probably remove this
        //need to account for when someone putts locations that aren't used on the map and there's a bunch of correct things
        float totalCorrect = 0;
        float extraPlaces = 0;

        if (currMap.Count == answerMap.Count){
            correctNumPlaces = true;
        }

        foreach (KeyValuePair<Locations, Vector2> entry in currMap){
            if(answerMap.ContainsKey(entry.Key)){
                Vector2 answer = answerMap[entry.Key];
                if (answer.x == entry.Value.x && answer.y == entry.Value.y){
                    totalCorrect++;
                    //need to write a function that checks the position around the placed icon
                }else if ((answer.x + 1 == entry.Value.x || answer.x - 1 == entry.Value.x) ||
                 (answer.y + 1 == entry.Value.y || answer.y - 1 == entry.Value.y)){
                    totalCorrect += 2f/3f; 
                }
            } else {
                correctPlacesUsed = false;
                extraPlaces++;
            }
        }

    
    float scoreFinal = scoreCalculation(totalCorrect, extraPlaces, totalPlaces);
  
    if(score!= null){
        if(scoreFinal <= 60f){
            score.text = "Hmmm. Maybe try again!";
        } else if (scoreFinal < 80f && scoreFinal > 60f){
            score.text = "Yeah this is close enough, good job!";
            levelHandler.loadLevel();
        } else if (scoreFinal >= 80f){
            score.text = "Superb, it's almost like you live here!";
            levelHandler.loadLevel();
        }
        
    }


    }

    private float scoreCalculation(float totalCorrect, float extraPlaces, float totalPlaces){
        float correctCount = (totalCorrect - extraPlaces) > 0 ? (totalCorrect - extraPlaces) : 0;
        return Mathf.Ceil(((correctCount)/totalPlaces) * 100f);
    }

    private void debugCorrect(Locations place , Vector2 Coordinate, string truth){
        //
        if(debugText!= null)
        {
            debugText.text += $"Currently {place} is at {Coordinate}. This is {truth}. ";
        }
        //if this shows up, the merge went through
    }
}
