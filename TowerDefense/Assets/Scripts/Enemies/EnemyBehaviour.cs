using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour {

    
    public float speed = 5;
    public float health; 
    public int enemyValue;
    public Image healthBar;
    
    
    [HideInInspector]
    public float startSpeed;
    [HideInInspector]
    public float startHealth;
    
    void Start(){
        startSpeed = speed;
        startHealth = health;
    }

    public void TakeDamage(float amount){
        health -= amount;

        // Takes float between 0 and 1
        healthBar.fillAmount = health / startHealth;
        print(health);
          
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
		EnemySpawner.enemiesAlive--;
        Destroy(gameObject);
    }
    
  
}
