using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck : MonoBehaviour
{

    public float radius = 1f;

    public float camWidth;
    public float camHeight;

    public bool keepOnScreen = true;
    public bool isOnScreen = true;
    public bool offRight, offLeft, offUp, offDown;

    // thsi method sets the camera height and width to be used for the borders
    void Awake() {

        camHeight = Camera.main.orthographicSize; //obtain value from main Camera
        camWidth = camHeight * Camera.main.aspect;
       }

    //this makes sure that object are within bounds
    void LateUpdate() {

        Vector3 pos = transform.position;
        isOnScreen = true;
        offRight = offLeft = offUp = offDown = false;
        
        // these if statements check if the object is off the screen and makes sure its stay on screen
        if (pos.x > camWidth - radius)
        {
            pos.x = camWidth - radius;
            isOnScreen = false;
            offRight = true;
        }

        if (pos.x < -camWidth + radius)
        {
            pos.x = -camWidth + radius;
            isOnScreen = false;
            offLeft = true;
        }

        if (pos.y > camHeight - radius)
        {
            pos.y = camHeight - radius;
            isOnScreen = false;
            offUp = true;
        }

        if (pos.y < -camHeight + radius)
        {
            pos.y = -camHeight + radius;
            isOnScreen = false;
            offDown = true;
        }

        isOnScreen = !(offRight || offLeft || offUp || offDown); //sets value of isOnScreen depending on whether the object left the bounds
        
        if (keepOnScreen && !isOnScreen)
        {
            transform.position = pos;
            isOnScreen = true;
            offRight = offLeft = offUp = offDown = false;
        }
    }

    // this draws the game borders 
    void OnDrawGizmos() {
        
        if (!Application.isPlaying) return; 
        Vector3 boundSize = new Vector3(camWidth * 2, camHeight * 2, 0.1f);
        Gizmos.DrawWireCube(Vector3.zero, boundSize); 
    }
}
