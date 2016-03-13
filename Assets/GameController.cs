using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    // Public variables - set in scene inspector
    public int _score = 0;
    public Text _scoreText, _countdownText;
    public ParticleSystem _particles;
    public GameObject moleObject;

    float timeFromLastSpawn = 0.0f;
    float masterTimer = 0.0f;

    

	// Use this for initialization
	void Start () {
        StartCoroutine(RunCountdown());
        BeginGame();
         
	}

    // Count Down from 3 to 0
    IEnumerator RunCountdown()
    {
        yield return new WaitForSeconds(1);
        _countdownText.text = "2";
        yield return new WaitForSeconds(1);
        _countdownText.text = "1";
        yield return new WaitForSeconds(1);
        _countdownText.fontSize = 10;
        _countdownText.text = "Go!";
        yield return new WaitForSeconds(1);
        _countdownText.enabled = false;

    }

    // Renable the capsule and start the game timer
    void BeginGame()
    {
        moleObject.SetActive(true);
    }

    // Update is called once per frame
    void Update () {

        timeFromLastSpawn += Time.smoothDeltaTime;
        if(timeFromLastSpawn >= 10.0f)
        {
            PositionMole();
            timeFromLastSpawn = 0.0f;
        }
        masterTimer += Time.smoothDeltaTime;
        
	}

    // Update Score
    public void UpdateScore()
    {
        StartCoroutine( PlayEffect());
        _score++;
        _scoreText.text = _score.ToString();

    }
    // Play the smack effect
    IEnumerator PlayEffect()
    {
        _particles.Emit(1);
        yield return new WaitForSeconds(1);
        PositionMole();

    }

    // Position the next mole
    // Radius = 5
    void PositionMole()
    {
        float angle = Random.Range(0.0f, 2*Mathf.PI);

        float xPos = 6f * Mathf.Sin(angle);
        float zPos = 6f * Mathf.Cos(angle);

        Vector3 _newLocation = new Vector3(xPos, 1.83f, zPos);
        Debug.Log("Location: " + _newLocation);
        GameObject.FindGameObjectWithTag("mole").transform.position = _newLocation;
        GameObject.FindGameObjectWithTag("mole").transform.LookAt(new Vector3(0.0f, 0.0f, 0.0f));
        timeFromLastSpawn = 0.0f;     
    }
   
}
