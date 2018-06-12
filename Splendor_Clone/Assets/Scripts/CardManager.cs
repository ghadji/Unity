using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CardManager : MonoBehaviour {
    List<List<Card>> tiers = new List<List<Card>>();
    [Header("Cards")]
    [SerializeField] int t1_counter = 0;
    [SerializeField] int t2_counter = 0;
    [SerializeField] int t3_counter = 0;
    [SerializeField] GameObject card_prefab;
    [SerializeField] List<GameObject> tiers_go = new List<GameObject>();
    [SerializeField] Image cardImg;

    [Header("Nobles")]
    [SerializeField] GameObject noble_go;
    [SerializeField] List<Noble> nobles = new List<Noble>();
    [SerializeField] GameObject noble_prefab;
    [SerializeField] Image nobleImg;

    public static CardManager Instance { get; set; }

    private void Start() {
        Instance = this;
    }

    void Awake() {
        for (int i = 0; i < 3; i++) {
            tiers.Add(new List<Card>());
        }

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
            Card c = ScriptableObject.CreateInstance(typeof(Card)) as Card;
            int.TryParse(row[0], out c.tier);
            c.name = row[1];
            c.gemReward = row[2];
            int.TryParse(row[3], out c.pointsReward);
            int.TryParse(row[4], out c.ruby);
            int.TryParse(row[5], out c.sapphire);
            int.TryParse(row[6], out c.diamond);
            int.TryParse(row[7], out c.emerald);
            int.TryParse(row[8], out c.onyx);
            if (c.tier == 1) {
                tiers[0].Add(c);
                t1_counter++;
            } else if (c.tier == 2) {
                tiers[1].Add(c);
                t2_counter++;
            } else {
                tiers[2].Add(c);
                t3_counter++;
            }
        }
    }

    void LoadNobles(TextAsset ta) {
        string[] data = ta.text.Split(new char[] { '\n' });
        for (int i = 1; i < data.Length - 1; i++) {
            string[] row = data[i].Split(new char[] { ',' });
            Noble n = ScriptableObject.CreateInstance(typeof(Noble)) as Noble;
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
        int counter = 0;
        foreach (List<Card> t in tiers) {
            foreach (Transform card in tiers_go[counter].transform) {
                if (card.name.CompareTo("Stack") == 0) {
                    break;
                }
                GameObject c_temp = Instantiate(card_prefab) as GameObject;
                c_temp.transform.SetParent(card);
                c_temp.transform.position = c_temp.transform.parent.position;

                Card r = t[Random.Range(0, t.Count)];
                c_temp.GetComponent<CardDisplay>().setValues(r);

                t.Remove(r);
            }
            counter++;
        }
    }

    void GenerateNobles() {
        for (int i = 0; i < 5; i++) {
            GameObject n_temp = Instantiate(noble_prefab) as GameObject;
            n_temp.transform.SetParent(noble_go.transform.GetChild(i).transform);
            n_temp.transform.position = n_temp.transform.parent.position;

            Noble n = nobles[Random.Range(0, nobles.Count)];
            n_temp.GetComponent<NobleDisplay>().setValues(n);

            nobles.Remove(n);
        }
    }
    #endregion

    public void activateZoomCard(CardDisplay card) {
        ZoomCardManager.Instance.displayZoomCard(card);
    }

    public void activateZoomNoble(NobleDisplay noble) {
        ZoomCardManager.Instance.displayZoomNoble(noble);
    }
}
