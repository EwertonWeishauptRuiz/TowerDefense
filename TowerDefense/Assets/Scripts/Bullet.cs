using UnityEngine;

public class Bullet : MonoBehaviour {


    Transform target;
    public float speed = 70;
    public float explosionRadius;
	public GameObject hitEffect;

    public int damage;
    
    public void Seek(Transform _target){
        target = _target;
    }
    	
	// Update is called once per frame
	void Update () {
	    if(target == null) {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float dist = speed * Time.deltaTime;
        
        // if the lenght of the direction vector is less
        if(dir.magnitude <= dist){
            Hit();
            return;
        }
        // Normalized to make sure how close we are to the target does not affect the speed.
        transform.Translate(dir.normalized * dist, Space.World);
        // Rotate the Bullet to focus on the target.
        transform.LookAt(target);
	}
    
    void Hit(){
        // Instantiate Particles here
        GameObject particles = Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(particles, 2);    
        // cause damage in a radius
        if(explosionRadius > 0){
            DamageRadius();            
        } else {
            Damage(target);
        }
        
        Destroy(gameObject);
    }
    
    void DamageRadius(){
        
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider colliders in hitColliders){
            if(colliders.CompareTag("Enemy")){
                Damage(colliders.transform);
            }
        }
    }
    
    void Damage(Transform enemy){
        // Damages the enemies
        EnemyBehaviour enemybehaviour = enemy.GetComponent<EnemyBehaviour>();
        
        if(enemybehaviour != null){
            enemybehaviour.TakeDamage(damage);
        }
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
