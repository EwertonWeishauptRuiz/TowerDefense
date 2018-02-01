using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine;

public class NodeBehaviour : MonoBehaviour {

    public Color hoverColor;
    Color startColor;
    Renderer rend;
    
    GameObject currObject;

    ItemManager itemManager;
	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        itemManager = ItemManager.instance;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnMouseDown(){
        if(EventSystem.current.IsPointerOverGameObject()){
            // Avoid Clicking in something that is not the canvas. 
            return;
        }
        
        if(itemManager.GetObjectToBuild() == null){
            return;
        }    

        if(currObject != null){
            print("It already have ab object placed");
            return;
        }

        GameObject objectToBuild = itemManager .GetObjectToBuild();
        Vector3 offset = new Vector3(0, 0.5f, 0);
    
        currObject = Instantiate(objectToBuild, transform.position + offset, transform.rotation);
        print("You can place");
    }
    
    void OnMouseEnter(){
        if(EventSystem.current.IsPointerOverGameObject()){
            // Avoid Clicking in something that is not the canvas. 
            return;
        }        
        if(itemManager.GetObjectToBuild() == null){
            // If no object to build is selected, do not highlight the node.
            return;
        }
            
        rend.material.color = hoverColor;        
    }

    void OnMouseExit(){
        rend.material.color = startColor;    
    }
}
