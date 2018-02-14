using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ItemShopUI : MonoBehaviour {

    ItemShop itemShop;

    public Button towerButton, standardButton, secondaryButton, tercearyButton;
    public Text towerCost, basicCost, secondaryCost, tercearyCost;

	// Use this for initialization
	void Start () {
        itemShop = GetComponent<ItemShop>();
        towerCost.text = "$" + itemShop.towerBase.cost.ToString();
        basicCost.text = "$" + itemShop.standardTurret.cost.ToString();
        secondaryCost.text = "$" + itemShop.secondaryTurret.cost.ToString();
        tercearyCost.text = "$" + itemShop.laserBeamTurret.cost.ToString();        
	}
	
	// Update is called once per frame
	void Update () {
        CheckItemAvailability();
    }
    
    void CheckItemAvailability(){
		if(PlayerManager.currency >= itemShop.towerBase.cost){
			towerButton.interactable = true;
		} else {
			towerButton.interactable = false;
		}
		if(PlayerManager.currency >= itemShop.standardTurret.cost){
			standardButton.interactable = true;
		} else {
			standardButton.interactable = false;
		}
		if(PlayerManager.currency >= itemShop.secondaryTurret.cost){
			secondaryButton.interactable = true;
		} else {
			secondaryButton.interactable = false;
		}
		if(PlayerManager.currency >= itemShop.laserBeamTurret.cost){
			tercearyButton.interactable = true;
		} else {
			tercearyButton.interactable = false;
		}        
    }
}
