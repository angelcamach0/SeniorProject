using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Projectile class that enables enemies to do damage to the player using a standard ranged attack
public class Projectile : MonoBehaviour
{
    //Velocity at which the projectile travels at in respect to time
    public float speed;

    //Instantiate variables for current target of each enemy projectile fired
    private Transform player;
    private Vector2 target;
    private SpriteRenderer spriteRenderer;


    //Find player gameObject and set the target of the enemy projectile to be aimed at the player
    void Start()
    {
        player = GameObject.Find("PlayerCat").transform;

        target = new Vector2(player.position.x, player.position.y);
    }

   //When projectile hits or misses targeted playerCat object, then it destroys itself after a few seconds in each updated frame of gameplay
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    //Afte a collision with the player's character is successful from the projectile, damage the player's health and then call DestroyProjectile() method
    //DestroyProjectile() destroys the game object/prefab of Projectile after hitting or missing the player target upon point of impact
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject Player = other.gameObject;

        if (Player.name == "PlayerCat") 
        {
           DestroyProjectile();
        }
    }
    
    //Destroy the Projectile gameObject after enemy has shot it directed towards the player
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
