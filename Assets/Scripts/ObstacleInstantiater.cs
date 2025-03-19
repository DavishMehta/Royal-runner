using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleInstantiater : MonoBehaviour
{

    [SerializeField] GameObject obs;
    [SerializeField] Transform obstacleControllerPosition;
    [SerializeField] float min_spawn_position;
    [SerializeField] float max_spawn_position;
    List<float> SpawnIndexNo = new List<float> { -2.5f,0,2.5f};

    private void Start()
    {
        InvokeRepeating("Instantiating_function", 1f, 0.7f);
    }

    void Instantiating_function() {
        Vector3 spawnPosition = new Vector3(obstacleControllerPosition.position.x + SpawnIndexNo[Random.Range(0, 3)], obstacleControllerPosition.position.y , obstacleControllerPosition.position.z);
        Instantiate(obs, spawnPosition, Random.rotation);
    }
}
