using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class NodeUI : MonoBehaviour {

    GameObject canvas;
    [Header("Upgrade")]
    public Text upgradeCost;
    public Button upgradeButton;
    
    [Header("Sell")]
    public Text sellCost;
    public Button sellButton;

    NodeBehaviour node;
    
    void Start(){
        canvas = transform.GetChild(0).gameObject;
        canvas.SetActive(false);        
    }
    
    void Update(){
        if(!canvas.activeInHierarchy){
            print("Canvas not active"); 
            return;
        }        

        if(PlayerManager.currency < node.itemBlueprint.upgradeCost){
            upgradeButton.interactable = false;
        } else {
            upgradeButton.interactable = true;
        } 

    }
    
    public void SetTarget(NodeBehaviour target){
        node = target;
        // Puts the UI in the correct position
        transform.position = target.GetBuildPosition();

        upgradeCost.text = "$" + node.itemBlueprint.upgradeCost.ToString();
                
        canvas.SetActive(true);
    }
    
    public void Hide(){
        canvas.SetActive(false);   
    }
    
    public void Upgrade(){
       node.UpdgradeTurret();
       // Deselects the node.
       ItemManager.instance.DeselectNode();
    }
}
