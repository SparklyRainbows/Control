using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Sprite on;
    public Sprite off;
    public GameObject Device;

    private SpriteRenderer renderer;
    private bool isOn;

    private void Start() {
        renderer = GetComponent<SpriteRenderer>();
    }

    public void Toggle() {
        isOn = !isOn;
        renderer.sprite = isOn ? on : off;
        if (Device.CompareTag("MovingPlat"))
        {
            MovingPlatform Plat = Device.GetComponent<MovingPlatform>();
            Plat.setMoving(!Plat.getMoving());
            if (!Plat.getStarted())
            {
                Plat.setStarted(true);
                StartCoroutine(Plat.Move());
            }
        }
        else if (Device.CompareTag("ConveyorBelt"))
        {
            ConveyorBelt Conv = Device.GetComponent<ConveyorBelt>();
            if (Conv.getStoppable())
            {
                Conv.changeStop();
            }
            else
            {
                Conv.changeDirection();
                Debug.Log("Direction Changed");
            }
        }
    }
}
