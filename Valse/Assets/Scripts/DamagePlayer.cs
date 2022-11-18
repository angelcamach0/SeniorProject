using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
   [SerializeField] private int bulletDamage;
   [SerializeField] private PlayerHealth catHealth;
   
    
public void Start() {
    catHealth = GameObject.Find("HealthController").GetComponent<PlayerHealth>();
}
 private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
           CatgetsDamaged();
        }
    }

   public void CatgetsDamaged() {
        catHealth.playerHealth = catHealth.playerHealth - bulletDamage;
        catHealth.UpdateHealth();
        //gameObject.SetActive(false);
    } //end CatgetsDamaged
} //end class