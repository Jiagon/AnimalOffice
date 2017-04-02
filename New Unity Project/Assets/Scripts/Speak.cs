using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speak : MonoBehaviour {

    public GameObject player;
    public string[] dialogues;

    private bool canSpeak = false;
    private bool displayMessage = false;
    private int currMessage = 0;
    private float playerX;
    private string message;
    private bool hasSpoken = false;

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
        if (displayMessage)
        {
            player.transform.position.Set(playerX, player.transform.position.y, player.transform.position.z);
        }

    }

    void OnGUI()
    {
        if(displayMessage)
        {
            GUI.Box(new Rect(0, Screen.height - 100f, Screen.width, 40f), message);
            hasSpoken = true;
        }
    }

    void ChangeDisplayMessage()
    {
        displayMessage = !displayMessage;
        if (displayMessage)
        {
            player.GetComponent<ProtagMovement>().setFrozen(true);
        }
        else
        {
            player.GetComponent<ProtagMovement>().setFrozen(false);
        }
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

    public void setMessage(string msg)
    {
        message = msg;
    }
    
    public void setHasSpoken(bool value)
    {
        hasSpoken = value;
    }

    public bool getHasSpoken()
    {
        return hasSpoken;
    }
}
