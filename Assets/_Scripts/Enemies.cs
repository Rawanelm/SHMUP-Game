using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{

    public float speed = 10f;
    private BoundsCheck _bndCheck;

    //initilizes the bound check component 
    void Awake()
    {
        _bndCheck = GetComponent<BoundsCheck>();
    }
    
    //this method gets the current position of the enemy
    public Vector3 pos
    {
        get { 
            return (this.transform.position); 
        }

        set{

            this.transform.position = value;
        }
    }

    //this method movesthe enemy and destroys it when it goes out of bounds
    void Update()
    {
        Move(); // call the move method

        if(_bndCheck != null && (_bndCheck.offDown|| _bndCheck.offRight || _bndCheck.offLeft)) // checks if enemy is out of bounds anywhere
        {
                Destroy(gameObject);//this destryos the gameobject
        }
    }

    // thsi method moves the enemy and it is inheritable 
    public virtual void Move()
    {
        Vector3 tempPos = pos; // sets a new temporary position
        tempPos.y -= speed * Time.deltaTime; //changes  y the value to allow the enemy to move straight down
        pos = tempPos;// sets the new position after it has been moved
    }
}
