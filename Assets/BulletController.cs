using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private BoundsCheck _bndCheck;

    //initilizes the bound check component 
    void Awake()
    {
        _bndCheck = GetComponent<BoundsCheck>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemies"))
        {
            Destroy(gameObject); //destroys bullet
            Destroy(other.gameObject); //destroys enemy
            //adds 2 points to the score when destroying an enemy with a gun 
            //ScoreScript.countValue += 2;

        }

        if (_bndCheck != null && (_bndCheck.offDown || _bndCheck.offRight || _bndCheck.offLeft)) // checks if enemy is out of bounds anywhere
        {
            Destroy(gameObject);//this destryos the gameobject
        }

    }
}

