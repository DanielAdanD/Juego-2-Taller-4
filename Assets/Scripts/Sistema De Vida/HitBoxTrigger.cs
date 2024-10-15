using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxTrigger : MonoBehaviour
{
    public int daño;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jugador"))
        {   
            if (collision.transform.GetComponent<Damagable>() != null)
                collision.transform.GetComponent<Damagable>().TakeDamage(daño);
        }
    }       
}