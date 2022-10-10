using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Locations
{
    NedNoodle,
    BeesKnees,
    PostOffice,
    TownHall,
    Hospital,
    GrasshopperStadium,
    BearClaw,
    Arcade,
    HornetsNest,
    FoxsDen,
    None
}


[CreateAssetMenu(menuName = "Location")]
public class Location: ScriptableObject
{
    public Locations type;
}

