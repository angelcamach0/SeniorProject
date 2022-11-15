using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement: MonoBehaviour {

   public float moveSpeed = 2.0f;
   Rigidbody2D theRB;
   Transform target;
   Vector2 moveDirection;
   
    
   public Animator animator;
   public Transform playerCharacter;
   public GameObject projectile;
   public float startTimeShots;
    
   private SpriteRenderer spriteRenderer;
   private float timeBetweenShots;






   private void Awake() {
    theRB = GetComponent<Rigidbody2D>();

    this.spriteRenderer = this.GetComponent<SpriteRenderer>();
   }

   private void Start() {
    target = GameObject.Find("PlayerCat").transform;


    timeBetweenShots = startTimeShots;
   }



   private void Update() {

    this.spriteRenderer.flipX = playerCharacter.transform.position.x > this.transform.position.x;

    if(target) {

        Vector3 direction = (target.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //theRB.rotation = angle;
        moveDirection = direction;
    }

    if(timeBetweenShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBetweenShots = startTimeShots;
        }
   else
        {
            timeBetweenShots -= Time.deltaTime;
        }
   }


   private void FixedUpdate() {
     if (target) {
       theRB.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
     }
   }

}
