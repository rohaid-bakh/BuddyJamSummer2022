using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Locations
{
    Museum,
    House,
    Park,
    Bridge,
    Pizzeria,
    AbandonedMansion,
    None
}


[CreateAssetMenu(menuName = "Location")]
public class Location: ScriptableObject
{
    public Locations type;
}

