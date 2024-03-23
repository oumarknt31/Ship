using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScreenUtils
{

    //#region Fields

    // Saved to support resolution resolution
    static int screenWidth;
    static int screenHeight;

    // Cacched for efficient boundary
    static float screenLeft;
    static float screenRight;
    static float screenTop;
    static float screenBottom;

    // Properties
    public static float ScreenLeft { get { return screenLeft; } }
    public static float ScreenRight { get { return screenRight; } }
    public static float ScreenTop { get { return screenTop; } }
    public static float ScreenBottom { get { return screenBottom; } }

    // Method
    public static void Initialize()
    {
        float screenZ = -Camera.main.transform.position.z;
        Vector3 lowerLetfCornerScreen = new Vector3(0, 0, screenZ);
        Vector3 lowerLeftCornerWorld = Camera.main.ScreenToWorldPoint(lowerLetfCornerScreen);
        Vector3 topRightCornerScreen = new Vector3(Screen.width, Screen.height, screenZ);
        Vector3 topRightCornerWorld = Camera.main.ScreenToWorldPoint(topRightCornerScreen);

        screenLeft = lowerLeftCornerWorld.x;
        screenRight = topRightCornerWorld.x;
        screenTop = topRightCornerWorld.y;
        screenBottom = lowerLeftCornerWorld.y;

    }

    /*public static void KeepInScreen( float colliderHalfWidth, float colliderHalfHeight)
    {
        Vector3 position = transform.position;

        if (position.x - colliderHalfWidth < screenLeft)
        {
            position.x = screenLeft + colliderHalfWidth;
        }

        if (position.x + colliderHalfWidth > screenRight)
        {
            position.x = screenRight - colliderHalfWidth;
        }

        if (position.y - colliderHalfHeight < screenBottom)
        {
            position.y = screenBottom + colliderHalfHeight;
        }

        if (position.y + colliderHalfHeight > screenTop)
        {
            position.y = screenTop - colliderHalfHeight;
        }

        transform.position = position;
    }*/
}