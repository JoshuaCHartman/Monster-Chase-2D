using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] monsterReference; // monster array - currently 7

    private GameObject spawnedMonster;

    [SerializeField] private Transform leftPos, rightPos; // positions of empty L/R GameObjects acting as spawn points

    private int randomIndex;
    private int randomSide;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters() // coroutine 
    {
        //while loop for spawn

        while (true)
        {
            // wait for seconds keeps while loop from crashing

            yield return new WaitForSeconds(Random.Range(1, 5)); // return random seconds from 1-5

            randomIndex = Random.Range(0, monsterReference.Length); // random index number from array
            randomSide = Random.Range(0, 2); // random L or R spawn point

            spawnedMonster = Instantiate(monsterReference[randomIndex]); // create monster from array, using random number

            // left spawn point
            if (randomSide == 0)
            {
                spawnedMonster.transform.position = leftPos.position; // spawned monster position = left spawn point position
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(4, 10); // generate random speed value (speed is public in Monster script but hidden)
            }
            // right spawn point  
            else
            {
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(-4, -10); // neg speed to left/down X axis
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f); // reverse orientation of monster
            }
        }

    }



}
