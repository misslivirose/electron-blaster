using UnityEngine;
using System.Collections;

public class MoleScript : MonoBehaviour {

    public GameController _controller;
    public AudioClip _deathSound, _lifeSound;

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

    // On Collision Enter
    void OnCollisionEnter(Collision col)
    {
        isInFocus = true;
    }

    // On Collision Exit
    void OnCollisionExit(Collision col)
    {
        isInFocus = false;
    }

    // Generate the hit and return to out of focus
    void GenerateHit()
    {
        _controller.SendMessage("UpdateScore");
        isInFocus = false;
    }

    // Play death sound
    public void PlayDeathSound()
    {
        gameObject.GetComponent<AudioSource>().clip = _deathSound;
        gameObject.GetComponent<AudioSource>().Play();
    }

    // Play awake sound
    public void PlayAwakeSound()
    {
        gameObject.GetComponent<AudioSource>().clip = _lifeSound;
        gameObject.GetComponent<AudioSource>().Play();
    }
}
