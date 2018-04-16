using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Available gems")]
    [SerializeField] int rubyGems = 7;
    [SerializeField] int sapphireGems = 7;
    [SerializeField] int onyxGems = 7;
    [SerializeField] int diamondGems = 7;
    [SerializeField] int emeraldGems = 7;
    [SerializeField] int goldGems = 5;

    [Header("Available cards")]
    [SerializeField] List<Card> cards = new List<Card>();
    [SerializeField] int t1_counter = 0;
    [SerializeField] int t2_counter = 0;
    [SerializeField] int t3_counter = 0;
    [SerializeField] List<Noble> nobles = new List<Noble>();

    [Header("Card/Noble Prefabs")]
    [SerializeField] GameObject t1_go;
    [SerializeField] GameObject t2_go;
    [SerializeField] GameObject t3_go;
    [SerializeField] Image cardImg;
    [SerializeField] GameObject noble_go;
    [SerializeField] Image nobleImg;

    void Awake() {
        TextAsset t1_cards = Resources.Load<TextAsset>("Data/t1");
        LoadCards(t1_cards);

        TextAsset t2_cards = Resources.Load<TextAsset>("Data/t2");
        LoadCards(t2_cards);

        TextAsset t3_cards = Resources.Load<TextAsset>("Data/t3");
        LoadCards(t3_cards);

        TextAsset nobles = Resources.Load<TextAsset>("Data/nobles");
        LoadNobles(nobles);

        GenerateCards();
        GenerateNobles();
    }

    #region LOAD_DATA
    void LoadCards(TextAsset ta) {
        string[] data = ta.text.Split(new char[] { '\n' });
        for (int i = 1; i < data.Length - 1; i++) {
            string[] row = data[i].Split(new char[] { ',' });
            Card c = new Card();
            int.TryParse(row[0], out c.tier);
            if (c.tier == 1)
                t1_counter++;
            else if (c.tier == 2)
                t2_counter++;
            else
                t3_counter++;
            c.name = row[1];
            c.gemReward = row[2];
            int.TryParse(row[3], out c.pointsReward);
            int.TryParse(row[4], out c.ruby);
            int.TryParse(row[5], out c.sapphire);
            int.TryParse(row[6], out c.diamond);
            int.TryParse(row[7], out c.emerald);
            int.TryParse(row[8], out c.onyx);
            cards.Add(c);
        }
    }

    void LoadNobles(TextAsset ta) {
        string[] data = ta.text.Split(new char[] { '\n' });
        for (int i = 1; i < data.Length - 1; i++) {
            string[] row = data[i].Split(new char[] { ',' });
            Noble n = new Noble();
            n.name = row[0];
            int.TryParse(row[1], out n.pointsReward);
            int.TryParse(row[2], out n.ruby);
            int.TryParse(row[3], out n.sapphire);
            int.TryParse(row[4], out n.diamond);
            int.TryParse(row[5], out n.emerald);
            int.TryParse(row[6], out n.onyx);
            nobles.Add(n);
        }
    }
    #endregion

    #region GENERATE_CARDS
    void GenerateCards() {

    }

    void GenerateNobles() {

    }
    #endregion


}
