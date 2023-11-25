using System.Runtime;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Enemy : MonoBehaviour
{

     [Header("Enemy Stats")]

     public float health = 100;
     public float startSpeed = 10f;

     [HideInInspector]
     public float speed;
     public int damage = 1;
     public int moneyDrop = 20;

     private bool alive;


     //faire une liste de debuffs que les tourelles remplissent et qui est gérée dans l'update ici
     
     void Start()
     {
         speed = startSpeed; 
         alive = true;
     }
     public GameObject deathEffect;


     public void TakeDamage(float amount) 
     {
          health -= amount;

          if (health <= 0) 
          {
               Die();
          }
     }

     public void Slow(float slowAmount)
     {
          speed = startSpeed * (1f - slowAmount);
     }
     void Die()
     {
          if(alive){
               alive = false;
               Destroy(gameObject);
               GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
               Destroy(effect, 2f / WorldTime.getActionSpeed());
               if(PlayerStats.Money < 99999) PlayerStats.Money += moneyDrop;
               else PlayerStats.Money = 99999;
          }
     }

    
}
