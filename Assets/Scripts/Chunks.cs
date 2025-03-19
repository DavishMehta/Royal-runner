using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunks : MonoBehaviour
{

    [SerializeField] GameObject fence_prefab;
    [SerializeField] GameObject coin_prefab;
    List<float> horizontalDividation = new List<float> { -2.5f, 0, 2.5f};
    void Start()
    {
        SpawnFence();
        Debug.Log(horizontalDividation.Count);
    }

    void SpawnFence()
    {
        List<int> SpawnIndexNo = new List<int> { 0, 1, 2 };

        for (int i = 0; i < Random.Range(0, SpawnIndexNo.Count); i++)
        {
            int RandomIndex = Random.Range(0, horizontalDividation.Count);
            Vector3 spawnPosition = new Vector3(transform.position.x + horizontalDividation[RandomIndex], transform.position.y + 0.5f, transform.position.z);
            Debug.Log(horizontalDividation[RandomIndex]);
            Instantiate(fence_prefab, spawnPosition, Quaternion.identity, transform);
            horizontalDividation.RemoveAt(RandomIndex);
        }

        int RandomNo = Random.Range(0, horizontalDividation.Count + 1);
        for (int i = 0; i < RandomNo; i++)
        {
            int RandomIndex = Random.Range(0, horizontalDividation.Count);
            Vector3 spawnPosition = new Vector3(transform.position.x + horizontalDividation[RandomIndex], transform.position.y + 0.5f, transform.position.z);
            Debug.Log(horizontalDividation[RandomIndex]);
            Pickups coin = Instantiate(coin_prefab, spawnPosition, Quaternion.identity, transform).GetComponent<Pickups>();
            horizontalDividation.RemoveAt(RandomIndex);
        }
    }
}
