using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MapHandler : MonoBehaviour
{

    //TODO: Use bools to weight the scores. Give a percentage on accuracy as well
    //TODO: Change the score display. Need to round to nearest whole number.
    //TODO: Account for extraneous locations on map that are incorrect even if other map stuff is correct.
    private Dictionary<Locations, Vector2> currMap = new Dictionary<Locations, Vector2>();
    private Dictionary<Locations, Vector2> answerMap = new Dictionary<Locations, Vector2>();

    [SerializeField]
    private TextMeshProUGUI currentText;
    [SerializeField]
    private TextMeshProUGUI score;


    void Awake(){

        //Only present for testing
        if(currentText != null){
            currentText.text += "This is also not shown to the user. \n";
            foreach(KeyValuePair<Locations, Vector2> entry in answerMap){
                currentText.text += $"The {entry.Key} is at {entry.Value.x}, {entry.Value.y}.\n";
            }
        }

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
                }
            } else {
                correctPlacesUsed = false;
                extraPlaces++;
            }
        }

    
    float scoreFinal = scoreCalculation(totalCorrect, extraPlaces, totalPlaces);
    //Test.Remove
    // Debug.Log($"total Correct: {totalCorrect}");
    // Debug.Log($"total Places: {totalPlaces}");
    // Debug.Log((totalCorrect/totalPlaces) * 100f);

    if(score!= null){
        score.text = $"Score: {scoreFinal}%";
    }


    }

    private float scoreCalculation(float totalCorrect, float extraPlaces, float totalPlaces){
        return Mathf.Ceil(((totalCorrect-extraPlaces)/totalPlaces) * 100f);
    }
}
