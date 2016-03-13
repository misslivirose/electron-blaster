using UnityEngine;
using System.Collections;

public class GlobalAudioScript : MonoBehaviour {

    public AudioSource _globalSource;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Play Sound
    public void PlaySound(AudioClip _soundToPlay)
    {
        _globalSource.clip = _soundToPlay;
        _globalSource.Play();
    }
}
