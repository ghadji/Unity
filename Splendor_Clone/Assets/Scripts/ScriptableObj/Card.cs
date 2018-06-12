using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/Card")]
public class Card : ScriptableObject {

    [Header("Info")]
    public int tier;
    public new string name;
    public string gemReward;
    public int pointsReward;

    [Header("Cost")]
    public int ruby;
    public int sapphire;
    public int diamond;
    public int emerald;
    public int onyx;
}
