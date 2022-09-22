using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float upperBound = 25.0f;

    private Balloon balloon;
    private ScoreManager scoreManager; // A variable to reference the ScoreManager    

    // Start is called before the first frame update
    void Start()
    {
       //Reference ScoreManager Component
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>(); // Reference ScoreManger
        balloon = GetComponent<Balloon>(); // Reference balloon script
    }

    // Update is called once per frame
    void Update()
    {
      // Move the Balloon upward
      transform.Translate(Vector3.up * moveSpeed * Time.deltaTime); 

      // Destroy Balloon after it passes upperbound
      if(transform.position.y > upperBound)
      {
        scoreManager.DecreaseScoreText(balloon.scoreToGive);// Substract scoreToGive from total score
        Destroy(gameObject);// POP Balloon
      } 
    }
}
