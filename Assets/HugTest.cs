using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugTest : MonoBehaviour {
    public GameObject carModel;
    public Transform raycastPoint;
    private float hoverHeight = 0.4f;
    private float speed = 20.0f;
    private float terrainHeight;
    private float rotationAmount;
    private RaycastHit hit;
    private Vector3 pos;
    private Vector3 forwardDirection;
    public Rigidbody carRb;
    private float globalDistancePoint;
    private float currentDistance;

    void Update()
    {
        // Keep at specific height above terrain
        // Solution 1: Using the height of the terrain + hoverHeight. 
        // Problem: Only works in terrain object
                //pos = transform.position;
                //float terrainHeight = Terrain.activeTerrain.SampleHeight(pos);
                //transform.position = new Vector3(pos.x,
                //                                 //terrainHeight + 
                //                                 pos.y + hoverHeight,
                //                                 pos.z);

        // Solution 2: Using raycast to constatly observe a distance between a transform and a hit point
        Physics.Raycast(raycastPoint.position, -transform.up, out hit);
        
        float posHitY = hit.point.y;
        globalDistancePoint = transform.position.y - posHitY;
        currentDistance = hit.distance;

        Vector3 transformUp = transform.up;

        var errorHeight = hoverHeight - currentDistance;

        if (errorHeight > 0.07f || errorHeight < -0.07f)
        {
            //var p = transform.position;
            //p.y = posHitY + hoverHeight;
            //transform.position = p;

            //transformUp.y = posHitY + hoverHeight;
            //var p = transform.up;
            //p.y = hoverHeight;
            //transform.up = p;

            //transform.Translate(Vector3.up * Time.deltaTime, Space.World);

            //if(globalDistancePoint < hoverHeight)
            //{
            //    var d = hoverHeight - globalDistancePoint;
            //    transform.Translate(new Vector3(0,d,0), Space.World);
            //}
            //else
            //{
            //    var d = globalDistancePoint - hoverHeight;
            //    transform.Translate(new Vector3(0, -d, 0), Space.World);
            //}

            //if (globalDistancePoint > hoverHeight + 0.2f || globalDistancePoint < hoverHeight - 0.2f) {
            //    var c = transformUp;
            //    c.y = c.y != 0 ? (c.y < 0 ? -0.1f : 0.1f) : 0;
            //    c.z = c.z != 0 ? (c.z < 0 ? -0.1f : 0.1f) : 0;

            //    if (globalDistancePoint > hoverHeight) c *= -1;

            //    transform.Translate(c);
            //}

            transform.Translate((errorHeight > 0 ? Vector3.up : Vector3.down) * 0.01f);
        }


        // Rotate to align with terrain
        transform.up -= (transformUp - hit.normal) * 0.1f;
        //transform.up += hit.normal * 0.1f;

        // Rotate with input
        rotationAmount = (Input.GetAxis("Horizontal") * 120.0f) * Time.deltaTime;
        carModel.transform.Rotate(0.0f, rotationAmount, 0.0f);

        // Move forward
        forwardDirection = carModel.transform.forward;
        transform.position += forwardDirection * Time.deltaTime * InputManager.MainVertical() * 2.5f;
        //Vector3 verticalDir = carModel.transform.forward * InputManager.MainVertical() * 2;
        //carRb.AddForce(verticalDir);

        // visualModelTr.transform.position = transform.position;
        //visualModelTr.transform.rotation = new Quaternion(transform.rotation.x,
        //                                                    visualModelTr.transform.rotation.y,
        //                                                    transform.rotation.z, transform.rotation.w);
        //visualModelTr.transform.Rotate(0, rotationAmount, 0.0f);

        // Debug
        string info = string.Format(
                "hit Point: {0} " +
                "|| GlobalDistanceP: {1:0.00} " +
                "|| Normal: {2} " +
                "|| TramsfUp: {3} " + 
                "|| ErrHeight: {4}" + 
                "|| Ray Origin: {5}" + 
                "|| OriginVShitPos: {6}"+
                "|| Distance: {7:0.00}",
                "("+ System.Math.Round(hit.point.x, 2) + ", " + System.Math.Round(hit.point.y,2) + ", " + System.Math.Round(hit.point.z, 2)+")",
                globalDistancePoint,
                hit.normal,
                transform.up,
                errorHeight,
                raycastPoint.position,
                raycastPoint.position - hit.point,
                currentDistance
                );
        Debug.Log(info);
    }

    private void OnDrawGizmosSelected()
    {
        Debug.DrawLine(raycastPoint.position, raycastPoint.position + -transform.up * currentDistance, Color.yellow);
    }
}
