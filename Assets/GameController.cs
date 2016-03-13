using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class GameController : MonoBehaviour {

    // Public variables - set in scene inspector
    public int _score = 0;
    public Text _scoreText, _countdownText;
    public ParticleSystem _particles;
    public GameObject moleObject;

    public GlobalAudioScript _globalSound;
    public AudioClip _60SecondSound, _30SecondSound, _countdownSound, _321, _go, _laser, _hit;
    public Material _sky;

    // Private variables - specified here
    float timeFromLastSpawn = 0.0f;
    float masterTimer = 90.0f;
    bool masterTimerRunning = false;
    AudioSource _source;
    float _skyRotation = 0.0f;

    // Alert remaining time variables
    bool _minuteMark = false;
    bool _halfMinuteMark = false;
    bool _tenSecondCountDown = false;
    bool _finished = false;

	// Use this for initialization
	void Start () {

        _source = gameObject.GetComponent<AudioSource>();

        // Run the countdown
        StartCoroutine(RunCountdown());
        ApplyDangerEffect();
	}

    // Count Down from 3 to 0, then trigger game start
    IEnumerator RunCountdown()
    {
       
        _globalSound.SendMessage("PlaySound", _321);

        yield return new WaitForSeconds(1);
        _countdownText.text = "2";
        _globalSound.SendMessage("PlaySound", _321);

        yield return new WaitForSeconds(1);
        _countdownText.text = "1";
        _globalSound.SendMessage("PlaySound", _321);


        yield return new WaitForSeconds(1);
        _countdownText.fontSize = 10;
        _countdownText.text = "Go!";
        _globalSound.SendMessage("PlaySound", _go);


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
                    _globalSound.SendMessage("PlaySound", _60SecondSound);
                    _minuteMark = true;
                }
                // 30 second mark
                else if (!_halfMinuteMark & masterTimer <= 35)
                {
                    _globalSound.SendMessage("PlaySound", _30SecondSound);
                    _halfMinuteMark = true;
                }
                // 10 second mark
                else if(!_tenSecondCountDown & masterTimer <= 12)
                {
                    _globalSound.SendMessage("PlaySound", _countdownSound);
                    _tenSecondCountDown = true;

                }
                // Game is finished
                else if (!_finished & masterTimer <= 0)
                {
                    _finished = true;
                    masterTimerRunning = false;
                    _countdownText.text = _score.ToString();
                    _countdownText.enabled = true;
                    Destroy(moleObject);
                    StartCoroutine(ResetGame());
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
        _source.clip = _laser;
        _source.Play();
        yield return new WaitForSeconds(1);
        PositionMole();

    }

    // Position the next mole
    // Radius = 5
    void PositionMole()
    {
        _source.clip = _hit;
        _source.Play();

        float angle = Random.Range(0.0f, 2*Mathf.PI);

        float xPos = 6f * Mathf.Sin(angle);
        float zPos = 6f * Mathf.Cos(angle);

        Vector3 _newLocation = new Vector3(xPos, 1.83f, zPos);
        GameObject.FindGameObjectWithTag("mole").transform.position = _newLocation;
        GameObject.FindGameObjectWithTag("mole").transform.LookAt(new Vector3(0.0f, 0.0f, 0.0f));
        timeFromLastSpawn = 0.0f;     
    }

    // Wait for 10 seconds, then return to the home screen
    IEnumerator ResetGame()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(0);
    }

    // Flash material walls to red 
    void ApplyDangerEffect()
    {
        
        _sky.SetColor("_TintColor", Color.red);
        Debug.Log(_sky.ToString());
    }
    
   
}
