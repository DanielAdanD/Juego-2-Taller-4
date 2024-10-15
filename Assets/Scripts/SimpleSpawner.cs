using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpawner : MonoBehaviour
{
    public Transform spawnPosition;
    public GameObject spawnObject;

    public void Spawn()
    {
        Instantiate(spawnObject, spawnPosition.position, spawnPosition.rotation);
    }
}
