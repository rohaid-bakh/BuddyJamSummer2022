using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MapHandler : MonoBehaviour
{

    //TODO: Use bools to weight the scores. Give a percentage on accuracy as well
    private Dictionary<Locations, int[]> currMap = new Dictionary<Locations, int[]>();
    private Dictionary<Locations, int[]> answerMap = new Dictionary<Locations, int[]>();

    [SerializeField]
    private TextMeshProUGUI currentText;
    [SerializeField]
    private TextMeshProUGUI score;


    void Awake(){
        //this is for testing purposes only
        //Will be replaced with setting answerMap to the Map needing to be solved
        answerMap.Add(Locations.AbandonedMansion, new int[]{0,1});
        answerMap.Add(Locations.Pizzeria , new int[]{3,1});
        answerMap.Add(Locations.Museum, new int[]{-2,1});

        if(currentText != null){
            currentText.text += "This is also not shown to the user. \n";
            foreach(KeyValuePair<Locations, int[]> entry in answerMap){
                currentText.text += $"The {entry.Key} is at {entry.Value[0]}, {entry.Value[1]}.\n";
            }
        }

    }
    public void addLocation(Locations place, int[] spot){
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

        if (currMap.Count == answerMap.Count){
            correctNumPlaces = true;
        }

        foreach (KeyValuePair<Locations, int[]> entry in currMap){
            if(answerMap.ContainsKey(entry.Key)){
                int[] answer = answerMap[entry.Key];
                if (answer[0] == entry.Value[0] && answer[1] == entry.Value[1]){
                    totalCorrect++;
                }
            } else {
                correctPlacesUsed = false;
            }
        }

    //Test.Remove
    Debug.Log($"total Correct: {totalCorrect}");
    Debug.Log($"total Places: {totalPlaces}");
    Debug.Log((totalCorrect/totalPlaces) * 100);


    if(score!= null){
        score.text = $"Score: {(totalCorrect/totalPlaces) * 100}%";
    }


    }
}
