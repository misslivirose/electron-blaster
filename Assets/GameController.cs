using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    public int _score = 0;
    public Text _scoreText;
    public ParticleSystem _particles;

    float timeFromLastSpawn = 0.0f;

	// Use this for initialization
	void Start () {
        // Count down 3 - 2 - 1
             
	}
	
	// Update is called once per frame
	void Update () {

        timeFromLastSpawn += Time.deltaTime;
        if(timeFromLastSpawn >= 10.0f)
        {
            PositionMole();
            timeFromLastSpawn = 0.0f;
        }
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
