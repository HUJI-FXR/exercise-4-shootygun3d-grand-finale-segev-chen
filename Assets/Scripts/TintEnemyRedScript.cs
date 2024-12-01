using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TintEnemyRedScript : MonoBehaviour
{
    private LifeTotalScript lifeTotalScript;
    private Renderer[] renderers;
    [SerializeField] public Color colorToSet = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        lifeTotalScript = GetComponent<LifeTotalScript>();
        renderers = GetComponentsInChildren<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float lifeLeftRatio = lifeTotalScript.GetLeftLifeRatio();
        Color colorToSet = lifeLeftRatio * Color.white + (1f - lifeLeftRatio) * Color.red;
        foreach (Renderer renderer in renderers)
        {
            if (renderer != null)
            {
                renderer.material.color = colorToSet;
            }
        }

    }
}
