using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
       public int health;
       public int amountofHealth;

       public Image[] heartSystem;
       public Sprite full_Life;
       public Sprite empty_Life;

       void Update() {

         if (health > amountofHealth) {
               health = amountofHealth;
            } //end if

         for (int n = 0; n < heartSystem.Length; n++) {

            if (n < health) {
               heartSystem[n].sprite = full_Life;
            } //end if

            else {
               heartSystem[n].sprite = empty_Life;
            } //end else

            if (n < amountofHealth) {
               heartSystem[n].enabled = true;
            } //end if

            else {
               heartSystem[n].enabled = false;
            } //end else
         } //end for
       } //end Update function
       
 } //end PlayerHealth method


