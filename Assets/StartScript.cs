using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	  
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // On hover, change color
    public void OnHoverEnter()
    {
        Text _thisText = gameObject.GetComponentInChildren<Text>();
        _thisText.color = new Color(1.0f, 163f/255f, 0.0f );

    }

    // When not hovering, return color
    public void OnHoverExit()
    {
        Text _thisText = gameObject.GetComponentInChildren<Text>();
        _thisText.color = new Color(96f/255f, 96f/255f, 96f/255f);
    }

    // On click, load game
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}
