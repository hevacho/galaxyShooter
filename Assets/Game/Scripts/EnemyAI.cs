using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private float speed= 3f;
    private Animator animator;

    [SerializeField]
    private GameObject enemyExplosionPrefaf;

    private UIManager _uIManager;
    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(666);
        animator = GetComponent<Animator>();
        _uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_uIManager != null)
        {
            _uIManager.UpdateScore(0);
        }

        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameManager.isGameOver())
        {
            Destroy(gameObject);
        }

        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if(transform.position.y < -7)
        {
            respawnEnemy();
        }
        
    }

    private void respawnEnemy()
    {
      float x =  Random.Range(-8.5f, 8.5f);
      this.transform.position = new Vector3(x, 11f);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();

            }
            _uIManager.UpdateScore(5);
            Instantiate(enemyExplosionPrefaf, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }else if (collision.CompareTag("Laser"))
        {
            _uIManager.UpdateScore(10);
            Destroy(collision.gameObject);
            Destroy(Instantiate(enemyExplosionPrefaf, transform.position, Quaternion.identity), 10);
            Destroy(this.gameObject);

        }
        
    }
}
