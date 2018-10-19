using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastDrawer : MonoBehaviour {

    public enum PositionRay
    {
        down,
        up,
        left,
        right,
        forward,
        back
    }

    public Color rayColor = Color.black;
    public PositionRay raycastPosition;
    public float meters = 0.5f;

    public bool UsarTransformDown;
    public bool UsarTransformUp;

    void Update () {
        Vector3 dir = Vector3.up;

        switch (raycastPosition) {
            case PositionRay.down:
                dir = Vector3.down;
                break;
            case PositionRay.up:
                dir = Vector3.up;
                break;
            case PositionRay.left:
                dir = Vector3.left;
                break;
            case PositionRay.right:
                dir = Vector3.down;
                break;
            case PositionRay.back:
                dir = Vector3.back;
                break;
            case PositionRay.forward:
                dir = Vector3.forward;
                break;
        }

        if(UsarTransformDown) dir = -transform.up;
        if (UsarTransformUp) dir = Vector3.up;

        Vector3 direction = transform.TransformDirection(dir) * meters; // 0.5 meters
        Debug.DrawRay(transform.position, direction, rayColor);
	}
}
