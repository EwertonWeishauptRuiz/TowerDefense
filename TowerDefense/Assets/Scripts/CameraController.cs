using UnityEngine;

public class CameraController : MonoBehaviour {

    bool cameraMove = true;

    public float panSpeed = 30f;
    public float panBorderThickness = 10;
    public float scrollSpeed = 5;

    public float minY = 10;
    public float maxY = 50;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey(KeyCode.Escape)){
            cameraMove = !cameraMove;
        }
        
        if(!cameraMove){
            return;
        }
    
		if(Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - panBorderThickness){
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        } 
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBorderThickness){
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorderThickness){
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= panBorderThickness){
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        // Restric the position between the 2 values
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
        
	}
}
