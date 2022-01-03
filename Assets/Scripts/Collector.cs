using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Player")) // catches enemeis & players that hit collector gameobjects
        {
            Destroy(collision.gameObject); // destroys the object that COLLIDED with Collector points vs Destroy(gameObject) which would destory the collector

        }
    }
}
