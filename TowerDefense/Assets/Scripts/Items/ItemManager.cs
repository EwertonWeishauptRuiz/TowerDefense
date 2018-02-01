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
    
	public GameObject basicTurret, secondTurret;
       
    GameObject objectToBuild;

    public GameObject GetObjectToBuild(){
        return objectToBuild;
    }
    
    public void CurrentObjectToBuild(GameObject selectedObject){
        objectToBuild = selectedObject;
    }
    
}
