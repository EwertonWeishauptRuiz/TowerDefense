using UnityEngine;

public class ItemShop : MonoBehaviour {

    ItemManager itemManager;
    
    void Start(){
        itemManager = ItemManager.instance;
    }

    public void SelectedBasicTurret(){
        print("Basic Turret Selected");
        itemManager.CurrentObjectToBuild(itemManager.basicTurret);
    }   
    
     public void SelectedAnotherTurret(){
        print("Second Turret Selected");
        //Change for the other object that will be available.
        //itemManager.CurrentObjectToBuild(itemManager.basicTurret);
     } 
}
