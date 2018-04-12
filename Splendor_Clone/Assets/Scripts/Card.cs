using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/Card")]
public class Card : ScriptableObject {

    [Header("Info")]
    public int tier;
    public new string name;
    public string gemReward;
    public int pointsReward;

    [Header("Cost")]
    public int redCost;
    public int blueCost;
    public int whiteCost;
    public int greenCost;
    public int blackCost;
}
