using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enemy moves around each level and targets the player while chasing the playerCat gameObject position
public class EnemyMovement: MonoBehaviour {

  //Set enemy HP to 3 and currHealth to 3 HP at the start of the game
   public int health = 3;
   public int currHealth;

    //initialize enemy collision and movement variables 
   public float moveSpeed = 2.0f;
   Rigidbody2D theRB;
   Transform target;
   Vector2 moveDirection;
   
   //variables that control enemy movement and projectile system in the game scene 
   public Animator animator;
   public Transform playerCharacter;
   public GameObject projectile;
   public GameObject Enemy;
   public float startTimeShots;
    
   private SpriteRenderer spriteRenderer;
   private float timeBetweenShots;

  //declare a RigidBody component so enemies can collide with the character object in different levels
   private void Awake() {
    theRB = GetComponent<Rigidbody2D>();

    this.spriteRenderer = this.GetComponent<SpriteRenderer>();
   }

  //enemy targets the player and shoots at it while converging onto its position
   private void Start() {
    target = GameObject.Find("PlayerCat").transform;
    timeBetweenShots = startTimeShots;
    currHealth = health;
   }

   //Flip enemy wolf sprite based on player position in the camera's perspective
   private void Update() {

    this.spriteRenderer.flipX = playerCharacter.transform.position.x > this.transform.position.x;

    //If player is found enemy starts chasing him and shooting projectiles directed at their current location
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

        //if enemy health equal to 0 or less than 0 then destroy enemy gameobject
        if (health <= 0) {
          Destroy(gameObject);
        }
   }

  //If character is in range of enemy, then enemy moves towards character at a slower speed 
   private void FixedUpdate() {
     if (target) {
       theRB.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
     }
   }

  //Enemy takes damage from the character melee attack at close range
   public void TakeDamage(int damageTaken) {
        currHealth -= damageTaken;  

        if (currHealth <= 0) {
          EnemyDie();
        }       
   }

   //After an enemy dies trigger the enemy death animation
   //Then destroy the enemy object after the enemy HP is down to 0
   void EnemyDie() {
      animator.SetTrigger("Die");
      Destroy(Enemy, 1);
      Debug.Log("Enemy now dead");

      GetComponent<Collider2D>().enabled = false;
      this.enabled = false;
      
   }
}
