using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed; // set speed value
    public float rotSpeed; // Rotation
    public float hInput; // horizontal input
    public float vInput; //vertical input
    
    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up, rotSpeed * hInput * Time.deltaTime);// Left and Right movement

        transform.Translate(Vector3.forward * speed * vInput * Time.deltaTime);//Forward and Backward movement
    }
}
