using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BalloonInstantiate : MonoBehaviour
{
    public GameObject balloon,enemyBalloon,healthBalloon;
    private float balloonInstantiateTime = 0.7f;
    private float time = 0f;
    private int randomBalloon;
    private int randomHealthBalloon;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        randomBalloon = Random.Range(1, 9);
        randomHealthBalloon = Random.Range(1, 10);
        time -= Time.deltaTime;
        if (time < 0)
        {
            balloonInstantiate();
            enemyBaloonInstantiate();
            healthBaloonInstaniate();
            time = balloonInstantiateTime;
        }
    }

    void balloonInstantiate()
    {
        float x = Random.Range(-2f, 2f);
        Instantiate(balloon, new Vector3(x,-7f,0),Quaternion.identity);
    }

    void enemyBaloonInstantiate()
    {
        if (randomBalloon == 2)
        {
            float x = Random.Range(-2f, 2f);
            Instantiate(enemyBalloon, new Vector3(x,-7f,0),Quaternion.identity);
        }
    }

    void healthBaloonInstaniate()
    {
        if (randomHealthBalloon == 4 && _gameManager.health < 5)
        {
            float x = Random.Range(-2f, 2f);
            Instantiate(healthBalloon, new Vector3(x,-7f,0),Quaternion.identity);
        }
    }


}
