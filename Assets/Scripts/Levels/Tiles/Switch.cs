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
    [SerializeField]
    [Tooltip("0:red 1:green 2:purple 3:blue 4:yellow 5:orange")]
    private int color = 0;

    private void Start() {
        renderer = this.gameObject.GetComponent<SpriteRenderer>();
        renderer.sprite = sprites[color * 2];
        
    }

    public void Toggle() {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("Switch");

        isOn = !isOn;

        index = index == 0 ? 1 : 0;
        renderer.sprite = sprites[color *2  + index];

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
