using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject enemyShipPrefab;
    [SerializeField]
    private GameObject[] powerUps; //0 tripleshot, 1 speed, 2 shield
    
    private Player player; 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Player>();
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(PowerUpSpawnRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while(player!=null && player.isAlive())
        {
            Instantiate(enemyShipPrefab, new Vector3(Random.Range(-8.5f, 8.5f), 11f), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator PowerUpSpawnRoutine()
    {
        while (player != null && player.isAlive())
        {
            int randomPowerUp = Random.Range(0, 3);
            Instantiate(powerUps[randomPowerUp], new Vector3(Random.Range(-8.5f, 8.5f), 11f), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }
}
