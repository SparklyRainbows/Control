using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    private Transform target;

    private Camera cam;

    private void Awake() {
        cam = GetComponent<Camera>();
    }

    private void Update() {
        if (!target) {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null) {
                target = player.transform;
            }
        }

        if (target) {
            Vector3 point = cam.WorldToViewportPoint(target.position);
            Vector3 targetPos = target.position + new Vector3(0, 1, 0);
            Vector3 delta = targetPos - cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
    }
}
