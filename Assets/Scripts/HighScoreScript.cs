using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreScript : MonoBehaviour
{
    [Header("UI Components")]
    private TextMeshProUGUI highScoreText;

    [Header("High Score Management")]
    private int highScore;
    public ScoreScript scoreScript; // Reference to the ScoreScript

    [Header("Game Over UI")]
    public GameObject gameOverTextObject; // Assign the GameOverText GameObject here
    public TextMeshProUGUI gameOverMessage; // Assign the TextMeshProUGUI inside GameOverText



    // Start is called before the first frame update
    void Start()
    {
        highScoreText = GetComponent<TextMeshProUGUI>();

        if (highScoreText == null)
        {
            Debug.LogError("No TextMeshProUGUI component found on HighScoreText GameObject.");
        }

        // Load existing high score from PlayerPrefs
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            highScore = 0; // Default high score if not saved yet
        }

        // Display the current high score
        UpdateHighScoreUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckHighScore()
    {
        int currentScore = scoreScript.score;

        // Update high score if current score is higher
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore); // Save new high score
        }

        // Update the UI
        UpdateHighScoreUI();
    }

    private void UpdateHighScoreUI()
    {
        highScoreText.text = $"High Score: {highScore}";
    }

    public void EndGame(bool playerWon)
    {
        // Display game over text
        gameOverTextObject.SetActive(true);

        // Set the appropriate message
        if (playerWon)
        {
            gameOverMessage.text = "You Win!";
        }
        else
        {
            gameOverMessage.text = "You Lose!";
        }

        // Check and update high score
        CheckHighScore();
    }

}
