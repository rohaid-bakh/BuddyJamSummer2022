using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Level")]
public class Level : ScriptableObject
{
    public Sprite[] characters;
    [TextArea(6,6)]
    //added because Unity 2021 LTS problem with showing index 0 TextArea arrays :/
    [NonReorderable]
    public string[] text;

    //The item at index A in places must have the correct position stored in index A in coordinates
    [Header("Answer Key")]
    [Tooltip("The item at index A in places must have the correct position stored in index A in coordinates")]
    public Locations[] places;
    public Vector2[] coordinates;

    public Sprite map;
    
    
}