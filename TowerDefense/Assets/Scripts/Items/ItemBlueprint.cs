using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemBlueprint{

    public GameObject prefab, upgradedPrefab;
    public int cost, upgradeCost;
    
    
    public int SellAmount(){
        return cost / 2;
    }
    // Change here to an upgrade system that improves the range and damage of each item
}
