using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement :  MonoBehaviour {

    public float moveSpeed;
    public float vertical;
    public float runSpeed = 20.0f;

    private RigidBody2D theRB;

   
    void Start() {

      theRB = GetComponent<RigidBody2D>();

    }

    void Update() {

        moveSpeed.x = Input.GetAxisRow("Horizontal");
        moveSpeed.y = Input.GetAxisRow("Vertical");

       // transform.position = new Vector3(moveControl.x * Time.deltaTime * moveSpeed, moveControl.y * Time.deltaTime, 0f);

       theRB.velocity = newVector2(horizontal * runSpeed, vertical * runSpeed);

       Vector3 mousePos = Input.mousePosition;
       Vector screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);

       if(mousePos < screenPoint.x) {
              transform.localScale = new Vector(-1f, 1f, 1f);
       } //end if

       else {
         transform.localScale = Vector3.one;
       }

       if (moveSpeed != Vector2.zero) {
          anim.setBool("isMoving", true);
       }

       else {
          anim.setBook("isMoving", false);
       } //end else
   } //end Update
   
} //end CharacterMovement