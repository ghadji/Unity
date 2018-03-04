using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/Card")]
public class Card : ScriptableObject {

    [Header("Points")]
    public int points;

    [Header("Cost")]
    public int whiteGemCost;
    public int redGemCost;
    public int greenGemCost;
    public int blueGemCost;
    public int blackGemCost;


}
