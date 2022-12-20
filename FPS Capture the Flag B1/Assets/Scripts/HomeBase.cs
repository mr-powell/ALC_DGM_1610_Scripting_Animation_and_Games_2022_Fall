using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBase : MonoBehaviour
{
    private GameManager gm;
    private Renderer flagRend;

    // Start is called before the first frame update
    void Start()
    {
        // Get Components
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        flagRend = GameObject.Find("FlagHome").GetComponent<Renderer>();
        //Hide the flag
        flagRend.enabled = false;

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && gm.hasFlag)
        {
            Debug.Log("Player has reached Homebase!");
            gm.PlaceFlag();
            flagRend.enabled = true;//Makes flag visible
        }
    }
}