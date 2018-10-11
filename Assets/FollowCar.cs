using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCar : MonoBehaviour {

    public Transform tCar;

    public Vector3 offset;

	// Update is called once per frame
	void Update () {
        //var tCarx = tCar.position.x;
        //tCarx += 16.23f;
        //var tCarx = tCar.position.x;
        //tCarx += 16.23f;

        transform.position = tCar.position + offset;
	}
}
