using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine;

public class NodeBehaviour : MonoBehaviour {

    public Color hoverColor, noCurrencyColor;
    Color startColor;
    Renderer rend;
    [Header("Only add if a item has to be placed by the GM")]
    public GameObject selectedItem;

    ItemManager itemManager;

	void Start () {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        itemManager = ItemManager.instance;
	}
    
    public Vector3 GetBuildPosition(){
        Vector3 offset = new Vector3(0, 0.5f, 0);
        return transform.position + offset;
    }
    
    void OnMouseDown(){
        if(EventSystem.current.IsPointerOverGameObject()){
            // Avoid Clicking in something that is not the canvas. 
            return;
        }
        
        if(!itemManager.CanBuild){
            return;
        }    

        if(selectedItem != null){
            print("It already have ab object placed");
            return;
        }

        itemManager.BuildTurret(this);
    }
    
    void OnMouseEnter(){
        if(EventSystem.current.IsPointerOverGameObject()){
            // Avoid Clicking in something that is not the canvas. 
            return;
        }        
        if(!itemManager.CanBuild){
            // If no object to build is selected, do not highlight the node.
            return;
        }
        
        // Change color
        if(itemManager.HasCurrency){
			rend.material.color = hoverColor;        
        } else {
            rend.material.color = noCurrencyColor;
        }
    }

    void OnMouseExit(){
        rend.material.color = startColor;    
    }
}
