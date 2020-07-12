using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    private int index;
    public Sprite[] sprites;

    public GameObject[] Devices;

    private SpriteRenderer renderer;
    private bool isOn;

    private void Start() {
        renderer = GetComponent<SpriteRenderer>();
    }

    public void Toggle() {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("Switch");

        isOn = !isOn;

        index = index == 0 ? 1 : 0;
        renderer.sprite = sprites[index];

        foreach (GameObject Device in Devices)
        {
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
}
