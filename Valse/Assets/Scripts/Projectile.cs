using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;


    private Transform player;
    private Vector2 target;
    private SpriteRenderer spriteRenderer;


    void Start()
    {
        player = GameObject.Find("PlayerCat").transform;

        target = new Vector2(player.position.x, player.position.y);
    }


    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject Player = other.gameObject;

        if (Player.name == "PlayerCat") 
        {
           DestroyProjectile();
        }
    }
    
    
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
