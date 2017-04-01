using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speak : MonoBehaviour {

    public GameObject player;
    public string[] dialogues;

    private bool displayMessage = false;
    private int currMessage = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(currMessage == 0 && Mathf.Abs(Mathf.Abs(player.transform.position.x) - Mathf.Abs(transform.localPosition.x)) < 1.0f)
            {
                ChangeDisplayMessage();
            }
        }
        if (Mathf.Abs(Mathf.Abs(player.transform.position.x) - Mathf.Abs(transform.localPosition.x)) > 1.0f)
        {
            displayMessage = false;
            currMessage = 0;
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
