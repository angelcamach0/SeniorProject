using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement :  MonoBehaviour {

    private Rigidbody2D theRB;
    private bool attack;
    public GameObject[] players;
    public float runSpeed = 20.0f;
    public Animator animator;


    public Transform attackPos;
    public float attackRange = 0.4f;
    public int damageTaken = 1;
    public LayerMask whatisEnemy;

    void Awake() {

      theRB = GetComponent<Rigidbody2D>();

       GetComponent<Rigidbody2D>().gravityScale = 0.0f;
    }

    
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }



    void Update() {

       animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        
       Vector2 catVelocity = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
       moveCharacter(catVelocity);

       Attack();

       ResetAttack();
       AttackInput();

    } //end Update 
        
     void moveCharacter(Vector2 catVelocity) {
         theRB.velocity = (catVelocity * runSpeed) * Time.deltaTime;
     
    //Make character change direction (left or right)
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
        if(attack)
        {
            animator.SetTrigger("attack");

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
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            attack = true; 
        } 
    } //end AttackInput

    private void ResetAttack() 
     {
        attack = false;
    }
   
    private void OnLevelWasLoaded(int level)
    {
        FindStartPos();

        players = GameObject.FindGameObjectsWithTag("Player"); 
        
        if(players.Length > 1)
        {
            Destroy(players[1]);
        }
    }

    void FindStartPos()
    {
        transform.position = GameObject.FindWithTag("StartPos").transform.position;
    }


    void OnDrawGizmosSelected() {
        if (attackPos == null) 
          return;
        
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
   }

} //end CharacterMovement class

