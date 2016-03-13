using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    // Public variables - set in scene inspector
    public int _score = 0;
    public Text _scoreText, _countdownText;
    public ParticleSystem _particles;
    public GameObject moleObject;

    // Private variables - specified here
    float timeFromLastSpawn = 0.0f;
    float masterTimer = 90.0f;
    bool masterTimerRunning = false;

    // Alert remaining time variables
    bool _minuteMark = false;
    bool _halfMinuteMark = false;
    bool _tenSecondCountDown = false;
    bool _finished = false;

	// Use this for initialization
	void Start () {
        StartCoroutine(RunCountdown());
         
	}

    // Count Down from 3 to 0, then trigger game start
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
        BeginGame();
    }

    // Renable the capsule and start the game timer
    void BeginGame()
    {
        masterTimerRunning = true;
        moleObject.SetActive(true);
    }

    // Update is called once per frame
    void Update () {
        if(!_finished)
        {
            timeFromLastSpawn += Time.deltaTime;
            if (timeFromLastSpawn >= 10.0f)
            {
                PositionMole();
                timeFromLastSpawn = 0.0f;
            }
            if (masterTimerRunning)
            {
                masterTimer -= Time.deltaTime;
                // 60 second mark
                if (!_minuteMark & masterTimer <= 65 )
                {
                    Debug.Log("Minute warning");
                    _minuteMark = true;
                }
                // 30 second mark
                else if (!_halfMinuteMark & masterTimer <= 35)
                {
                    Debug.Log("Half Minute Warning");
                    _halfMinuteMark = true;
                }
                else if (!_finished & masterTimer <= 0)
                {
                    _finished = true;
                    masterTimerRunning = false;
                    _countdownText.text = _score.ToString();
                    _countdownText.enabled = true;
                    Destroy(moleObject);
                }
            }
        }
 
	}

    // Update Score
    public void UpdateScore()
    {
        if(!_finished)
        {
            StartCoroutine(PlayEffect());
            _score++;
            _scoreText.text = _score.ToString();
        }
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
        GameObject.FindGameObjectWithTag("mole").transform.position = _newLocation;
        GameObject.FindGameObjectWithTag("mole").transform.LookAt(new Vector3(0.0f, 0.0f, 0.0f));
        timeFromLastSpawn = 0.0f;     
    }
   
}
