using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinController : MonoBehaviour
{

    public TMP_Text WINTEXT;
    
    // Start is called before the first frame update
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
            WINTEXT.gameObject.SetActive(true);
        }
    }
}
