using UnityEngine;
using System.Collections;

public class MoleScript : MonoBehaviour {

    public GameController _controller;
    bool isInFocus = false;
    Color inFocusColor = new Color(0.0f, 1.0f, 1.0f);
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
                CheckIfHit();
            }
        }
	}

    // On Trigger Enter
    void OnCollisionEnter(Collision col)
    {
        PlaceInFocus();
    }

    // On Trigger Exit
    void OnCollisionExit(Collision col)
    {
        RemoveFocus();
    }

    // When pointer enters, is in focus
    public void PlaceInFocus()
    {
        isInFocus = true;
        gameObject.GetComponent<MeshRenderer>().material.color = inFocusColor;
    }

    // When pointer exits, is not in focus
    public void RemoveFocus()
    {
        isInFocus = false;
        gameObject.GetComponent<MeshRenderer>().material.color = outFocusColor;
    }

    // On pointer click, test if in focus
    public void CheckIfHit()
    {            
            _controller.SendMessage("UpdateScore");
    }
}
