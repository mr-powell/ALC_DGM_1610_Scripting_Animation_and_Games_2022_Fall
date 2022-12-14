using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Access Mod, Data Type, Name ;
    public float speed; // set speed value
    public float rotSpeed; // Rotation speed
    public float hInput; // horizontal input
    public float vInput; //vertical input
    public float jumpForce; // Jump height
    public Rigidbody playerRB; // Reference Rigidbody component 
    
    // Update is called once per frame
    void Update()
    {
        // Collect Input values from keyboard
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        // Move the character around

        transform.Rotate(Vector3.up, rotSpeed * hInput * Time.deltaTime);        
        //Rotate Left and Right 

        transform.Translate(Vector3.forward * speed * vInput * Time.deltaTime);// Forward and Backward movement 

        if(Input.GetKeyDown(KeyCode.Space)) //Check for space bar press
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);  // Makes player jump     
    }
}
