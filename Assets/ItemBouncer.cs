using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBouncer : MonoBehaviour
{
    public float bounceAmount = 0.1f;
    public float speedScale = 1f;
    private Vector3 startingPosition;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = startingPosition + (Vector3.up * bounceAmount * Mathf.Sin(Time.time * speedScale));
    }
}
