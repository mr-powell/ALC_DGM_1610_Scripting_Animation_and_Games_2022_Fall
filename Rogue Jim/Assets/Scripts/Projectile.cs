using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed;
    private Transform player;
    private Vector2 target;
    private Health playerHealth;
    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();// Get players position
        target = new Vector2(player.position.x, player.position.y);// Aim at the target/ player
        playerHealth = GameObject.Find("Player").GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
       transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime); 

       if(transform.position.x == target.x && transform.position.y == target.y)// Once target has been reached destroy projectile
       {
           DestroyProjectile();
       }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))// Destroy projectile if it hits the player
        {
            playerHealth.TakeDamage(damage);
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
