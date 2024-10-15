using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public GameObject impactPrefab;
    public float velocidadProyectil;
    public Rigidbody2D rb2d;

    Vector3 posicionAnterior;
    // SonidosGameObject sonidosGO;

    private void Awake()
    {
        // sonidosGO = GetComponent<SonidosGameObject>();

    }

    IEnumerator Start()
    {
        posicionAnterior = transform.position;
        yield return new WaitForSeconds(3);

        // Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        rb2d.velocity = transform.up * velocidadProyectil;
    }

}
