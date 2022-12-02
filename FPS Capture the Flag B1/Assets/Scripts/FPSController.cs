using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    //Global Variables
    [Header("Player Stats")]
    public float moveSpeed = 10f;// movement speed in units per second
    public float jumpForce;// force applied to the y axis to make the player jump up
    [Header("Camera Info")]
    public float lookSensitivity;// mouse look sensitivity
    public float maxLookX;// lowest point we can look down
    public float minLookX;// highest point we can look up
    private float rotX;// Current x rotation of the camera
    [Header("Private Variables")]
    private Camera camera;// reference the main camera
    private Rigidbody rb;// reference the rigidbody component

    void Awake()
    {
        //Get Components
        camera = Camera.main;
        rb = GetComponent<Rigidbody>();
        //Freeze and Disable Cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        CameraLook();

        if(Input.GetButtonDown("Jump"))
            PlayerJump();
    }

    void PlayerMove()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed; // Get left and right input
        float z = Input.GetAxis("Vertical") * moveSpeed; // Get forward and back input
        // Move the player in relation to the cameras direction. 
        Vector3 dir = transform.right * x + transform.forward * z;
        dir.y = rb.velocity.y;
        
        rb.velocity = dir; // Applys velocity on x and z axes. It makes the player move.
    }

    void CameraLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity;

        rotX = Mathf.Clamp(rotX, minLookX, maxLookX); //Clamp the vertical rotation of the player so it doesn't flip around
        // Apply rotation to the player
         camera.transform.localRotation = Quaternion.Euler(-rotX, 0, 0);
         transform.eulerAngles += Vector3.up * y;
    }

    void PlayerJump()
    {
        //Ray cast for ground detection
        Ray ray = new Ray(transform.position, Vector3.down);

        if(Physics.Raycast(ray, 1.1f))
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

    }

    public void GiveHealth(int amount)
    {

    }

    public void GiveAmmo(int amount)
    {
        
    }
}