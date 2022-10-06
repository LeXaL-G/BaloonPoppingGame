using UnityEngine;

public class healthBaloon : MonoBehaviour
{
    private GameManager _gameManager;
    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300f*Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Barrier")
        {
            Destroy(gameObject);
        }
    }
}
