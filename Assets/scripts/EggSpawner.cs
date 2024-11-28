using System.Collections;
using UnityEngine;

public class EggSpawner : MonoBehaviour
{
    public GameObject eggPrefab;       // Prefab trứng
    public float spawnRange = 5f;      // Phạm vi sinh trứng
    public float initialInterval = 2f; // Thời gian ban đầu giữa các lần sinh
    public float intervalDecrease = 0.1f; // Giảm thời gian giữa các lần sinh
    public float minInterval = 0.5f;   // Thời gian tối thiểu giữa các lần sinh

    private float currentInterval;

    private void Start()
    {
        currentInterval = initialInterval;
        StartCoroutine(SpawnEggs());
    }

    private IEnumerator SpawnEggs()
    {
        while (true)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnRange, spawnRange), transform.position.y, 0);
            Instantiate(eggPrefab, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(currentInterval);
            currentInterval = Mathf.Max(minInterval, currentInterval - intervalDecrease); // Giảm thời gian
        }
    }
}
