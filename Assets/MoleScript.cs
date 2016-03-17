using UnityEngine;
using System.Collections;

public class MoleScript : MonoBehaviour {

    public GameController _controller;

    bool isInFocus = false;
    Color inFocusColor = new Color(.2f, .2f, 0.2f);
    Color outFocusColor = new Color(0.0f, 0.0f, 160.0f/255.0f);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetMouseButtonUp(0))
        {
            if(isInFocus)
            {
                GenerateHit();
            }
        }
	}

    // On Trigger Enter
    void OnCollisionEnter(Collision col)
    {
        isInFocus = true;
    }

    // On Trigger Exit
    void OnCollisionExit(Collision col)
    {
        isInFocus = false;
    }

    // On pointer click, test if in focus
    void GenerateHit()
    {
        _controller.SendMessage("UpdateScore");
    }
}
