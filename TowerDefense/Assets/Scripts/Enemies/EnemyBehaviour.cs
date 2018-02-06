using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    
    public float speed = 5;
    public float health; 
    public int enemyValue;
    
    [HideInInspector]
    public float startSpeed;
    
    void Start(){
        startSpeed = speed;
    }

    public void TakeDamage(float amount){
          health -= amount;
          
          if(health <= 0){
            Die();
          }
    }
    
    public void Slow(float amount){
        // Slow down by the percentage of the slowLaser.
        speed = startSpeed * (1 - amount);
    }
    
    void Die(){
        PlayerManager.currency += enemyValue;
        PlayerManager.lives += enemyValue;
        Destroy(gameObject);
    }
    
  
}
