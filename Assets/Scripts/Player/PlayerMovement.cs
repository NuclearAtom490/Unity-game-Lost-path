using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalInput;
    [SerializeField] private float movespeed; //  "SerializeField" enables you to change the variable value directly in Unity
    [SerializeField] private float jumpSpeed;
    private Rigidbody2D rb; //Assigns RigidBody2D to varaible "body"
    private Animator anim; // Allows acces to animatior
    private bool grounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); //Searches for the RigidBody2D component in Unity and stores it in body variable
        anim = GetComponent<Animator>();
    }

    private void Update() // Runs on every frame of the game
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Just sets horizontalInput as a variable for ease

        rb.linearVelocity = new Vector2(horizontalInput * movespeed, rb.linearVelocity.y); //Left and right movement

        //This code will flip the sprite depending on the direction its facing
        if (horizontalInput > 0.001f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.001f)
            transform.localScale = new Vector3(-1,1,1);

        //Jump 
        if (Input.GetKey(KeyCode.W) && grounded)
        {
            Jump();
        }

        //Sprinting
        if (Input.GetKey(KeyCode.LeftShift))
            rb.linearVelocity = new Vector2(horizontalInput * (movespeed * 2), rb.linearVelocity.y);
        else
            rb.linearVelocity = new Vector2(horizontalInput * movespeed, rb.linearVelocity.y);


        //Set animator parameters
        anim.SetBool("Walk", horizontalInput != 0);
        anim.SetBool("Run", Input.GetKey(KeyCode.LeftShift) == true);
        anim.SetBool("Grounded", grounded);
    }  


    private void Jump()
    {
        float actualJumpSpeed;

        // Increases jump power when sprinting
        if (Input.GetKey(KeyCode.LeftShift))
            actualJumpSpeed = jumpSpeed * 1.3f;
        else
            actualJumpSpeed = jumpSpeed;

        rb.linearVelocity = new Vector2(rb.linearVelocity.x, actualJumpSpeed);
        anim.SetTrigger("Jump");
        grounded = false;
    }
    //Detects collision between the ground and the player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }


}