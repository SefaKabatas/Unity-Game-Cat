using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomcisimler : MonoBehaviour
{
    public GameObject[] prefabs;

    private void Start()
    {
        InvokeRepeating("olustur", 0.4f, 1.8f);
    }
    void olustur()
    {
        float salla = Random.Range(0, prefabs.Length);
        Vector3 vec = new Vector3(Random.Range(-7.1f, 4.1f), 10, Random.Range(-10f, 10f));
        var x = Instantiate(prefabs[(int)salla], vec, Quaternion.identity);
        x.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 4, 0);
    }
}
