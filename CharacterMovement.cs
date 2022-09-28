using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement :  MonoBehaviour {

    public float moveSpeed;
    public float vertical;
    public float runSpeed = 20.0f;

    private RigidBody2D theRB;

   
    void Awake() {

      theRB = GetComponent<RigidBody2D>();

       rigidBody2D.gravityScale = 0.0f;
    }

    void Update() {

       Vector2 catVelocity = new Vector2 (Input.getAxisRow("Horizontal"), Input.getAxisRow("Vertical"));
       Move(catVelocity);
        
     void moveCharacter(Vector2 catVelocity) {
         
         theRB.velocity = (catVelocity * moveSpeed) * Time.deltaTime;
   } //end Update
} //end CharacterMovement
