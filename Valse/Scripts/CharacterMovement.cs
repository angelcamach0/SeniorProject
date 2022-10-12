using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement :  MonoBehaviour {

    public GameObject character;
    
    public float moveSpeed;
   // public float horizontal;
    public float vertical;
    public float runSpeed = 20.0f;

    private RigidBody2D theRB;

   
    void Awake() {

      theRB = GetComponent<RigidBody2D>();

       rigidBody2D.gravityScale = 0.0f;
    }

    void Update() {
        
        if(Input.GetKey(KeyCode.RightArrow)) {
            transform.position += Vector3.right * runSpeed * time.deltaTime;
        } //end if
        
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.position += Vector3.left * runSpeed * time.deltaTime;
        } //end if
        
        if (Input.GetKeyCode(KeyCode.UpArrow)) {
            transform.position += Vector3.forward * runSpeed * time.deltaTime;
        } //end if
        
        if (Input.GetKeyCode(KeyCode.DownArrow)) {
            transform.position += Vector3.back * runSpeed * time.deltaTime;
        } //end if

       Vector2 catVelocity = new Vector2 (Input.getAxisRow("Horizontal"), Input.getAxisRow("Vertical"));
       moveCharacter(catVelocity);
        
     void moveCharacter(Vector2 catVelocity) {
         theRB.velocity = (catVelocity * moveSpeed) * Time.deltaTime;
   } //end Update
} //end CharacterMovement class
