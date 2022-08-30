using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0,2,-7);

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset; 
    }
}
