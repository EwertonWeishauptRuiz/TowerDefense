using UnityEngine;

public class ItemManager : MonoBehaviour {

    // Stores a reference to itself.
    public static ItemManager instance;

    void Awake() {
        if(instance != null){
            Debug.LogError("More than one build manager in scene");             
            return;
        }    
        // Everytime the game starts, it will have a reference to itself
        // which can be accessed from everywhere
        instance = this;
    }
       
	ItemBlueprint itemSelected;

    public bool CanBuild { 
        // Allows the function to only check if player can build something
        get { 
            return itemSelected != null; 
        } 
    } 
    
    public bool HasCurrency{
        get {
            return PlayerManager.currency >= itemSelected.cost;
        }  
    }
    
    public void BuildTurret(NodeBehaviour node){
        if(PlayerManager.currency < itemSelected.cost){
            print("No money to buy");
            return;
        }
        // Subtract the value of the item from the player currency
        PlayerManager.currency -= itemSelected.cost;
    
        // Instantiate the object
        GameObject item = Instantiate(itemSelected.prefab, node.GetBuildPosition(), node.transform.rotation);
        node.selectedItem = item;
        
        // Add particles and sound for placement of items
        
        print("Turret build" +" money left: " + PlayerManager.currency);
    }
   
    public void SelectTurret(ItemBlueprint item){
        itemSelected = item;
    }
    
}
