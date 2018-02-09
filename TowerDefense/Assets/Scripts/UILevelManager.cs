using UnityEngine.UI;
using UnityEngine;

public class UILevelManager : MonoBehaviour {

    public Text currencyDisplay, livesDisplay;

	// Update is called once per frame
	void Update () {
        currencyDisplay.text = "$" + PlayerManager.currency.ToString();
        livesDisplay.text = PlayerManager.lives.ToString();
	}
}
