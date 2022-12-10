//import Unity libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This method damages the player when they get hit by a bullet or projectile from the enemy
public class DamagePlayer : MonoBehaviour
{
    //Modifiable traits of how much damage the player can take (conveyed by bulletDamage) in the Unity inspector
    //Indicates how much health the player starts out with while contolling the character (conveyed by catHealth) in the Unity inspector
   [SerializeField] private int bulletDamage;
   [SerializeField] private PlayerHealth catHealth;
   
 //Retrieve gameobject of HealthController in the PlayerHealth.cs script in order to update catHealth after player takes damage
public void Start() {
    catHealth = GameObject.Find("HealthController").GetComponent<PlayerHealth>();
}
//If player collides with a projectile then their health bar gets damaged by 1 HP (life)
 private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
           CatgetsDamaged();
        }
    }
//This method updates cat health value from the HealthController gameobject and damages player health after Cat collides with an enemy projectile
   public void CatgetsDamaged() {
        catHealth.playerHealth = catHealth.playerHealth - bulletDamage;
        catHealth.UpdateHealth();
        //gameObject.SetActive(false);
    } //end CatgetsDamaged
} //end class