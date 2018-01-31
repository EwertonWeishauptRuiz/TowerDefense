using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public float speed = 5;

    Transform target;
    int wavePointIndex;

	// Use this for initialization
	void Start () {
        // Get the first point in the Index
        target = Waypoints.waypoints[0];
	}
	
	// Update is called once per frame
	void Update () {
        // Get the direction point from one point to the other
        Vector3 direction = target.position - transform.position;
        // Normalize to have always the same lenght and fixed speed
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        
        // Check if the distance to the waypoint is small, to go the next
        if(Vector3.Distance(transform.position, target.position) <= 0.2f){
            NextWaypoint();
        }        
	}
    
    void NextWaypoint(){
        if(wavePointIndex >= Waypoints.waypoints.Length - 1){
            Destroy(gameObject);
        }
    
        wavePointIndex++;
        target = Waypoints.waypoints[wavePointIndex];
    }
    
}
