using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{    
    public int clickToPop = 3; //How many clicks before balloon pops

    public float scaleToIncrease = 0.10f; //Scale increase each time the ballon is clicked

    public int scoreToGive;  // Score give for popped balloon.

    private ScoreManager scoreManager; // A variable to reference the ScoreManger

    // Start is called before the first frame update
    void Start()
    {
        //Reference ScoreManager Component
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    void OnMouseDown()
    {
        // Reduce clicks by one
        clickToPop -= 1;
        //Increase 
        transform.localScale += Vector3.one * scaleToIncrease;

        if(clickToPop == 0)
        {
            scoreManager.IncreaseScoreText();
            Destroy(gameObject);// POP Balloon
        }
    }
}