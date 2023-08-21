using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//In order to acces an image, we need to import this moduile
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    //savin to instance variable this script in instance variable in order to be used in other scripts
    //This is known is Singleton
    public static UIController instance;

    //Getting acces to image
    public Image heart1, heart2,heart3;

    public Sprite heartFull, heartEmpty;


    // Start is called before the first frame update
    void Start()
    {
        //Assigning script
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Creating our function for updating the UI hearts
    public void UpdateHealthDisplay()
    {
        switch(PlayerHealthController.instance.currentHealth)
        {
            case 3:
                //if the player only has 3 of value in health
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;
                break;
            case 2:
                //if the player only has 2 of value in health
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartEmpty;
                break;
            case 1:
                //if the player only has 1 of value in health
                heart1.sprite = heartFull;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;
            case 0:
                //if the player only has 2 of value in health
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;
            default:
                //If for some reason it has another value the health
                //then it will be no hearts
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;
        }
    }
}
