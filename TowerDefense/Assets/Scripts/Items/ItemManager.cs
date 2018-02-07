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
       
	// Item selected to build
    ItemBlueprint itemToBuild;

    NodeBehaviour selectedNode;

    public NodeUI nodeUI;
    
    public bool CanBuild { 
        // Allows the function to only check if player can build something
        get { 
            return itemToBuild != null; 
        } 
    } 
    
    public bool HasCurrency{
        get {
            return PlayerManager.currency >= itemToBuild.cost;
        }  
    }
   
    // Find the selected node
    public void SelectNode(NodeBehaviour node){
        if(selectedNode == node){
            DeselectNode();
            return;
        }
        
        selectedNode = node;
        itemToBuild = null;

        nodeUI.SetTarget(node);
    }
    
    public void DeselectNode(){
        selectedNode = null;
        nodeUI.Hide();
    }
   
    public void SelectTurret(ItemBlueprint item){
        itemToBuild = item;
        DeselectNode();
    }
    
    public ItemBlueprint GetObjectToBuild(){
        return itemToBuild;
    }
}
