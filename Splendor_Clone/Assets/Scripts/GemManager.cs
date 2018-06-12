using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemManager : MonoBehaviour {

    [Header("Available gems")]
    [SerializeField] int rubyGems = 7;
    [SerializeField] int sapphireGems = 7;
    [SerializeField] int onyxGems = 7;
    [SerializeField] int diamondGems = 7;
    [SerializeField] int emeraldGems = 7;
    [SerializeField] int goldGems = 5;

    public Text rubyText;
    public Text sapphireText;
    public Text onyxText;
    public Text diamondText;
    public Text emeraldText;
    public Text goldText;

    public static GemManager Instance { get; set; }

    private void Start() {
        Instance = this;

        rubyText.text = rubyGems.ToString();
        sapphireText.text = sapphireGems.ToString();
        onyxText.text = onyxGems.ToString();
        diamondText.text = diamondGems.ToString();
        emeraldText.text = emeraldGems.ToString();
        goldText.text = goldGems.ToString();
    }

}
