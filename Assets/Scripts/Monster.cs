using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // MONSTERS will not collide with each other bc added to new collision layer - ENEMY & changed to no interaction

    [HideInInspector] public float speed; // have to access in enemyspawner script but dont want to change it in inspector

    private Rigidbody2D myBody;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate() // put here bc physics
    {
        // a set velocity for movement 
        myBody.velocity = new Vector2(speed, myBody.velocity.y); // speed declared above but defined in EnemySpawner script as random number

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
