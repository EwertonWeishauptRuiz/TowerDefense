using UnityEngine;

public class ItemShop : MonoBehaviour {

    public ItemBlueprint standardTurret, 
                        secondaryTurret, 
                        laserBeamTurret,
                        towerBase;
    

    ItemManager itemManager;
    
    void Start(){
        itemManager = ItemManager.instance;
    }
    
    public void SelectTower(){
        itemManager.SelectObject(towerBase);
    }

    public void SelectBasicTurret(){        
        itemManager.SelectObject(standardTurret);
    }   
    
     public void SelectSecondaryTurret(){        
        itemManager.SelectObject(secondaryTurret);
    } 
     
    public void SelectLaserBeam(){        
        itemManager.SelectObject(laserBeamTurret);
    } 
}
