using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameOver = true;

    public GameObject playerPrefab;
    private UIManager _uIManager;

    private void Start()
    {
        Random.InitState(666);
        _uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    private void Update()
    {
        if (gameOver)
        {
            if (Input.GetButton("Fire1"))
            {
                Instantiate(playerPrefab, new Vector3(0, -4, 0), Quaternion.identity);
                gameOver = false;
                _uIManager.HideTitle();
            }
        }
    }

    public bool isGameOver()
    {
        return this.gameOver;
    }

    public void GameOver()
    {
        this.gameOver = true;
        _uIManager.ShowTitle(); ;
    }
}
