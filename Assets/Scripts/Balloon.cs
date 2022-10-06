using System;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Balloon : MonoBehaviour
{
    private GameManager _gameManager;
    private volumeSetting _volumeSetting;
    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, _gameManager.speed * Time.deltaTime * 10));
        if (_gameManager.health <= 0)
        {
            _gameManager.health = 5;
            SceneManager.LoadScene(2);
        }
        _gameManager.BalonSpeed();
    }
    

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Barrier")
        {
            Destroy(gameObject);
            _gameManager.Health();
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag=="enemyBaloon")
            Destroy(gameObject);
        if(col.gameObject.tag=="healthBaloon")
            Destroy(gameObject);
    }
}