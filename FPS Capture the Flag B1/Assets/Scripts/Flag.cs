using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    private GameManager gm;
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
       gm = GameObject.Find("GameManager").GetComponent<GameManager>(); //Find and reference GameManager
       rend = GetComponent<Renderer>();
       rend.enabled = true;//Makes the flag visible
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gm.hasFlag = true;
            Debug.Log("You have captured the flag!");
            //this.gameObject.SetActive(false);
            rend.enabled = false;//Hides the Flag
        }
    }
}