using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slope : MonoBehaviour
{
    public bool facingRight = true;
    public int height;

    private void OnValidate() {
        Quaternion n = new Quaternion(0, facingRight ? 0 : 180, 0, 0);
        transform.rotation = n;
    }

    public int GetHeight() {
        return height;
    }
}
