using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starkod : MonoBehaviour
{
    public GameObject spawnee;
    public bool stopspawing = false;
    public float spawntime;
    public float spawnDelay;
    void Start()
    {
        InvokeRepeating("SpawnObject", spawntime, spawnDelay);
        

    }

    public void SpawnObject()
    {
        Instantiate(spawnee, transform.position, transform.rotation);
        if (stopspawing)
        {
            CancelInvoke("SpawnObject");
        }
    }

}
