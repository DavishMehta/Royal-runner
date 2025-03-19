using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] GameObject chunk_prefab;
    int temp = -10;
    float chunk_move_speed = 1f;
    List<GameObject> chunks = new List<GameObject>();
    [SerializeField] Camera mainCamera;
    float cameraDistanceFromChunk = 5f;

    void Start()
    {
        for(int i = 0; i < 9; i++)
        {
           Vector3 spawn_position = new Vector3(transform.position.x, transform.position.y, transform.position.z * i + temp);
           GameObject chunk_instant =  Instantiate(chunk_prefab, spawn_position, Quaternion.identity);
           temp -= 10;
           chunks.Add(chunk_instant);
        }   
    }

    void Update()
    {
        for(int i = 0; i < chunks.Count; i++) {
            GameObject chunk = chunks[i];
            chunk.transform.Translate(0, 0, 10*Time.deltaTime*chunk_move_speed);
            if (chunk.transform.position.z > mainCamera.transform.position.z+5f)
            {
                chunks.Remove(chunk);
                Destroy(chunk);
                Vector3 instantiatingPosition = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z - 10*chunks.Count-cameraDistanceFromChunk);
                GameObject instant2 =  Instantiate(chunk_prefab, instantiatingPosition, Quaternion.identity);
                chunks.Add(instant2);
            }
        }        
    }
}
