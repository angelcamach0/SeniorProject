using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement :  MonoBehaviour {

    private Rigidbody2D theRB;
    private bool attack;
    public float runSpeed = 20.0f;
    public Animator animator;

    
    
    void Awake() {

      theRB = GetComponent<Rigidbody2D>();

       GetComponent<Rigidbody2D>().gravityScale = 0.0f;
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
        }
    }

    private void AttackInput()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            attack = true;
        }
    }

    private void ResetAttack()
    {
        attack = false;
    }
   
} //end CharacterMovement class

