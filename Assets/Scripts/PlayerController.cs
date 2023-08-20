using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    //Create move speed in order to set the character move speed
    public float moveSpeed;
    //RigidBody in order to move player
    public Rigidbody2D elRB;
    public float jumpForce;

    //keep track if the player is touching the ground
    private bool isInGround;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround; // stores ground that the player will be touching

    private bool isDoubleJump; // Initializes to false(booleans in C# the default is false)


    //Referencing the animation
    private Animator anim;
    //Storing previous sprite for the animation
    private SpriteRenderer elSR;


    public float powerUpDuration;
    
    public GameObject speedTrail;
    private Transform playerTransform;
    private ParticleSystem speedTrailInstance;
    void Start()
    {
        //Select the animation of the character that currently has this script attached
        anim = GetComponent<Animator>();

        //Assigning the Sprite renderer of the attached character
        elSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()    
    {
        // Controll horizontal movement
        //We are moving only horizontally and maintaining the same y vertical position
        elRB.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), elRB.velocity.y);

        //We are going to assign to "isInGround" a True or a false, depending if the character is touching the ground
        isInGround = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);

        if (isInGround){
            //When the character is in the ground
            //Then we are allowed a Double Jump
            isDoubleJump = true;
        }

        // Jumping functionality
        if(Input.GetButtonDown("Jump")){
            if (isInGround){
                elRB.velocity = new Vector2(elRB.velocity.x, jumpForce); //jump
            }
            else if(isDoubleJump){
                elRB.velocity = new Vector2(elRB.velocity.x, jumpForce);// jump #2
                //Since we just only want just two jumps, then we can put false so it can reset the double jump to true again when the player is in the ground
                isDoubleJump = false;

            }
            
        }

        //If the character us moving in the x direction to the left
        if(elRB.velocity.x < 0){
            // then we flip the sprite in order for the animation to look left(In this case, since our character is watching towards us, we will not notice that :^/)
            elSR.flipX = true;
        } else if(elRB.velocity.x > 0)
        {
            //In the case that the chracter is looking to the right, the sprite has to return to its original rotation(watching to the right)
            elSR.flipX = false;
        }
        

        //Now, we are going to modify the parameters that we set in the Animator
        //We are using absolute values in order to make the running animation when the player movesto the left(moving to the negative of the x-axis)
        anim.SetFloat("movespeed", MathF.Abs(elRB.velocity.x));
        anim.SetBool("isGrounded", isInGround);
    }

    public void PowerUpEffect()
    {
        moveSpeed += 4;
        activateSpeedTrail();
        StartCoroutine(DeactivatePowerup());
    }

    IEnumerator DeactivatePowerup()
    {
        yield return new WaitForSeconds(powerUpDuration);
        moveSpeed = 6;
    }


    public void activateSpeedTrail()
    {
        // Instantiate the speedTrailPrefab

        Quaternion particleRotation = speedTrail.transform.rotation;

        speedTrailInstance = Instantiate(speedTrail, transform.position, particleRotation).GetComponent<ParticleSystem>();

        // Set the speedTrailInstance's parent as the player's transform
        speedTrailInstance.transform.SetParent(transform);

        // Play the particle system
        if (speedTrailInstance != null)
        {
            speedTrailInstance.Play();
        }
    }
}
