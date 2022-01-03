using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveForce = 10f;
    [SerializeField] private float jumpForce = 11f;
    //public float maxVelocity = 22f;

    private float movementX;

    [SerializeField] private Rigidbody2D myBody;

    private SpriteRenderer sr; // declare to access sprite renderer - channge orientation

    private Animator anim;
    private string WALK_ANIMATION = "Walk"; // Walk is name of walking animation state in animator

    private bool isGrounded;
    private string GROUND_TAG = "Ground"; // Ground is name of tag on ground objects

    [SerializeField] private float minX, maxX; // for boundaries
    private Vector3 tempPos;

    private string ENEMY_TAG = "Enemy"; // for collision with enemy

    private void Awake()
    {
        // make references from defined class/objects to game engine objects & components 
        myBody = GetComponent<Rigidbody2D>(); // looks through Player components until finding rigidbody
        anim = GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>(); 

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
        
    }

    private void FixedUpdate() // usually used for physics calculations, like with rigidbody

    {
        //PlayerJump(); moved to update - doesnt sync properly
    }
    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        // getaxis RAW vs getaxis = -1,0,1 vs fractional values 
        //Debug.Log("move X value is :" + movementX);

        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
        // transform.position += new Vector2(movementX, 0f) * Time.deltaTime * moveForce; - DOES NOT WORK AS VECTOR2
        //Debug.Log(Time.deltaTime);

        //set hard boundaries for player so won't fall off using empty vector3 for storageS
        tempPos = transform.position; // get player's position and store it

        if (transform.position.x > maxX)
            tempPos.x = maxX; // if x position greater than maxX set it as maxX in stored position
        if (transform.position.x < minX)
            tempPos.x = minX; // if x position less than minX set is as minX in stored position
        transform.position = tempPos; // make player's position equal the stored position


    }

    void AnimatePlayer()
    {
        //anim.SetBool(WALK_ANIMATION, true);
        // getaxis raw returns 3 potential values = -1, 0 (not pressed), 1

        // go right (default)
        if (movementX > 0 /*|| movementX <0*/)
        {
            anim.SetBool(WALK_ANIMATION, true); // animator action tree transition parameters "Walk" set to true
            sr.flipX = false; // sprite renderer flip property - false is default
        }
        // go LEFT 
        else if (/*movementX > 0 ||*/ movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true; // flip player on x axis when negative x value entered via keybpoard
        }
        //IDLE
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded) // unity defined platform neutral / down is when button pressed down, up is when button released
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            // add force on x (0) & y (jumpforce), instant application 
            // add physics to the rigidbody
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // when 2d colliders touch method runs

        // MONSTERS will not collide with each other bc added to new collision layer - ENEMY & changed to no interaction

        if (collision.gameObject.CompareTag(GROUND_TAG)) // tag is on ground objects. when player 
            // collides with tag, bool switches
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag(ENEMY_TAG)) // destroy player when contact enemy
        {
            Destroy(gameObject);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision) // destroy player when contact ghost. ghost set to trigger.
    {
        // trigger collider allows other object to "pass through" vs run into each other
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }
}
