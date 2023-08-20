using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // reference the target or thing that the camera will be following
    public Transform target;

    //select the background that is far away
    public Transform farBackground;

    //To calculate how much the background moves, we will store in each frame update, the last position the camera was in
    private float lastxPos;

    //setting the maximum height and minimum that the camera can go in the y-axis
    public float minHeight, maxHeight;


    void Start()
    {
       //As soon as the code executes, we are assigning the last position
       lastxPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        //We are going to attach the camera to the target
        //Here we follow horizontally 
        transform.position = new Vector3(target.position.x, Mathf.Clamp(transform.position.y, minHeight,maxHeight), transform.position.z);

        //Calculating the the amount that will move the background
        float amountToMoveX = transform.position.x - lastxPos;

        //Moving the background that is far away
        farBackground.position = farBackground.position + new Vector3(amountToMoveX,0f,0f);

        //Before finishing the frame update, we are going to store the last position the camera was in so that the next frame can update the background position
        lastxPos = transform.position.x;
    }
}
