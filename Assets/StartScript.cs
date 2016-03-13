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
        Debug.Log("HoverEnter");

        Text _thisText = gameObject.GetComponentInChildren<Text>();
        _thisText.color = Color.blue;
        
    }

    // When not hovering, return color
    public void OnHoverExit()
    {
        Text _thisText = gameObject.GetComponentInChildren<Text>();
        _thisText.color = new Color(0.0f, 1.0f, 1.0f);
    }

    // On click, load game
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}
