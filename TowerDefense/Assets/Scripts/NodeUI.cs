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
            return;
        }        
        // Enable and disable the button realted to the player currency situation. 
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

        sellCost.text = "$" + node.itemBlueprint.SellAmount().ToString();        
        canvas.SetActive(true);
		// Set the radius renderer on
		node.turretBehaviour.rangeRadiusRenderer.enabled = true;
    }
    
    public void Hide(){
		canvas.SetActive(false);   
        // If there is no node, return, otherwise, set the randeRadius off.
        if(node == null){
            return;
        }        
        node.turretBehaviour.rangeRadiusRenderer.enabled = false;
    }
    
    public void Upgrade(){
       node.UpdgradeTurret();
       // Deselects the node.
       ItemManager.instance.DeselectNode();
    }
    
    public void Sell(){
        node.SellTurret();
        ItemManager.instance.DeselectNode();
    }
}
