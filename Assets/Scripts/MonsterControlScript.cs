using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterControlScript : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    public float monsterTime = 5f;
    public float chasePlayerChance = 0.5f;
    [SerializeField] private float monsterTimer = 0f;
    private bool chasePlayer = false;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        monsterTimer += Time.deltaTime;
        if (monsterTimer >= monsterTime)
        {
            monsterTimer = 0f;
            chasePlayer = Random.Range(0f, 1f) < chasePlayerChance;
        }

        if (chasePlayer && player != null)
        {
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(directionToPlayer.x, 0, directionToPlayer.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 2f);
        }
        else
        {
            transform.Rotate(0, Random.Range(-30f, 30f) * Time.deltaTime, 0);
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
