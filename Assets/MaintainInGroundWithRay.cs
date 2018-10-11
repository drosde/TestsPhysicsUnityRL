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
        float distanceGlobalPoin;

        Vector3 direction = transform.TransformDirection(Vector3.down) * meters; // 0.5 meters

        if (Physics.Raycast(transform.position, direction, out hit))
        {
            distance = hit.distance;
            distanceGlobalPoin = carTr.position.y - hit.point.y;

            //if (distance > baseRayDistance)
            //{
            //    var p = carTr.position;
            //    p.y -= hit.point.y + baseCarDistance;
            //    carTr.position = p;
            //}

            string info = string.Format(
                "Distance: {0:0.00} " +
                "- Name: {1} " +
                "- Pos Y coll: {2}" +
                "- Vector 3 hit: {3}",
                distance,
                hit.collider.gameObject.name,
                hit.collider.gameObject.transform.position.y,
                hit.point
                );
            Debug.Log(info);
        }
    }
}
