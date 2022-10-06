using UnityEngine;

public class BalloonDestroyer : MonoBehaviour
{
    public string baloonTag;
    public string enemyTag;
    public string healthBaloonTag;
    private int rayControl = 0;
    public Camera mainCamera;
    private GameManager _gameManager;
    public GameObject explosion,healthExplosion,enemyExplosion;
    public LayerMask targetLayer;
    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0)&&rayControl<=5)
        {
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Input.mousePosition),Mathf.Infinity,targetLayer);
            rayControl++;
            if (rayHit.collider != null)
            {
                
                if (rayHit.collider.gameObject.CompareTag(baloonTag))
                {
                    if (_gameManager.pauseControl == 0)
                    {
                        _gameManager.totalScore();
                        Destroy(
                            Instantiate(explosion, rayHit.collider.gameObject.transform.position, Quaternion.identity),
                            1f);
                        Destroy(rayHit.collider.gameObject);
                    }
                }   
                else if (rayHit.collider.gameObject.CompareTag(enemyTag))
                {
                    if (_gameManager.pauseControl == 0)
                    {
                        _gameManager.health -= 2;
                        Destroy(
                            Instantiate(enemyExplosion, rayHit.collider.gameObject.transform.position, Quaternion.identity),
                            1f);
                        Destroy(rayHit.collider.gameObject);
                    }
                }
                else if (rayHit.collider.gameObject.CompareTag(healthBaloonTag))
                {
                    if (_gameManager.pauseControl == 0)
                    {
                        _gameManager.health += 1;
                        Destroy(
                            Instantiate(healthExplosion, rayHit.collider.gameObject.transform.position, Quaternion.identity),
                            1f);
                        Destroy(rayHit.collider.gameObject);
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            rayControl = 0;
        }
    }
}