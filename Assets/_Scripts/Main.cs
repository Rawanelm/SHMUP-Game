 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    static public Main S;
    public GameObject[] enemies;
    public float enemySpawn = 0.5f;
    public float enemyPadding = 1.5f;
    private BoundsCheck _bndCheck;

    // this method is called when the application is started 
    void Awake (){
        S = this;
        _bndCheck = GetComponent<BoundsCheck>();

        Invoke("SpawnEnemy", 1f / enemySpawn); //calls the enemySpawn method 

        }

    // this method spawns enemies
    public void SpawnEnemy()
    {
        int ndx = Random.Range(0, enemies.Length); //generates random number to choose type of enemy 
        GameObject go = Instantiate<GameObject>(enemies[ndx]); //instatiates random enemy

        float ePadding = enemyPadding; // sets padding to standard padding

        if (go.GetComponent<BoundsCheck>() != null)
        {
            ePadding = Mathf.Abs(go.GetComponent<BoundsCheck>().radius); // ets padding to the radius from boundchek
        }

        // determines the bounds for spawning an enemy
        Vector3 pos = Vector3.zero;
        float xMin = -_bndCheck.camWidth + ePadding; 
        float xMax = _bndCheck.camWidth - ePadding; 

        // generates random x position
        pos.x = Random.Range(xMin, xMax); 
        pos.y = _bndCheck.camHeight + ePadding; 

        go.transform.position = pos; //spawns the enemy

        Invoke("SpawnEnemy", 1f / enemySpawn); // invokes the enemy spawn method again
    }
}
