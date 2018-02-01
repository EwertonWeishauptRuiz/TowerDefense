using UnityEngine;

public class Bullet : MonoBehaviour {

    Transform target;
    public float speed = 70;
    
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
	}
    
    void Hit(){
        // Instantiate Particles here
        //Video 5 for reference
        Destroy(gameObject);
    }
}
