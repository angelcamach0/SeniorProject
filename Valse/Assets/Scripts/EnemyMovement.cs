using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement: MonoBehaviour {

   public float moveSpeed = 2.0f;
   Rigidbody2D theRB;
   Transform target;
   Vector2 moveDirection;
   public Animator animator;

   private void Awake() {
    theRB = GetComponent<Rigidbody2D>();
   }

   private void Start() {
    target = GameObject.Find("PlayerCat").transform;
   }

   private void Update() {

    if(target) {

        Vector3 direction = (target.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        theRB.rotation = angle;
        moveDirection = direction;
    }
   }


   private void FixedUpdate() {
     if (target) {
       theRB.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
     }
   }

}
