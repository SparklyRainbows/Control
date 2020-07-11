using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Sprite on;
    public Sprite off;

    private SpriteRenderer renderer;
    private bool isOn;

    private void Start() {
        renderer = GetComponent<SpriteRenderer>();
    }

    public void Toggle() {
        isOn = !isOn;
        renderer.sprite = isOn ? on : off;
    }
}
