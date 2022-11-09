using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public float deathDelay;
    
    // Start is called before the first frame update
    void Start()
    {
       currentHealth = maxHealth; //Set current health to max health        
    }

    public void TakeDamage(int dmgAmount)
    {
        currentHealth -= dmgAmount; // Take away a certain amount of health 
        Debug.Log("Enemies Health = "+ currentHealth);

        if(currentHealth <= 0) // Check to see if the enemy has expired
        {
            Debug.Log("Enemy has Died!");
            Destroy(gameObject,deathDelay);
        }
    }
       
}