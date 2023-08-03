using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies; //index 1 and 2 are fighters, index 3 is destroyer
    private static float xRange = 27.5f;
    private static float zPos = 35.0f; //spawns a little above game area
    public float spawnInterval = 3.0f;
    public float enemiesSpawned;
    public int enemyVariety;
    public int enemyCap; 
    bool spawn = true;

    void Start()
    {
        //enemiesSpawned = 0;
        //enemyVariety = 2; //index 1 and 2 are fighters, index 3 is destroyer
        //enemyCap = 8;
        //spawnInterval = 3.0f;
        //^^^^starting values given by game manager
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn)
        {
            StartCoroutine(spawnEnemy());
        }

        if (enemiesSpawned >= enemyCap && spawnInterval > 1.8f) //increase spawn time for each amount of enemies spawned
        {
            spawnInterval -= 0.2f;
            enemyCap += 7;
        }

        if (enemiesSpawned >= 9) //after 9 enemies spawned, destroyers will now spawn
        {
            enemyVariety = 3;
        }

    }

    IEnumerator spawnEnemy() //spawns random enemies at random positions at the top of the screen
    {
        float randomXPos = Random.Range(-xRange, xRange);
        int enemyIndex = Random.Range(0, enemyVariety);
        Vector3 spawnPos = new Vector3(randomXPos, 0, zPos);
        Instantiate(enemies[enemyIndex], spawnPos, Quaternion.Euler(0f, 180f, 0f));
        spawn = false;
        enemiesSpawned++;
        yield return new WaitForSeconds(spawnInterval);
        spawn = true;
    }

}
