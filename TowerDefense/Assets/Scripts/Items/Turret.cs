 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    Transform target, turret;

    public Transform firePoint;
    
    public float range, lockSpeed, fireRate;

    float fireCountdown;

    [Header("Laser Properties")]
    public bool useLaser;
    LineRenderer lineRenderer;

    public GameObject bullet;
    
    
	// Use this for initialization
	void Start () {
        if(useLaser){
            lineRenderer = GetComponent<LineRenderer>();
        }
    
		turret = gameObject.transform.GetChild(0);    
// Old getting the firepoitn by child....change i again to get it programatically, not as a public        
//        firePoint = gameObject.transform.GetChild(1);        
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
            if(useLaser){
                if(lineRenderer.enabled){
                    lineRenderer.enabled = false;
                }
            }
            // Should Reset the rotation of the turret to the initial rotation. 
            return;
        }

        LockOnTarget();
        
        if(useLaser){
            ShootLaser();
        } else {
			if(fireCountdown <= 0){
				Shoot();
				// Divide the second by fire rate
				fireCountdown = 1 / fireRate;
			}
			
			fireCountdown -= Time.deltaTime;        
        }
        
	}

    void LockOnTarget(){
        // Get the direction by subtracting the target pos - turret pos
        Vector3 targetDir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(targetDir);
        // Applies lerp so the lock on target is not instantanious 
        Vector3 targetRot = Quaternion.Lerp(turret.rotation, lookRotation, Time.deltaTime * lockSpeed).eulerAngles;
        //If rotation is not being applied properly check the child object for how he is rotate
        //in global position and change it
        turret.transform.rotation = Quaternion.Euler(0, targetRot.y, 0);
    }

    void ShootLaser(){
        if(!lineRenderer.enabled){
            lineRenderer.enabled = true;
        }
        lineRenderer.SetPosition(0, firePoint.transform.position);
        lineRenderer.SetPosition(1, target.transform.position);
    }

    void Shoot(){
        GameObject bulletGO = Instantiate(bullet, firePoint.position, firePoint.rotation);
        Bullet bulletBehaviour = bulletGO.GetComponent<Bullet>();
        
        if(bullet == null){
            return;
        }
        bulletBehaviour.Seek(target);        
    }

    void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.color = Color.red;
    }
}
