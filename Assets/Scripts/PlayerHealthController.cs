using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{

    //Storing this script in order to use it in other scripts when character collides to something
    public static PlayerHealthController instance;

    //We are storing the current health in order to trck the player's halth, also sotre the maximum health that this character can have
    public int currentHealth, maxHealth;

    public float invincibleLength;
    private float invincibleCounter;

    //getting the sprite in order to make it transparent
    private SpriteRenderer elSR;

    private float minYValueForDeath = -30f;


    // We are going to use the built in function of awake from Unity that it will execute before the code is even run and before the Start() function
    private void Awake(){
        //Befor the script is executed, we wil assign the script the variable instance
        instance = this;
    }
    void Start()
    {
        
        //At the beginning we will assign the max health to the current one since the game just started
        currentHealth = maxHealth;
        elSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //if player falls then it should die
        if(transform.position.y < minYValueForDeath)
        {
            LevelManager.instance.RespawnPlayer();
        }

        //In each fram decrement the counter for invincible
        if( invincibleCounter > 0){
            invincibleCounter -= Time.deltaTime;

            if (invincibleCounter <=0){
                //return to normal color when invincible finishes
                elSR.color = new Color(elSR.color.r, elSR.color.g, elSR.color.b, 1f);
            }
        }
        
    }
    //Now ww will create a function that will executre everytime we collide with something dangerous

    public void DealDamage()
    {
        //so we will reduice the current health
        currentHealth --;

        // We will always check if the character has already died
        if(currentHealth <= 0)
        {
            currentHealth =0;

            //if the player does not have health then it will dissapear
            
            LevelManager.instance.RespawnPlayer();
        } else{
            invincibleCounter = invincibleLength;
            elSR.color = new Color(elSR.color.r, elSR.color.g, elSR.color.b, 0.5f);

            PlayerController.instance.Knockback();
        }

        //here the hearts will change everytinme we get damaged
        UIController.instance.UpdateHealthDisplay();
    }
}
