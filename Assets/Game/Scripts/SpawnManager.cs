using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject enemyShipPrefab;
    [SerializeField]
    private GameObject[] powerUps; //0 tripleshot, 1 speed, 2 shield
    
    private Player player;

    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {

        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(PowerUpSpawnRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            if (!_gameManager.isGameOver())
            {
                Instantiate(enemyShipPrefab, new Vector3(Random.Range(-8.5f, 8.5f), 11f), Quaternion.identity);
            }
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator PowerUpSpawnRoutine()
    {
        while (true)
        {
            if (!_gameManager.isGameOver())
            {
                int randomPowerUp = Random.Range(0, 3);
                Instantiate(powerUps[randomPowerUp], new Vector3(Random.Range(-8.5f, 8.5f), 11f), Quaternion.identity);
            }
            yield return new WaitForSeconds(6.0f);
        }
    }
}
