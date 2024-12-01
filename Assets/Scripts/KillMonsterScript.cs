using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMonsterScript : MonoBehaviour
{
    private LifeTotalScript lifeTotalScript;

    // Start is called before the first frame update
    void Start()
    {
        lifeTotalScript = GetComponent<LifeTotalScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeTotalScript.lifeTotal <= 0)
        {
            Destroy(gameObject);

        }
    }
}
