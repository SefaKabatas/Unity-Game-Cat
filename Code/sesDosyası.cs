using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sesDosyası : MonoBehaviour
{
    private AudioSource ses;
    private float muzikSesi=0.5f;
    private float kapama;

    void Start()
    {
        ses = this.GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void Update()
    {
        ses.volume = muzikSesi;
    }
    public void SesAyarla(float vol)
    {
        if (muzikSesi == 0.5f)
        {
            muzikSesi = vol;

        }
        else
        {
            muzikSesi = 0.5f;
        }
    }
}
