//import Unity libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Handles amount of health the player has, which is a primary component of making the HealthController gameobject function
public class PlayerHealth : MonoBehaviour
{
     //variables to handle player health system
     public int playerHealth;
    
    public GameObject[] lives;
    public Sprite full_Life;
    public Sprite empty_Life;
    public Animator animator;

  //Call UpdateHealth to update lives if the player takes damage from enemy projectiles that collide with the Cat sprite during gameplay testing
    private void Start() {
     UpdateHealth();
}

//Important method that updates playerHealth after loss of a live in the health UI
public void UpdateHealth() 
   {
      //go through each heart game object in the array of hearts and either keep at full life (if no damage occurred upon projectile collision)
      //or damage the health system and replace the full life sprite with a empty life gameObject (indicates that one HP from character health system was deducted)
        for (int i = 0; i < lives.Length; i++) {
  
           //Modify the sprite object to contain full life if no damage has occurred (red hearts means full life)
             if (i < playerHealth) {
               SpriteRenderer spriteRenderer = lives[i].GetComponent<SpriteRenderer>();
                 spriteRenderer.sprite = full_Life;
                //lives[0].sprite = full_Life;
             } //end if

            //Modify the sprite object to update a full life to an empty life when damage has collided with the character (white hearts means empty life)
             else {
               SpriteRenderer spriteRenderer = lives[i].GetComponent<SpriteRenderer>();
               spriteRenderer.sprite = empty_Life;
              // lives[i].sprite = empty_Life;
             } //end else
       } //end for

       //if the playerHealth is updated to be less than or equal to 0 in the Unity inspector
       //call PlayerDead method which triggers a player death animation
        if (playerHealth <= 0)
        {
            PlayerDead();
        }

      } //end UpdateHealth

//Player's death animation is destroyed and triggers after their life bar of 6 hearts is full of empty life sprites (or completely a list of white hearts)
//The player death animation works only in Level 1 but not functioning in Level 3 scene within Unity
public void PlayerDead()
    {
        animator.SetTrigger("Die");
        Debug.Log("Player now dead");
    }
 } //end PlayerHealth method


