using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speak : MonoBehaviour {

    public GameObject speaker1 = null;
    public GameObject speaker2 = null;

    private bool displayMessage = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(speaker1 != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                displayMessage = true;
            }
        }
        if (speaker2 != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                displayMessage = true;
            }
        }

        if (displayMessage)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                displayMessage = false;
            }
        }

        while (!Input.GetKeyUp(KeyCode.Space)) ;
        {

        }

    }

    void OnGUI()
    {
        if(displayMessage)
        {
            GUI.Label(new Rect(10f, 10f, 100f, 20f), "Testing");
        }
    }
}
