using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FowardHitRaycast : MonoBehaviour {

    public Transform carTr;
    public Rigidbody carRb;
    public float meters = 0.5f;

    void Update()
    {
        RaycastHit hit;
        float distance;

        Vector3 direction = transform.TransformDirection(Vector3.forward) * meters; // 0.5 meters

        if (Physics.Raycast(transform.position, direction, out hit))
        {
            distance = hit.distance;

            if (distance <= 1) {
                carTr.Rotate(new Vector3(-2, 0, 0));

                //string info = string.Format(
                //    "Distance: {0:0.00} " +
                //    "- Name: {1} " +
                //    "- Pos Y coll: {2}",
                //    distance,
                //    hit.collider.gameObject.name,
                //    hit.collider.gameObject.transform.position.y
                //    );
                //Debug.Log(info);
            }
        }
    }
}
