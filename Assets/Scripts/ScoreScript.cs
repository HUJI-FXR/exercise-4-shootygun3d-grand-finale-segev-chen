using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public int score = 0;
    [SerializeField] private float comboBonus = 1f;
    [SerializeField] private float comboTimer = 0f;
    [SerializeField] private TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        comboTimer += Time.deltaTime;
        scoreText.text = $"Score: {score}";
    }

    public void AddScore()
    {
        score += Mathf.FloorToInt(1f + comboBonus / comboTimer);
        comboTimer = 0f;
    }
}
