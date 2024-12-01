using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTotalScript : MonoBehaviour
{
    [SerializeField] public int lifeTotal;
    [SerializeField] public int initialLifeTotal = 3;
    // Start is called before the first frame update
    void Start()
    {
        lifeTotal = initialLifeTotal;
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeTotal <= 0)
        {
            if (CompareTag("Player"))
            {
                HighScoreScript highScoreScript = FindObjectOfType<HighScoreScript>();
                if (highScoreScript != null)
                {
                    highScoreScript.EndGame(false); // Player lost
                }
            }
            // destroy the player
            Destroy(gameObject);
        }
    }

    public float GetLeftLifeRatio()
    {
        float temp = lifeTotal / initialLifeTotal;
        if (temp <= 0)
            return 0;
        return lifeTotal / initialLifeTotal;
    }

    public void takeDamage(int damage)
    {
        lifeTotal -= damage;
    }

    void OnDestroy()
    {
        if (CompareTag("Enemy"))
        {
            ScoreScript textScoreScript = FindObjectOfType<ScoreScript>();
            if (textScoreScript != null)
            {
                textScoreScript.AddScore();
            }
            // Check if all monsters are dead
            if (FindObjectsOfType<LifeTotalScript>().Length == 1) // Only Player remains
            {
                HighScoreScript highScoreScript = FindObjectOfType<HighScoreScript>();
                if (highScoreScript != null)
                {
                    highScoreScript.EndGame(true); // Player won
                }
            }

        }
    }
}
