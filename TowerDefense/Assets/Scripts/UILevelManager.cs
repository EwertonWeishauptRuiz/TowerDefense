using UnityEngine.UI;
using UnityEngine;

public class UILevelManager : MonoBehaviour {

    public Text currencyDisplay, livesDisplay;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        currencyDisplay.text = "$" + PlayerManager.currency.ToString();
        livesDisplay.text = PlayerManager.lives.ToString();
	}
}
