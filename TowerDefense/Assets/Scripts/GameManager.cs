using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    bool gameOver;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(gameOver){
            return;
        }
        
        if(PlayerManager.lives < 0){
            EndGame();
        }		
	}
    
    void EndGame(){
        gameOver = true;
        print("GameOver");
    }
}
