using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager {

    #region axes
    public static float MainHorizontal()
    {
        float r = 0.0f;
        r += Input.GetAxis("J_MainHorizontal");
        r += Input.GetAxis("K_MainHorizontal");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static float MainVertical()
    {
        float r = 0.0f;
        r += Input.GetAxis("JT_MainVertical");
        r += Input.GetAxis("K_MainVertical");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static float MainVerticalMovement()
    {
        float r = 0.0f;
        r += Input.GetAxis("J_MainVertical");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    #endregion

    #region buttons

    public static bool AButton()
    {
        return Input.GetButton("A_Button");
    }

    public static bool BButton()
    {
        return Input.GetButtonDown("B_Button");
    }

    public static bool XButton()
    {
        return Input.GetButtonDown("X_Button");
    }

    public static bool YButton()
    {
        return Input.GetButtonDown("Y_Button");
    }

    #endregion
}
