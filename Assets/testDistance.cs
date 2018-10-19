using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testDistance : MonoBehaviour {

    public float Y = 1;
    public float Z = 1;

    private bool modificar = true;

    public Transform Transform;

    // Update is called once per frame
    void Update () {
        if (Y != 3 && modificar)
        {
            //var p = transform.position;
            //p.y = Y;
            //p.z = Z != 3 ? Z : p.z;
            //transform.position = p;


            //var tup = transform.up;
            //var tp = transform.position;

            //tup = tp;
            //tup.y = tp.y + (tup.y * Y);
            //tup.z = tp.z + (tup.z * Z);

            //transform.position = tup;

            //Debug.Log(tp);

            //modificar = false;
        }
    }
}
