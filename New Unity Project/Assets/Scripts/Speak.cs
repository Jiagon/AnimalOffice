using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum kpState
{
    down,
    up,
}

public class Speak : MonoBehaviour {

    public GameObject speaker1 = null;
    public GameObject speaker2 = null;

    private bool displayMessage = false;
    private kpState keyState = kpState.up;
    private kpState previousKeyState = kpState.up;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeDisplayMessage();
            /*if (speaker1 != null)
            {
                ChangeDisplayMessage();
            }
            else if (speaker2 != null)
            {
                ChangeDisplayMessage();
            }*/
        }

    }

    void OnGUI()
    {
        if(displayMessage)
        {
            GUI.Box(new Rect(Screen.width / 2, Screen.height - 50f, 100f, 40f), "Testing");
        }
    }

    void ChangeDisplayMessage()
    {
        displayMessage = !displayMessage;
    }
}
