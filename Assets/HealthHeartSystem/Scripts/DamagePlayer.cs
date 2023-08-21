using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //We are going to use a Unity built in function that happens with collisions
    private void OnTriggerEnter2D(Collider2D collision)
    {

        //First we will check the tag of the object in order to check if it is the player
        if(collision.tag == "MainPlayer")
        {
            Debug.Log("The player has collided with an spike");
            PlayerHealthController.instance.DealDamage();
        }
    }
}
