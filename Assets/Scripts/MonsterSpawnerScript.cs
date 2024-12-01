using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject monsterPrefab;
    [SerializeField] private int numberOfMonsters = 100;
    [SerializeField] private GameObject floor; // Reference to the floor (Plane object)
    [SerializeField] private float safeDistance = 10f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnMonsters();
    }

    private void SpawnMonsters()
    {
        // Ensure that the floor and monsterPrefab are set
        if (floor == null || monsterPrefab == null)
        {
            Debug.LogError("Floor or Monster Prefab is not assigned.");
            return;
        }

        for (int i = 0; i < numberOfMonsters; i++)
        {
            Vector3 randomPosition = GetRandomPositionOnFloor();
            randomPosition.y = floor.transform.position.y + safeDistance; // Set the y position to the floor's y level
            SpawnMonsterAtPosition(randomPosition);
        }
    }

    private Vector3 GetRandomPositionOnFloor()
    {
        // Random position within the floor's boundaries, ensuring safe distance from the edges
        float randomX = Random.Range(safeDistance, floor.transform.localScale.x - safeDistance);
        float randomZ = Random.Range(safeDistance, floor.transform.localScale.z - safeDistance);
        Vector3 randomPosition = new Vector3(randomX, 0, randomZ);

        // Adjust the random position based on the floor's world position
        randomPosition += floor.transform.position;

        return randomPosition;
    }

    private void SpawnMonsterAtPosition(Vector3 position)
    {
        // Instantiate the monster at the given position
        GameObject monster = Instantiate(monsterPrefab, position, Quaternion.identity);
        monster.SetActive(true); // Activate the monster
    }

    // Update is called once per frame (if needed for future updates)
    void Update()
    {

    }

}
