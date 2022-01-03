using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //script attached to main camera (postion is camera's transform.position)

    private Transform player; // position and scale - will be assinged to object tagged "Player"

    private Vector3 tempPos; // holder for transform.position of player

    [SerializeField] private float minX, maxX; // boundaries


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform; // assign the transform (position) properties of object
                                                             // tagged Player to Transform object player

        // player is instantiated in GameManager after selection made in MainMenu (avoids null exception)
        //Debug.Log("selected character index: " + GameManager.instance.CharacterIndex);

    }

    // Update is called once per frame
    void LateUpdate() // LateUpdate called after all update calculations are finished
                        // avoids conflicts/stuttering bc will be moved AFTER player's new position is established
    {
        if (!player)
            return; // null exception handling when player destroyed (camera looking for position). prevents null error.
                    // return in void method - skips everything below 

        tempPos = transform.position; // tempPos = current transform position of the camera
        tempPos.x = player.position.x; // get player's x position and assign it to camera

        //set boundaries for x axis movement of camera
        if (tempPos.x < minX)
            tempPos.x = minX;
        if (tempPos.x > maxX)
            tempPos.x = maxX;

        transform.position = tempPos; // make camera position set to the new coordinates,
                                      // with the player's x. y & z not changed.



    }
}
