using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLines_Level02 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.parent.GetComponent<PlayerMovement>().enabled = false;
        Invoke("EnableStartPlayerLine1", 1f);
        gameObject.transform.parent.GetComponent<SpriteRenderer>().flipX = true;
    }

    public void EnableStartPlayerLine1()
    {
        gameObject.transform.parent.GetComponent<SpriteRenderer>().flipX = false;
        gameObject.transform.Find("StartPlayerLine1").GetComponent<Text>().enabled = true;
        Invoke("EnableStartPlayerLine2", 4f);
    }

    public void EnableStartPlayerLine2()
    {
        gameObject.transform.parent.GetComponent<SpriteRenderer>().flipX = true;
        gameObject.transform.Find("StartPlayerLine1").GetComponent<Text>().enabled = false;
        gameObject.transform.Find("StartPlayerLine2").GetComponent<Text>().enabled = true;
        Invoke("EnableStartPlayerLine3", 4f);
    }

    public void EnableStartPlayerLine3()
    {
        gameObject.transform.parent.GetComponent<SpriteRenderer>().flipX = false;
        gameObject.transform.Find("StartPlayerLine2").GetComponent<Text>().enabled = false;
        gameObject.transform.Find("StartPlayerLine3").GetComponent<Text>().enabled = true;
        Invoke("DisableStartPlayerLine", 5f);
    }

    public void DisableStartPlayerLine()
    {
        gameObject.transform.Find("StartPlayerLine3").GetComponent<Text>().enabled = false;
        gameObject.transform.parent.GetComponent<PlayerMovement>().enabled = true;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
