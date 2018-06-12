using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardDisplay : MonoBehaviour, IPointerClickHandler {

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

    public Image gemRewardImage;
    public Text pointsRewardText;
    public GameObject gemCosts;

    [Header("Prefab of gem cost")]
    public GameObject gemCost;
    
    public void setValues(Card c) {
        this.tier = c.tier;
        this.name = c.name;
        this.gemReward = c.gemReward;
        this.pointsReward = c.pointsReward;

        this.ruby = c.ruby;
        this.sapphire = c.sapphire;
        this.diamond = c.diamond;
        this.emerald = c.emerald;
        this.onyx = c.onyx;

        SetCardData();
    }

    private void SetCardData() {
        switch (gemReward) {
            case "Red":
                gemRewardImage.GetComponent<Image>().color = new Color32(149, 17, 30, 255);
                break;
            case "Blue":
                gemRewardImage.GetComponent<Image>().color = new Color32(15, 82, 186, 255);
                break;
            case "Green":
                gemRewardImage.GetComponent<Image>().color = new Color32(80, 200, 120, 255);
                break;
            case "White":
                gemRewardImage.GetComponent<Image>().color = new Color32(185, 242, 255, 255);
                break;
            case "Black":
                gemRewardImage.GetComponent<Image>().color = Color.black;
                break;
        }
        if (pointsReward == 0)
            pointsRewardText.text = "";
        else
            pointsRewardText.text = pointsReward.ToString();

        if (ruby > 0) {
            GameObject temp = Instantiate(gemCost);

            temp.transform.SetParent(gemCosts.transform);
            temp.transform.GetChild(0).GetComponent<Text>().text = ruby.ToString();
            temp.GetComponent<Image>().color = new Color32(149, 17, 30, 255);
        }
        if (sapphire > 0) {
            GameObject temp = Instantiate(gemCost);

            temp.transform.SetParent(gemCosts.transform);
            temp.transform.GetChild(0).GetComponent<Text>().text = sapphire.ToString();
            temp.GetComponent<Image>().color = new Color32(15, 82, 186, 255);
        }
        if (diamond > 0) {
            GameObject temp = Instantiate(gemCost);

            temp.transform.SetParent(gemCosts.transform);
            temp.transform.GetChild(0).GetComponent<Text>().text = diamond.ToString();
            temp.GetComponent<Image>().color = new Color32(185, 242, 255, 255);
        }
        if (emerald > 0) {
            GameObject temp = Instantiate(gemCost);

            temp.transform.SetParent(gemCosts.transform);
            temp.transform.GetChild(0).GetComponent<Text>().text = emerald.ToString();
            temp.GetComponent<Image>().color = new Color32(80, 200, 120, 255);
        }
        if (onyx > 0) {
            GameObject temp = Instantiate(gemCost);

            temp.transform.SetParent(gemCosts.transform);
            temp.transform.GetChild(0).GetComponent<Text>().text = onyx.ToString();
            temp.GetComponent<Image>().color = Color.black;
        }
    }

    public void OnPointerClick(PointerEventData eventData) {
        CardManager.Instance.activateZoomCard(this);
    }
}
