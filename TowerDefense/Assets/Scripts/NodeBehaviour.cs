using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine;

public class NodeBehaviour : MonoBehaviour {

    public Color hoverColor, noCurrencyColor;
    Color startColor;
    Renderer rend;
    
    [HideInInspector]
    public GameObject selectedItem;
    [HideInInspector]
    public ItemBlueprint itemBlueprint;
    [HideInInspector]
    public bool isUpgraded;

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
        
        // if there is a turrent in this node
        if(selectedItem != null){
            // Passes the node as the selected node
            itemManager.SelectNode(this);
            print("It already have ab object placed");
            return;
        }

		if(!itemManager.CanBuild){
			return;
		}
        // Gets a reference of object to build    
        BuildObject(itemManager.GetObjectToBuild());
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
    
    void BuildObject(ItemBlueprint iBlueprint){
        if(PlayerManager.currency < iBlueprint.cost){
            print("No money to buy");
            return;
        }
        // Subtract the value of the item from the player currency
        PlayerManager.currency -= iBlueprint.cost;
        
        //Passes to the blueprint, the current item
        itemBlueprint = iBlueprint;
    
        // Instantiate the object
        GameObject objectSelected = Instantiate(iBlueprint.prefab, GetBuildPosition(), transform.rotation);
        selectedItem = objectSelected;

        // Add particles and sound for placement of items

        print("Turret build");
    }
    
    public void UpdgradeTurret(){
        if(PlayerManager.currency < itemBlueprint.upgradeCost){
            print("No money to upgrade");
            return;
        }
        //Destroy the old turret
        Destroy(selectedItem);
        
        // Subtract the value of the item from the player currency
        PlayerManager.currency -= itemBlueprint.upgradeCost;
    
        // Instantiate the Upgraded object
        GameObject objectSelected = Instantiate(itemBlueprint.upgradedPrefab, GetBuildPosition(), transform.rotation);
        selectedItem = objectSelected;        

        // Add particles and sound for placement of items

		isUpgraded = true;
        print("Turret Upgraded");
    }
}
