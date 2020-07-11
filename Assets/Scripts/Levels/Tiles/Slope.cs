using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slope : MonoBehaviour
{
    public bool facingRight = true;
    public int height;

    private void OnValidate() {
        GetComponent<SpriteRenderer>().flipX = !facingRight;
    }

    public int GetHeight() {
        return height;
    }
}
