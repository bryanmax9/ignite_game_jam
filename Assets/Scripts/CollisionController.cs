using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollisionController : MonoBehaviour
{
    public GameObject destroyParticles;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "MainPlayer")
        {
            other.gameObject.GetComponent<PlayerController>().PowerUpEffect();

            Instantiate(destroyParticles, transform.position, Quaternion.identity);

            Destroy(gameObject);

        }
    }

}
