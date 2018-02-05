using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    //To be acessable everywhere
    public static int currency;
    public static int lives;
    
    public int startCurrency = 150;
    public int startLives;
    

	// Use this for initialization
	void Start () {
        // So the static property get rewritten and does not affect the player when scenes
        // are reloaded, carrying over the amount of money the player had before
        currency = startCurrency;
        lives = startLives;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
