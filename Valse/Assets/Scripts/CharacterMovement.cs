//Import Unity libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script is designed to have the main character move around in a Unity game environment, 
public class CharacterMovement :  MonoBehaviour {

   //Initialize character movement variables
    private Rigidbody2D theRB;
    private bool attack;
    public GameObject[] players;
    public float runSpeed = 20.0f;
    public Animator animator;

//Initialize variables that indicate character attack range and melee damage to enemies
    public Transform attackPos;
    public float attackRange = 0.4f;
    public int damageTaken = 1;
    public LayerMask whatisEnemy;

    //retrieves the playerCat gameobject RigidBody2D component and enables it to move in any inputted direction
    void Awake() {

      theRB = GetComponent<Rigidbody2D>();

       GetComponent<Rigidbody2D>().gravityScale = 0.0f;
    }

    //When a scene loads do not destroy the current game object transitioning into another scene
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }


   //Update character movement per frame and call methods to update the character attack animations
    void Update() {

       animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        
       Vector2 catVelocity = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
       moveCharacter(catVelocity);

       Attack();

       ResetAttack();
       AttackInput();
 } //end Update 
        
  //method responsible for moving the character with Unity imported function Time.deltaTime
     void moveCharacter(Vector2 catVelocity) {
         theRB.velocity = (catVelocity * runSpeed) * Time.deltaTime;
     
    //Make character change direction (left or right) based on location of the mouse cursor
    Vector3 mousePos = Input.mousePosition;
    Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);

    if (mousePos.x < screenPoint.x) {
        transform.localScale = new Vector3(-1f, 1f, 1f);
    }
    else {
       transform.localScale = Vector3.one;
    }
   } //end moveCharacter class

    private void Attack()
    {
        //if an attack is enabled then set trigger for character to start attacking
        if(attack)
        {
            animator.SetTrigger("attack");

            //initialize an array collision of enemies that take damage when the player initiates attack
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatisEnemy);

            //Damage the enemies
            foreach(Collider2D enemy in hitEnemies) {
                enemy.GetComponent<EnemyMovement>().TakeDamage(damageTaken);
                //Debug.Log("Cat hits the enemy: -1 HP damage dealt");
            }
        }
    }

    private void AttackInput()
    {
        //If user inputs left shift key then trigger melee attack animation for character "Cat"
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            attack = true; 
        } 
    } //end AttackInput

   //When left shift is not pressed down then reset character to initial state of movement
    private void ResetAttack() 
     {
        attack = false;
    }
   
   //This method loads each scene with character movement transitioning from each level
    private void OnLevelWasLoaded(int level)
    {
        FindStartPos();

        players = GameObject.FindGameObjectsWithTag("Player"); 
        
        if(players.Length > 1)
        {
            Destroy(players[1]);
        }
    }

    //Find the starting position of the character on the map and focus camera angle onto the player's position
    void FindStartPos()
    {
        transform.position = GameObject.FindWithTag("StartPos").transform.position;
    }

   //Red circle deployed in Unity scene that indicates distance between the enemy and player
    void OnDrawGizmosSelected() {
        if (attackPos == null) 
          return;
        
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
   }

} //end CharacterMovement class

