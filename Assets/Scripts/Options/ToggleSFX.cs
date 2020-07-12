using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToggleSFX : MonoBehaviour, IPointerClickHandler {

    private int index = 0;
    public Sprite[] images;

    public void OnPointerClick(PointerEventData eventData) {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("Click");
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().ToggleSfx();

        index = index == 0 ? 1 : 0;
        GetComponent<Image>().sprite = images[index];
    }
}
