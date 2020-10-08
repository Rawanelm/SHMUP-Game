using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : Enemies // This class inherits from the original enemies class
{
    
    public int direction; //variable to determine if enemy is moving left or right

   void Start() 
    {
       direction = Random.Range(0, 2); //Generate random direction
    }


    // This method moves the character
    public override void Move()
    {
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime; //decreases the y position

        // uses randomly generated number to determine direction of travel
        if (direction == 0) //travels right
        {
            tempPos.x += speed * Time.deltaTime; //changes the x position
        } 
        else if (direction == 1) { //travels left
            tempPos.x -= speed * Time.deltaTime; } //chnages the x position

        pos = tempPos; // sets new position of new enemy 
    }

}
