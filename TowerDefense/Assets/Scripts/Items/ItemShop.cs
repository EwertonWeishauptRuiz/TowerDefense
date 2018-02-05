using UnityEngine;

public class ItemShop : MonoBehaviour {

    public ItemBlueprint standardTurret, 
                        secondaryTurret, 
                        laserBeamTurret;
    

    ItemManager itemManager;
    
    void Start(){
        itemManager = ItemManager.instance;
    }

    public void SelectBasicTurret(){
        print("Basic Turret Selected");
        itemManager.SelectTurret(standardTurret);
    }   
    
     public void SelectSecondaryTurret(){
        print("Second Turret Selected");
        itemManager.SelectTurret(secondaryTurret);
    } 
     
    public void SelectLaserBeam(){
        print("LaserBeam Turret Selected");
        itemManager.SelectTurret(laserBeamTurret);
    } 
}
