using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMechanics : MonoBehaviour {

    public float jumpForce = 1000f;
    public float boostForce = 200f;

    public Rigidbody carRb;
    public Transform carTr;

    public static bool flying;
    private static int availableJumps = 2;
    private double currentSpeed;
    private double carSpeed;
    public float aceleration;
    public float rotationSpeed = 50f;

	// Use this for initialization
	void Start () {
        carRb = GetComponent<Rigidbody>();
        carTr = GetComponent<Transform>();

        currentSpeed = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = InputManager.MainHorizontal();
        float moveVertical = InputManager.MainVertical();

        currentSpeed = carRb.velocity.magnitude * 3.6;

        if (!flying) availableJumps = 2;

        // Jump
        if (InputManager.XButton() && availableJumps > 1)
        {
            carRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            availableJumps--;
        }

        // Boost
        //if (InputManager.AButton())
        //{
        //    carRb.AddForce(carRb.transform.forward * boostForce, ForceMode.Impulse);
        //}

        // jump in air
        if (flying)
        {
            carTr.Rotate(InputManager.MainVerticalMovement() * 5, moveHorizontal * 3, 0);
        }

        Move(moveVertical, moveHorizontal);
    }

    void Move(float movVertical, float movHorizontal)
    {
        float climbSpeed = carTr.position.y > 0.30f ? 1.2f : 1;
        Vector3 verticalDir = transform.forward * movVertical * aceleration * climbSpeed;
        carRb.AddForce(verticalDir);

        transform.Rotate(new Vector3(0, movHorizontal, 0) * Time.deltaTime * rotationSpeed, Space.World);
    }

    private void OnGUI()
    {
        var speed = string.Format("Speed: {0:0.00} Km/s", currentSpeed);
        GUI.Label(new Rect(10f, 10f, 200f, 150f), speed);
    }
}
