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

    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(42);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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
            Instantiate(enemyExplosionPrefaf, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }else if (collision.CompareTag("Laser"))
        {
            Destroy(collision.gameObject);
            Instantiate(enemyExplosionPrefaf, transform.position, Quaternion.identity);
            Destroy(this.gameObject);

        }
        
    }
}
