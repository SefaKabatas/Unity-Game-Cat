using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ucakKod : MonoBehaviour
{
    public float hız;
    public float max;
    public float min;
    public bool x;
    private Rigidbody2D fizik;
    public float yon = 1;
    void Start()
    {
        fizik = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;

        if(pos.x==min || pos.x == max)
        {
            yon = yon *-1;
            GameObject.Find("SpeedRunners").transform.Rotate(new Vector2(0, 180));


        }
        if (x)
        {
            pos.x = Mathf.Clamp(pos.x, min, max);
            fizik.velocity = new Vector2(Time.deltaTime * hız * yon, 0);

        }
        pos.z = 0;
        this.transform.position = pos;
    }
}
