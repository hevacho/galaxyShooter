using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Sprite[] livesImage;
    public Image livesImageDisplay;
    public Text scoreText;
    public GameObject title;
    
    public int score;

    public void UpdateLives(int currentLives)
    {
        livesImageDisplay.sprite = livesImage[currentLives];
    }

    public void UpdateScore(int scoreEnemy)
    {
        score += scoreEnemy;

        scoreText.text = "Score " + score;
    }

   

    public void ShowTitle()
    {
        title.SetActive(true);
    }

    public void HideTitle()
    {
        title.SetActive(false);
        this.score = 0;
        UpdateScore(0);
    }

    
}
