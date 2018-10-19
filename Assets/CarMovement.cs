using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour {
    public GameObject carModel;
    private float rotationAmount;

    void Update()
    {
        // Rotate with input
        rotationAmount = InputManager.MainHorizontal() * 120.0f;
        rotationAmount *= Time.deltaTime;
        carModel.transform.Rotate(0.0f, rotationAmount, 0.0f);
    }
}
