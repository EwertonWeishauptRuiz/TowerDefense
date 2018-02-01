using UnityEngine;

public class Waypoints : MonoBehaviour {
    [SerializeField]
    public static Transform[] waypoints;

	// Use this for initialization
	void Awake () {
        waypoints = new Transform[transform.childCount];
        for (int i = 0; i < waypoints.Length; i++){
            waypoints[i] = transform.GetChild(i);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
