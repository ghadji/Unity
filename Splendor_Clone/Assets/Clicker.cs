using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Clicker : MonoBehaviour, IPointerClickHandler {

    private void OnMouseDown() {
        Debug.Log("TEST");
    }

    private void OnMouseEnter() {
        Debug.Log("Enter");
    }

    public void OnPointerClick(PointerEventData eventData) {
        Debug.Log("Test");
    }
}
