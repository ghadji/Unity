using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public List<Card> cards = new List<Card>();
    public List<Noble> nobles = new List<Noble>();


    void LoadCards(TextAsset ta)
    {
        string[] data = ta.text.Split(new char[] { '\n' });
        for (int i = 1; i < data.Length - 1; i++)
        {
            string[] row = data[i].Split(new char[] { ',' });
            Card c = new Card();
            int.TryParse(row[0], out c.tier);
            c.name = row[1];
            c.gemReward = row[2];
            int.TryParse(row[3], out c.pointsReward);
            int.TryParse(row[4], out c.redCost);
            int.TryParse(row[5], out c.blueCost);
            int.TryParse(row[6], out c.whiteCost);
            int.TryParse(row[7], out c.greenCost);
            int.TryParse(row[8], out c.blackCost);
            cards.Add(c);
        }
    }

    void LoadNobles(TextAsset ta)
    {
        string[] data = ta.text.Split(new char[] { '\n' });
        for (int i = 1; i < data.Length - 1; i++)
        {
            string[] row = data[i].Split(new char[] { ',' });
            Noble n = new Noble();
            n.name = row[0];
            int.TryParse(row[1], out n.pointsReward);
            int.TryParse(row[2], out n.redCost);
            int.TryParse(row[3], out n.blueCost);
            int.TryParse(row[4], out n.whiteCost);
            int.TryParse(row[5], out n.greenCost);
            int.TryParse(row[6], out n.blackCost);
            nobles.Add(n);
        }
    }

    void Awake () {
        TextAsset t1_cards = Resources.Load<TextAsset>("Data/t1");
        LoadCards(t1_cards);

        TextAsset t2_cards = Resources.Load<TextAsset>("Data/t2");
        LoadCards(t2_cards);

        TextAsset t3_cards = Resources.Load<TextAsset>("Data/t3");
        LoadCards(t3_cards);

        TextAsset nobles = Resources.Load<TextAsset>("Data/nobles");
        LoadNobles(nobles);
    }
	

}
