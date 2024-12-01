using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LifeBarScript : MonoBehaviour
{
    public LifeTotalScript playerLife;
    private TextMeshProUGUI lifeText;

    // Start is called before the first frame update
    void Start()
    {
        lifeText = GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        lifeText.text = $"HP: {playerLife.lifeTotal:F1}";

    }
}
