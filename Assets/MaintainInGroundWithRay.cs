using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaintainInGroundWithRay : MonoBehaviour {

    public Transform carTr;
    public Rigidbody carRb;
    public float meters = 0.5f;
    private float baseCarDistance = 0.4f;

    void Update () {
        RaycastHit hit;
        float distance;
        float globalDistancePoint;

        Vector3 direction = transform.TransformDirection(Vector3.down) * meters; // 0.5 meters

        if (Physics.Raycast(transform.position, direction, out hit))
        {
            distance = hit.distance;
            float posHitY = hit.point.y;
            globalDistancePoint = carTr.position.y - posHitY;

            if (globalDistancePoint != baseCarDistance)
            {
                var p = carTr.position;
                p.y = posHitY + baseCarDistance;
                carTr.position = p;
            }
            

            string info = string.Format(
                "Distance: {0:0.00} " +
                "|| Name: {1} " +
                "|| Pos Y coll: {2} " +
                "|| hit Point: {3} " + 
                "|| Global distance Point: {4} " +
                "|| Normal: {5} ",
                distance,
                hit.collider.gameObject.name,
                hit.collider.gameObject.transform.position.y,
                hit.point,
                globalDistancePoint,
                transform.up - hit.normal
                );
            Debug.Log(info);
        }

        //carTr.up -= (transform.up - hit.normal) * 0.1f;
    }
}
