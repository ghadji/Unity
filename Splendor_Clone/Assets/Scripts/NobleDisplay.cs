using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NobleDisplay : MonoBehaviour, IPointerClickHandler {

    [Header("Info")]
    public int tier;
    public new string name;
    public int pointsReward;

    [Header("Card Cost")]
    public int ruby;
    public int sapphire;
    public int diamond;
    public int emerald;
    public int onyx;
    
    public Text pointsRewardText;
    public GameObject cardsCosts;

    [Header("Prefab of gem cost")]
    public GameObject cardCost;
    
    public void setValues(Noble n) {
        this.name = n.name;
        this.pointsReward = n.pointsReward;

        this.ruby = n.ruby;
        this.sapphire = n.sapphire;
        this.diamond = n.diamond;
        this.emerald = n.emerald;
        this.onyx = n.onyx;

        SetNobleData();
    }

    private void SetNobleData() {
        if (pointsReward == 0)
            pointsRewardText.text = "";
        else
            pointsRewardText.text = pointsReward.ToString();

        if (ruby > 0) {
            GameObject temp = Instantiate(cardCost);

            temp.transform.SetParent(cardsCosts.transform);
            temp.transform.GetChild(0).GetComponent<Text>().text = ruby.ToString();
            temp.GetComponent<Image>().color = new Color32(149, 17, 30, 255);
        }
        if (sapphire > 0) {
            GameObject temp = Instantiate(cardCost);

            temp.transform.SetParent(cardsCosts.transform);
            temp.transform.GetChild(0).GetComponent<Text>().text = sapphire.ToString();
            temp.GetComponent<Image>().color = new Color32(15, 82, 186, 255);
        }
        if (diamond > 0) {
            GameObject temp = Instantiate(cardCost);

            temp.transform.SetParent(cardsCosts.transform);
            temp.transform.GetChild(0).GetComponent<Text>().text = diamond.ToString();
            temp.GetComponent<Image>().color = new Color32(185, 242, 255, 255);
        }
        if (emerald > 0) {
            GameObject temp = Instantiate(cardCost);

            temp.transform.SetParent(cardsCosts.transform);
            temp.transform.GetChild(0).GetComponent<Text>().text = emerald.ToString();
            temp.GetComponent<Image>().color = new Color32(80, 200, 120, 255);
        }
        if (onyx > 0) {
            GameObject temp = Instantiate(cardCost);

            temp.transform.SetParent(cardsCosts.transform);
            temp.transform.GetChild(0).GetComponent<Text>().text = onyx.ToString();
            temp.GetComponent<Image>().color = Color.black;
        }
    }

    public void OnPointerClick(PointerEventData eventData) {
        CardManager.Instance.activateZoomNoble(this);
    }
}
