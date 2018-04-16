using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Noble", menuName = "Cards/Noble")]
public class Noble : ScriptableObject {

    [Header("Info")]
    public new string name;
    public int pointsReward;

    [Header("Cost")]
    public int ruby;
    public int sapphire;
    public int diamond;
    public int emerald;
    public int onyx;
}
