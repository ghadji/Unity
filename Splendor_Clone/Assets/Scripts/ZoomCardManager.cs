using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCardManager : MonoBehaviour {

    public GameObject zoomCardOverlay;
    public GameObject zoomNobleOverlay;
    public ZoomCard zoomCard;
    public ZoomNoble zoomNoble;

    public static ZoomCardManager Instance { get; set; }

    private void Start() {
        Instance = this;
    }

    public void displayZoomCard(CardDisplay c) {
        zoomCard.setValues(c);
        zoomCardOverlay.SetActive(true);
    }

    public void displayZoomNoble(NobleDisplay n) {
        zoomNoble.setValues(n);
        zoomNobleOverlay.SetActive(true);
    }

    public void hideCard() {
        zoomCardOverlay.SetActive(false);
        zoomCard.clearValues();
    }

    public void hideNoble() {
        zoomNobleOverlay.SetActive(false);
        zoomNoble.clearValues();
    }
}
