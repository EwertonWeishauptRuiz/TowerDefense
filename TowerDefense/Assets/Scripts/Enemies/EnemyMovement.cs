using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyBehaviour))]
public class EnemyMovement : MonoBehaviour {
    Transform target;
    int wavePointIndex;

    

    EnemyBehaviour enemyBehaviour;

    // Use this for initialization
    void Start () {
        // Get the first point in the Index
        target = Waypoints.waypoints[0];

        enemyBehaviour = GetComponent<EnemyBehaviour>();
    }
    
    void Update () {
        // Get the direction point from one point to the other
        Vector3 direction = target.position - transform.position;
        // Normalize to have always the same lenght and fixed speed
        transform.Translate(direction.normalized * enemyBehaviour.speed * Time.deltaTime, Space.World);
        
        // Check if the distance to the waypoint is small, to go the next
        if(Vector3.Distance(transform.position, target.position) <= 0.2f){
            NextWaypoint();
        }

        // If turret is not slowing the enemy, the enemy gos back to normal speed.
        enemyBehaviour.speed = enemyBehaviour.startSpeed;
    }
    
    void NextWaypoint() {
        if(wavePointIndex >= Waypoints.waypoints.Length - 1){
            ReachedEndLevel();
            return;
        }
    
        wavePointIndex++;
        target = Waypoints.waypoints[wavePointIndex];
    }
    
    void ReachedEndLevel(){
        PlayerManager.lives -= enemyBehaviour.enemyValue;
        EnemySpawner.enemiesAlive--;    
        Destroy(gameObject);
    } 
}
