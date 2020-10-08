using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    static public Ship S; //declares a singleton

    //these control the movement of the ship
    public float speed = 30;
    public float rollMult = -25;
    public float pitchMult = 10;

    private GameObject _lastTrigger = null;

    void Awake()
    {
        if(S == null)
        {
            S = this;//sets the singleton
        } else
        {
            Debug.LogError("Hero.Awake() - Attempted to assign second Hero.S");
        }
    }

    // this method moves the ship
    void Update()
    {
        //obtain information from the Input class
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        //changes the x and y coordinates of the ship to move it 
        Vector3 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        pos.y += yAxis * speed * Time.deltaTime;
        transform.position = pos;

        //implements a slight rotation of the ship
        transform.rotation = Quaternion.Euler(yAxis * pitchMult, xAxis * rollMult, 0);

    }

    //this method destorys ship and enemy upon collision
    void OnTriggerEnter(Collider other)
    {


        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;

        if (go == _lastTrigger) 
        {
            return;
        }

        if(go.tag == "Enemies")
        {
            Destroy(go); //destroys enemy
            Destroy(this.gameObject); //destorys ship
        }

    }
}
