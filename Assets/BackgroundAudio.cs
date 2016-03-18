using UnityEngine;
using System.Collections;

public class BackgroundAudio : MonoBehaviour {

    private static BackgroundAudio instance = null;
    public static BackgroundAudio Instance
    {
        get { return instance; }
    }

	// Use this for initialization
	void Start () {
	    if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
