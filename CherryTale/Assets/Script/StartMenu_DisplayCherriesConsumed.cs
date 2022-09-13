using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu_DisplayCherriesConsumed : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Text>().text = "Cherries consumed: " + PlayerPrefs.GetInt("CoinAmount");
    }

    
}
