using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speak : MonoBehaviour {

    public GameObject player;
    public string[] dialogues;

    private bool canSpeak = false;
    private bool displayMessage = false;
    private int currMessage = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (canSpeak)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (currMessage == 0 && Mathf.Abs(Mathf.Abs(player.transform.position.x) - Mathf.Abs(transform.localPosition.x)) < 0.5f)
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
    // PROPERTIES - Determines if a character is allowed to speak
    public bool getCanSpeak()
    {
        return canSpeak;
    }

    public void setCanSpeak(bool value)
    {
        canSpeak = value;
    }

    public GameObject getPlayer()
    {
        return player;
    }

    public void setPlayer(GameObject p)
    {
        player = p;
    }
}
