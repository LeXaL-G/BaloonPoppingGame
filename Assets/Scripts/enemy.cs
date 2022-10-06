using System;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,_gameManager.speed*Time.deltaTime*10));

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Barrier")
        {
            Destroy(gameObject);
        }
    }
}