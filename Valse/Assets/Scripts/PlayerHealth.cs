using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
     public int playerHealth;
    
      public GameObject[] lives;
       public Sprite full_Life;
       public Sprite empty_Life;

private void Start() {
     UpdateHealth();
}

public void UpdateHealth() 
   {

        for (int i = 0; i < lives.Length; i++) {
  
             if (i < playerHealth) {
               SpriteRenderer spriteRenderer = lives[i].GetComponent<SpriteRenderer>();
                 spriteRenderer.sprite = full_Life;
                //lives[0].sprite = full_Life;
             } //end if

             else {
               SpriteRenderer spriteRenderer = lives[i].GetComponent<SpriteRenderer>();
               spriteRenderer.sprite = empty_Life;
              // lives[i].sprite = empty_Life;
             } //end else
       } //end for
       

      } //end UpdateHealth
 } //end PlayerHealth method


