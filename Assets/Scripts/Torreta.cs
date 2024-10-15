using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour
{
    public bool puedeDisparar;

    public float tiempoCadencia;
    public float t;

    public GameObject prefabFlecha;
    public Transform puntoDeDisparo;
    public AudioSource audio;

    void Start()
    {
        
    }

    void Update()
    {
        Disparar();
        t += Time.deltaTime;
    }

    void Disparar()
    {
        
        if (puedeDisparar && t > tiempoCadencia)
        {
            GameObject flecha = Instantiate(prefabFlecha, puntoDeDisparo.position, puntoDeDisparo.rotation);
            audio.Play();
            t = 0f;
        }
        
    }
}
