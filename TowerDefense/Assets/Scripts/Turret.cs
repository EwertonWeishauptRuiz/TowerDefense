﻿ using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    Transform target, turret;

    public float range, lockSpeed;
    
	// Use this for initialization
	void Start () {
		turret = gameObject.transform.GetChild(0);        
        // Search for a target every .5 seconds
		InvokeRepeating("UpdateTarget", 0, .5f);
	}
	
    void UpdateTarget(){
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float smallestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;
        
        foreach (GameObject enemy in enemies) {
            float disToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(disToEnemy < smallestDistance){
                smallestDistance = disToEnemy;
                closestEnemy = enemy;
            }
        }
        
        if(closestEnemy != null && smallestDistance <= range){
            target = closestEnemy.transform;
        } else {
            target = null;
        }
    }
    
	// Update is called once per frame
	void Update () {
		if(target == null){
            // Should Reset the rotation of the turret to the initial rotation. 
            return;
        }
        // Get the direction by subtracting the target pos - turret pos
        Vector3 targetDir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(targetDir);
        // Applies lerp so the lock on target is not instantanious 
        Vector3 targetRot = Quaternion.Lerp(turret.rotation, lookRotation, Time.deltaTime * lockSpeed).eulerAngles;
        //If rotation is not being applied properly check the child object for how he is rotate
        //in global position and change it
        turret.transform.rotation = Quaternion.Euler(0, targetRot.y, 0);
	}

    void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.color = Color.red;
    }
}
